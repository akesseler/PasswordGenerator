/*
 * MIT License
 * 
 * Copyright (c) 2022 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.Collections.Generic;

namespace Plexdata.PasswordGenerator.Generators
{
    public class ExtendedGenerator : IExtendedGenerator
    {
        #region Private Fields

        private readonly Random random = null;

        #endregion

        #region Construction

        public ExtendedGenerator()
        {
            this.random = new Random(Convert.ToInt32(DateTime.Now.Ticks & Int32.MaxValue));
        }

        #endregion

        #region Public Methods

        public IEnumerable<String> Generate(IExtendedSettings settings, IGeneratorSettings source)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return this.Generate(source.CollectSource(), settings.Length, settings.Amount);
        }

        #endregion

        #region Private Methods

        private IEnumerable<String> Generate(String source, Int32 length, Int32 amount)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            source = source.Shuffle(this.random);

            for (Int32 index = 0; index < amount; index++)
            {
                yield return source.Mingle(this.random, length);
            }
        }

        #endregion
    }
}
