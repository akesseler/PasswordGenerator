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

using Plexdata.PasswordGenerator.Generators;
using Plexdata.PasswordGenerator.Interfaces;
using System;

namespace Plexdata.PasswordGenerator.Factories
{
    public class GeneratorFactory
    {
        #region Public methods

        public static TInterface Create<TInterface>()
        {
            Object result = null;

            if (typeof(TInterface) == typeof(IExchangeGenerator))
            {
                result = new ExchangeGenerator();
            }
            else if (typeof(TInterface) == typeof(IExtendedGenerator))
            {
                result = new ExtendedGenerator();
            }
            else if (typeof(TInterface) == typeof(ICommonGenerator))
            {
                result = new CommonGenerator();
            }
            else if (typeof(TInterface) == typeof(IInternetPasswordGenerator))
            {
                result = new InternetPasswordGenerator();
            }
            else if (typeof(TInterface) == typeof(IPasswordManagerGenerator))
            {
                result = new PasswordManagerGenerator();
            }
            else if (typeof(TInterface) == typeof(IWirelessPasswordGenerator))
            {
                result = new WirelessPasswordGenerator();
            }
            else
            {
                throw new NotSupportedException($"Interface type of \"{typeof(TInterface).Name}\" is not supported.");
            }

            return (TInterface)result;
        }

        #endregion
    }
}
