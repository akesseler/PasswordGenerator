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

using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;

namespace Plexdata.Utilities.Password.Calculators
{
    // TODO: Finalize documentation.
    public class EntropyCalculator : IEntropyCalculator
    {
        // The entropy of each pool is nothing else but its length. If a password contains 
        // at least one character of one of the pools then its entropy is the length of the 
        // fitting pool. The total password entropy is made of the sum of entropies of each 
        // of the included pools. Finally, the calculation rule of the password entropy is 
        // either "E = log2(R^L)" or "E = log2(R)*L" with E = password entropy, R = pool of 
        // unique characters, L = number of charactes in the password (password length). For 
        // the source of the above conclusion see those links:
        // https://www.pleacher.com/mp/mlessons/algebra/entropy.html
        // https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy/
        // Final note about usage of "Diceware Words List" as well as of "English Dictionary 
        // Words". Both were intentionally not taken into account.

        #region Private Fields

        private readonly IPoolsCollector collector;

        #endregion

        #region Construction

        public EntropyCalculator()
            : this(CollectorFactory.Create<IPoolsCollector>())
        {
        }

        public EntropyCalculator(IPoolsCollector collector)
        {
            this.collector = collector ?? throw new ArgumentNullException(nameof(collector));
        }

        #endregion

        #region Public Methods

        public String Generate()
        {
            return
                "The entropy of each pool is nothing else but its length. If a password contains " +
                "at least one character of one of the pools then its entropy is the length of the " +
                "fitting pool. The total password entropy is made of the sum of entropies of each " +
                "of the included pools. Finally, the calculation rule of the password entropy is " +
                "either \"E = log2(R ^ L)\" or \"E = log2(R) * L\" with E = password entropy, R = pool " +
                "of unique characters, L = number of charactes in the password (password length). For " +
                "the source of the above conclusion see those links: " +
                "https://www.pleacher.com/mp/mlessons/algebra/entropy.html, " +
                "https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy/ " +
                "Final note about usage of \"Diceware Words List\" as well as of \"English Dictionary " +
                "Words\". Both were intentionally not taken into account.";
        }

        public Double Calculate(String password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return 0d;
            }

            Double lower = 0d;
            Double upper = 0d;
            Double digit = 0d;
            Double extra = 0d;
            Double other = 0d;

            foreach (Char symbol in password)
            {
                lower = this.AddEntropy(symbol, lower, this.collector.Lowers);
                upper = this.AddEntropy(symbol, upper, this.collector.Uppers);
                digit = this.AddEntropy(symbol, digit, this.collector.Digits);
                extra = this.AddEntropy(symbol, extra, this.collector.Extras);
                other = this.AddEntropy(symbol, other, this.collector.Latins);
            }

            return this.GetEntropy(password.Length, lower, upper, digit, extra, other);
        }

        #endregion

        #region Private Methods

        private Double AddEntropy(Char symbol, Double value, String sources)
        {
            if (value == 0d)
            {
                foreach (Char source in sources)
                {
                    if (source == symbol)
                    {
                        value = sources.Length;
                        break;
                    }
                }
            }

            return value;
        }

        private Double GetEntropy(Double length, params Double[] values)
        {
            Double total = 0d;

            foreach (Double value in values)
            {
                total += value;
            }

            return Math.Log(total, 2) * length;
        }

        #endregion
    }
}
