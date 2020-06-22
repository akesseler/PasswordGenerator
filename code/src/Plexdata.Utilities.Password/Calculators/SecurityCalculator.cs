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

using Plexdata.Utilities.Password.Entities;
using Plexdata.Utilities.Password.Interfaces;
using System;

namespace Plexdata.Utilities.Password.Calculators
{
    // TODO: Finalize documentation.
    public class SecurityCalculator : ISecurityCalculator
    {
        // According to (see link below) a particular password might be cracked in "<n> seconds". 
        // These "seconds" are defined by mathematical formula: T = (2^(log2(R)*L))/G which is 
        // equivalent to T = (2^E)/G with E = password entropy, R = pool of unique characters, 
        // L = number of characters in the password (password length), G = number of guesses per 
        // second a computer can make (e.g. 2800000000 guesses per seconds).
        // https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy/

        #region Construction

        public SecurityCalculator()
        {
        }

        #endregion

        #region Public Methods

        public String Generate()
        {
            return
                "According to (see link below) a particular password might be cracked in \"<n> seconds\". " +
                "These \"seconds\" are defined by mathematical formula: T = (2^(log2(R)*L))/G which is " +
                "equivalent to T = (2^E)/G with E = password entropy, R = pool of unique characters, " +
                "L = number of characters in the password (password length), G = number of guesses per " +
                "second a computer can make (e.g. 2800000000 guesses per seconds). " +
                "https://ritcyberselfdefense.wordpress.com/2011/09/24/how-to-calculate-password-entropy/ ";
        }

        public Duration Calculate(Scenario scenario, Double entropy)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario), $"The argument {nameof(scenario)} must not be null.");
            }

            if (entropy < 0d)
            {
                throw new ArgumentOutOfRangeException(nameof(entropy), $"The argument {nameof(entropy)} must be greater than or equal to zero.");
            }

            if (scenario.Guesses == 0)
            {
                throw new DivideByZeroException("Number of guesses per second must not be zero.");
            }

            if (entropy == 0d)
            {
                return Duration.Zero;
            }

            Duration result = Duration.Zero;

            Double total = Math.Pow(2, entropy) / scenario.Guesses;

            try
            {
                result = Duration.FromSeconds(total);
            }
            catch (OverflowException)
            {
                result = Duration.Maximum;
            }

            return result;
        }

        #endregion
    }
}
