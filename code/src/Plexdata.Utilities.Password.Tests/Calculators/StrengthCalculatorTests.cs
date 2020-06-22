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

using NUnit.Framework;
using Plexdata.Utilities.Password.Calculators;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Calculators
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class StrengthCalculatorTests
    {
        [Test]
        public void Generate_SimpleGeneration_ResultContainsData()
        {
            String actual = this.GetInstance().Generate();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
        }

        [Test]
        public void Calculate_EntropyIsNaN_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => this.GetInstance().Calculate(Double.NaN), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Calculate_EntropyNegativeInfinity_ResultIsStrengthUnknown()
        {
            Strength actual = this.GetInstance().Calculate(Double.NegativeInfinity);

            Assert.That(actual, Is.EqualTo(Strength.Unknown));
        }

        [Test]
        public void Calculate_EntropyNegativeMinimum_ResultIsStrengthVeryWeak()
        {
            Strength actual = this.GetInstance().Calculate(Double.MinValue);

            Assert.That(actual, Is.EqualTo(Strength.VeryWeak));
        }

        [Test]
        public void Calculate_EntropyPositiveInfinity_ResultIsStrengthUnknown()
        {
            Strength actual = this.GetInstance().Calculate(Double.PositiveInfinity);

            Assert.That(actual, Is.EqualTo(Strength.Unknown));
        }

        [Test]
        public void Calculate_EntropyPositiveMaximum_ResultIsStrengthVeryStrong()
        {
            Strength actual = this.GetInstance().Calculate(Double.MaxValue);

            Assert.That(actual, Is.EqualTo(Strength.VeryStrong));
        }

        [TestCase(0, Strength.VeryWeak)]
        [TestCase(27.9, Strength.VeryWeak)]
        [TestCase(28, Strength.Weak)]
        [TestCase(35.9, Strength.Weak)]
        [TestCase(36, Strength.Reasonable)]
        [TestCase(59.9, Strength.Reasonable)]
        [TestCase(60, Strength.Strong)]
        [TestCase(127.9, Strength.Strong)]
        [TestCase(128, Strength.VeryStrong)]
        [TestCase(255, Strength.VeryStrong)]
        public void Calculate_EntropyIsValid_ResultAsExpected(Double entropy, Strength strength)
        {
            Strength actual = this.GetInstance().Calculate(entropy);

            Assert.That(actual, Is.EqualTo(strength));
        }

        private IStrengthCalculator GetInstance()
        {
            return new StrengthCalculator()
            {
                IsReinforced = false
            };
        }
    }
}
