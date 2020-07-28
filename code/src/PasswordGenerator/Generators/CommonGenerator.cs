/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
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

using Plexdata.PasswordGenerator.Enumerations;
using Plexdata.PasswordGenerator.Factories;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;

namespace Plexdata.PasswordGenerator.Generators
{
    public class CommonGenerator : ICommonGenerator
    {
        #region Construction

        public CommonGenerator()
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable<String> Generate(ICommonSettings settings, IGeneratorSettings source)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (settings.Amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(settings), $"Settings value {nameof(ICommonSettings.Amount)} must be greater than zero.");
            }

            if (settings.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(settings), $"Settings value {nameof(ICommonSettings.Length)} must be greater than zero.");
            }

            IPoolsCollector collector = CollectorFactory.Create<IPoolsCollector>();

            switch (settings.Type)
            {
                case CommonType.InternetPassword1:
                case CommonType.InternetPassword2:
                case CommonType.InternetPassword3:
                    return this.GenerateInternetPasswords(settings, collector);
                case CommonType.PasswordManager1:
                case CommonType.PasswordManager2:
                case CommonType.PasswordManager3:
                    return this.GenerateManagerPasswords(settings, collector);
                case CommonType.WepKey64Bit:
                case CommonType.WepKey128Bit:
                case CommonType.WepKey152Bit:
                case CommonType.WepKey256Bit:
                case CommonType.WepKeyCustom:
                case CommonType.WpaKey:
                case CommonType.Wpa2Key:
                    return this.GenerateWirelessPasswords(settings, collector);
                default:
                    throw new NotSupportedException($"Common type of {settings.Type} is not supported.");
            }
        }

        #endregion

        #region Private Methods

        private IEnumerable<String> GenerateInternetPasswords(ICommonSettings settings, IPoolsCollector collector)
        {
            IInternetPasswordGenerator generator = GeneratorFactory.Create<IInternetPasswordGenerator>();

            return generator.Generate(settings, collector);
        }

        private IEnumerable<String> GenerateManagerPasswords(ICommonSettings settings, IPoolsCollector collector)
        {
            IPasswordManagerGenerator generator = GeneratorFactory.Create<IPasswordManagerGenerator>();

            return generator.Generate(settings, collector);
        }

        private IEnumerable<String> GenerateWirelessPasswords(ICommonSettings settings, IPoolsCollector collector)
        {
            IWirelessPasswordGenerator generator = GeneratorFactory.Create<IWirelessPasswordGenerator>();

            return generator.Generate(settings, collector);
        }

        #endregion
    }
}
