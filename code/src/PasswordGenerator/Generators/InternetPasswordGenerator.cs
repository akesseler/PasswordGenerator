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
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Plexdata.PasswordGenerator.Generators
{
    // For some examples see https://www.gaijin.at/de/tools/password-generator
    public class InternetPasswordGenerator : IInternetPasswordGenerator
    {
        #region Private Fields

        private readonly Random random = null;

        #endregion

        #region Construction

        public InternetPasswordGenerator()
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

            List<String> results = new List<String>();

            for (Int32 count = 0; count < settings.Amount; count++)
            {
                List<String> sources = new List<String>();

                switch (settings.Type)
                {
                    case CommonType.InternetPassword1:
                        this.ApplySourcesType1(collector, settings.Length, sources);
                        break;
                    case CommonType.InternetPassword2:
                        this.ApplySourcesType2(collector, settings.Length, sources);
                        break;
                    case CommonType.InternetPassword3:
                        this.ApplySourcesType3(collector, settings.Length, sources);
                        break;
                    default:
                        throw new NotSupportedException($"Common type of \"{settings.Type}\" is not supported.");
                }

                String result = sources.Raffle(this.random);

                results.Add(result);
            }

            this.DumpGeneratorResults(settings, results);

            return results;
        }

        #endregion

        #region Private Methods

        private void ApplySourcesType1(IPoolsCollector collector, Int32 length, List<String> sources)
        {
            for (Int32 index = 0; index < length; index++)
            {
                if (index == 0)
                {
                    sources.Add(collector.Consonants.Shuffle(this.random).ToUpper());
                }
                else if (index + 2 >= length)
                {
                    sources.Add(collector.Digits.Shuffle(this.random));
                }
                else if (index % 2 != 0)
                {
                    sources.Add(collector.Vowels.Shuffle(this.random));
                }
                else
                {
                    sources.Add(collector.Consonants.Shuffle(this.random));
                }
            }
        }

        private void ApplySourcesType2(IPoolsCollector collector, Int32 length, List<String> sources)
        {
            // TODO: Change algorithm so that it better fits the rules: Cvcv[0..n/2-1]XVcvc[n/-1..n-2]DD
            // C = consonant; V = Vowel; X = Extra; D = Digit

            Int32 count = 0;
            Int32 index = 0;

            sources.Add(collector.Consonants.Shuffle(this.random).ToUpper());
            index++;

            if (index >= length) { return; }

            count = (length - 1) / 2;

            for (; index < count; index++)
            {
                if (index % 2 != 0)
                {
                    sources.Add(collector.Vowels.Shuffle(this.random));
                }
                else
                {
                    sources.Add(collector.Consonants.Shuffle(this.random));
                }
            }

            if (index >= length) { return; }

            sources.Add(collector.Collect(Pools.Symbols | Pools.Operators | Pools.Punctuations | Pools.Spaces).Shuffle(this.random));
            index++;

            if (index >= length) { return; }

            sources.Add(collector.Vowels.Shuffle(this.random).ToUpper());
            index++;

            if (index >= length) { return; }

            count = length - 2;

            for (; index < count; index++)
            {
                if (index % 2 != 0)
                {
                    sources.Add(collector.Vowels.Shuffle(this.random));
                }
                else
                {
                    sources.Add(collector.Consonants.Shuffle(this.random));
                }
            }

            if (index >= length) { return; }

            count = length;

            for (; index < count; index++)
            {
                sources.Add(collector.Digits.Shuffle(this.random));
            }
        }

        private void ApplySourcesType3(IPoolsCollector collector, Int32 length, List<String> sources)
        {
            // TODO: Change algorithm so that it better fits the rules: Cvcv[0..n/2-1]XVcvc[n/-1..n-3]DDD
            // C = consonant; V = Vowel; X = Extra; D = Digit

            Int32 count = 0;
            Int32 index = 0;

            sources.Add(collector.Consonants.Shuffle(this.random).ToUpper());
            index++;

            if (index >= length) { return; }

            count = (length - 3) / 2;

            for (; index < count; index++)
            {
                if (index % 2 != 0)
                {
                    sources.Add(collector.Vowels.Shuffle(this.random));
                }
                else
                {
                    sources.Add(collector.Consonants.Shuffle(this.random));
                }
            }

            if (index >= length) { return; }

            sources.Add(collector.Collect(Pools.Symbols | Pools.Operators | Pools.Punctuations | Pools.Spaces).Shuffle(this.random));
            index++;

            if (index >= length) { return; }

            sources.Add(collector.Vowels.Shuffle(this.random).ToUpper());
            index++;

            if (index >= length) { return; }

            count = length - 3;

            for (; index < count; index++)
            {
                if (index % 2 == 0)
                {
                    sources.Add(collector.Vowels.Shuffle(this.random));
                }
                else
                {
                    sources.Add(collector.Consonants.Shuffle(this.random));
                }
            }

            if (index >= length) { return; }

            count = length;

            for (; index < count; index++)
            {
                sources.Add(collector.Digits.Shuffle(this.random));
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
