﻿/*
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

using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.Text;

namespace Plexdata.PasswordGenerator.Generators
{
    public class ExchangeGenerator : IExchangeGenerator
    {
        #region Construction

        public ExchangeGenerator()
        {
        }

        #endregion

        #region Public methods

        public String Generate(IExchangeSettings settings, String source)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            StringBuilder builder = new StringBuilder(source);

            foreach ((Char From, Char Into) in settings.CollectValues())
            {
                builder.Replace(From, Into);
            }

            return builder.ToString();
        }

        #endregion
    }
}
