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

using NUnit.Framework;
using Plexdata.Utilities.Password.Calculators;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Calculators
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class EntropyCalculatorTests
    {
        [Test]
        public void EntropyCalculator_IPoolsCollectorIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => new EntropyCalculator(null), Throws.ArgumentNullException);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Calculate_ValueIsInvalid_ResultIsZero(String value)
        {
            Double actual = this.GetInstance().Calculate(value);

            Assert.That(actual, Is.Zero);
        }

        [TestCase("a", 26)]
        [TestCase("A", 26)]
        [TestCase("1", 10)]
        [TestCase("!", 30)]
        [TestCase(" ", 127)]
        [TestCase("aA", 52)]
        [TestCase("a1", 36)]
        [TestCase("A1", 36)]
        [TestCase("a!", 56)]
        [TestCase("A!", 56)]
        [TestCase("aA!", 82)]
        [TestCase("aA1!", 92)]
        [TestCase("aA 1!", 219)]
        public void Calculate_ValueIsValid_ResultAsExpected(String value, Int32 total)
        {
            Double actual = this.GetInstance().Calculate(value);

            Assert.That(actual, Is.EqualTo(Math.Log(total, 2) * value.Length));
        }

        private IEntropyCalculator GetInstance()
        {
            return new EntropyCalculator();
        }
    }
}
