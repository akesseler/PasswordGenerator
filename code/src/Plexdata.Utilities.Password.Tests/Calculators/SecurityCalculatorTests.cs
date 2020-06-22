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
using Plexdata.Utilities.Password.Entities;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Calculators
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class SecurityCalculatorTests
    {
        [Test]
        public void Generate_SimpleGeneration_ResultContainsData()
        {
            String actual = this.GetInstance().Generate();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
        }

        [Test]
        public void Calculate_ScenarioIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => this.GetInstance().Calculate(null, 42), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_EntropyIsLessZero_ThrowsArgumentNullException()
        {
            Assert.That(() => this.GetInstance().Calculate(new Scenario(), -1), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Calculate_GuessesIsZero_ThrowsDivideByZeroException()
        {
            Assert.That(() => this.GetInstance().Calculate(new Scenario(), 42), Throws.InstanceOf<DivideByZeroException>());
        }

        [Test]
        public void Calculate_EntropyIsZero_ThrowsArgumentNullException()
        {
            Duration actual = this.GetInstance().Calculate(new Scenario() { Guesses = 10 }, 0);

            Assert.That(actual, Is.EqualTo(Duration.Zero));
        }

        [Test]
        public void Calculate_ParametersValid_ResultAsExpected()
        {
            Double guesses = 10;
            Double entropy = 10;

            Duration actual = this.GetInstance().Calculate(new Scenario() { Guesses = guesses }, entropy);

            Assert.That(actual, Is.EqualTo(Duration.FromSeconds(Math.Pow(2, entropy) / guesses)));
        }

        [Test]
        public void Calculate_ParametersWithOverflow_ResultAsExpected()
        {
            Double guesses = 1;
            Double entropy = Double.MaxValue;

            Duration actual = this.GetInstance().Calculate(new Scenario() { Guesses = guesses }, entropy);

            Assert.That(actual, Is.EqualTo(Duration.Maximum));
        }

        private ISecurityCalculator GetInstance()
        {
            return new SecurityCalculator();
        }
    }
}
