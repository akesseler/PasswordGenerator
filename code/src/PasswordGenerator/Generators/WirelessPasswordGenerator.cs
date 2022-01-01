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

using Plexdata.PasswordGenerator.Enumerations;
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Plexdata.PasswordGenerator.Generators
{
    // For some examples see:
    // * https://www.gaijin.at/de/tools/password-generator (WEP/WPA),
    // * http://www.andrewscompanies.com/tools/wep.asp (WEP),
    // * https://www.blattertech.ch/itsupport/wpa-key-generator.htm (WPA),
    // * https://ms07.de/wlankeygen/ (WEP/WPA)

    public class WirelessPasswordGenerator : IWirelessPasswordGenerator
    {
        #region Private Fields

        private readonly Random random = null;

        #endregion

        #region Construction

        public WirelessPasswordGenerator()
        {
            this.random = new Random(Convert.ToInt32(DateTime.Now.Ticks & Int32.MaxValue));
        }

        #endregion

        #region Public Methods

        public IEnumerable<String> Generate(ICommonSettings settings, IPoolsCollector collector)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (collector == null)
            {
                throw new ArgumentNullException(nameof(collector));
            }

            if (settings.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(settings), $"Settings value {nameof(ICommonSettings.Length)} must be greater than zero.");
            }

            if (settings.Amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(settings), $"Settings value {nameof(ICommonSettings.Amount)} must be greater than zero.");
            }

            Pools pools = Pools.Nothing;

            if (settings.IsUppers) { pools |= Pools.Uppers; }
            if (settings.IsLowers) { pools |= Pools.Lowers; }
            if (settings.IsDigits) { pools |= Pools.Digits; }
            if (settings.IsExtras) { pools |= Pools.Extras; }

            String source = collector.Collect(pools);

            if (String.IsNullOrWhiteSpace(source))
            {
                return Enumerable.Empty<String>();
            }

            IEnumerable<String> results = null;

            switch (settings.Type)
            {
                case CommonType.WepKey64Bit:
                case CommonType.WepKey128Bit:
                case CommonType.WepKey152Bit:
                case CommonType.WepKey256Bit:
                    results = this.GenerateWepKeys(source, settings.Length, settings.Amount);
                    break;
                case CommonType.WepKeyCustom:
                    results = this.GenerateWepKeyFromPhrase(settings.Phrase);
                    break;
                case CommonType.WpaKey:
                case CommonType.Wpa2Key:
                    results = this.GenerateWpaKeys(source, settings.Length, settings.Amount);
                    break;
                default:
                    throw new NotSupportedException($"Common type of \"{settings.Type}\" is not supported.");
            }

            this.DumpGeneratorResults(settings, results);

            return results;
        }

        #endregion

        #region Private Methods

        private IEnumerable<String> GenerateWepKeys(String source, Int32 length, Int32 amount)
        {
            source = source.Shuffle(this.random);

            for (Int32 index = 0; index < amount; index++)
            {
                String value = source.Mingle(this.random, length / 2);

                Byte[] bytes = Encoding.ASCII.GetBytes(value);

                String result = BitConverter.ToString(bytes).Replace("-", String.Empty).ToLower();

                yield return $"{value}\t{result}";
            }
        }

        private IEnumerable<String> GenerateWepKeyFromPhrase(String phrase)
        {
            if (String.IsNullOrEmpty(phrase))
            {
                yield return String.Empty;
            }

            Byte[] bytes = Encoding.ASCII.GetBytes(phrase);

            String result = BitConverter.ToString(bytes).Replace("-", String.Empty).ToLower();

            yield return $"{phrase}\t{result}";
        }

        private IEnumerable<String> GenerateWpaKeys(String source, Int32 length, Int32 amount)
        {
            source = source.Shuffle(this.random);

            for (Int32 index = 0; index < amount; index++)
            {
                String value = source.Mingle(this.random, length);

                yield return value;
            }
        }

        [Conditional("DEBUG")]
        private void DumpGeneratorResults(ICommonSettings settings, IEnumerable<String> results)
        {
            Debug.WriteLine($"Type: {settings.Type}, Length: {settings.Length}, Amount: {settings.Amount}");

            foreach (String result in results)
            {
                Debug.WriteLine(result);
            }
        }

        #endregion
    }
}
