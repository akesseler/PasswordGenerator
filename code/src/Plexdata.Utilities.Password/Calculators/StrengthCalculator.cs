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

using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;

namespace Plexdata.Utilities.Password.Calculators
{
    // TODO: Finalize documentation.
    public class StrengthCalculator : IStrengthCalculator
    {
        #region Private Fields

        private Boolean reinforced = false;

        private readonly IDictionary<Strength, (Double Minimum, Double Maximum)> limits = null;

        #endregion

        #region Construction

        public StrengthCalculator()
        {
            this.limits = new Dictionary<Strength, (Double Minimum, Double Maximum)>
            {
                { Strength.VeryWeak,   (Double.NaN, Double.NaN) },
                { Strength.Weak,       (Double.NaN, Double.NaN) },
                { Strength.Reasonable, (Double.NaN, Double.NaN) },
                { Strength.Strong,     (Double.NaN, Double.NaN) },
                { Strength.VeryStrong, (Double.NaN, Double.NaN) },
            };

            this.IsReinforced = true;
        }

        #endregion

        #region Public Properties

        public Boolean IsReinforced
        {
            get
            {
                return this.reinforced;
            }
            set
            {
                if (this.reinforced != value)
                {
                    this.reinforced = value;
                    this.ApplyReinforcedMode();
                }
            }
        }

        #endregion

        #region Public Methods

        public Strength Calculate(Double entropy)
        {
            if (Double.IsNaN(entropy))
            {
                throw new ArgumentOutOfRangeException(nameof(entropy), "Entropy must be a valid number.");
            }

            foreach (KeyValuePair<Strength, (Double Minimum, Double Maximum)> limit in this.limits)
            {
                Strength strength = limit.Key;
                Double minimum = limit.Value.Minimum;
                Double maximum = limit.Value.Maximum;

                if (entropy >= minimum && (entropy < maximum || (entropy <= maximum && strength == Strength.VeryStrong)))
                {
                    return strength;
                }
            }

            return Strength.Unknown;
        }

        public Double ToPercent(Double entropy)
        {
            // Should be "this.limits[Strength.VeryWeak].Minimum"...
            // But that value is "Double.MinValue". Thus, it is zero.
            Double minimum = 0d;

            // Should be "this.limits[Strength.VeryStrong].Maximum"...
            // But that value is "Double.MaxValue". Thus, it is 
            // "this.limits[Strength.VeryStrong].Minimum".
            Double maximum = this.limits[Strength.VeryStrong].Minimum;

            if (entropy < minimum)
            {
                return 0d;
            }

            if (entropy > maximum)
            {
                return 100d;
            }

            return (entropy * 100d) / (maximum - minimum);
        }

        public String ToSummary(Strength strength)
        {
            switch (strength)
            {
                case Strength.Unknown:
                    return "Entropy range is unknown yet.";
                case Strength.VeryWeak:
                    return $"Entropy range less than {this.limits[strength].Maximum} bits, which is very weak. It might keep out family members.";
                case Strength.Weak:
                    return $"Entropy range from {this.limits[strength].Minimum} up to {this.limits[strength].Maximum} bits, which is weak. It should keep out most people, often good for desktop login passwords.";
                case Strength.Reasonable:
                    return $"Entropy range from {this.limits[strength].Minimum} up to {this.limits[strength].Maximum} bits, which is reasonable. It fairly secures passwords for network and company passwords.";
                case Strength.Strong:
                    return $"Entropy range from {this.limits[strength].Minimum} up to {this.limits[strength].Maximum} bits, which is strong. It could be good for guarding financial information.";
                case Strength.VeryStrong:
                    return $"Entropy range is equal to or greater than {this.limits[strength].Minimum} bits, which is very strong. It is often considered as overkill.";
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion

        #region Private Methods

        private void ApplyReinforcedMode()
        {
            if (this.IsReinforced)
            {
                // Values from https://keepass.info/help/kb/pw_quality_est.html
                this.limits[Strength.VeryWeak] = (Minimum: Double.MinValue, Maximum: 64);
                this.limits[Strength.Weak] = (Minimum: 64, Maximum: 80);
                this.limits[Strength.Reasonable] = (Minimum: 80, Maximum: 112);
                this.limits[Strength.Strong] = (Minimum: 112, Maximum: 128);
                this.limits[Strength.VeryStrong] = (Minimum: 128, Maximum: Double.MaxValue);
            }
            else
            {
                // Values from https://www.pleacher.com/mp/mlessons/algebra/entropy.html
                this.limits[Strength.VeryWeak] = (Minimum: Double.MinValue, Maximum: 28);
                this.limits[Strength.Weak] = (Minimum: 28, Maximum: 36);
                this.limits[Strength.Reasonable] = (Minimum: 36, Maximum: 60);
                this.limits[Strength.Strong] = (Minimum: 60, Maximum: 128);
                this.limits[Strength.VeryStrong] = (Minimum: 128, Maximum: Double.MaxValue);
            }
        }

        #endregion
    }
}
