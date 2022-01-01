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
using Plexdata.Utilities.Password.Collectors;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Collectors
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class PoolsCollectorTests
    {
        [Test]
        public void LowerPool_PropertyValueCheck_PropertyValueAsExpected()
        {
            Assert.That(this.GetInstance().Lowers, Is.EqualTo(PoolsTestHelper.ExpectedLowers));
        }

        [Test]
        public void UpperPool_PropertyValueCheck_PropertyValueAsExpected()
        {
            Assert.That(this.GetInstance().Uppers, Is.EqualTo(PoolsTestHelper.ExpectedUppers));
        }

        [Test]
        public void DigitPool_PropertyValueCheck_PropertyValueAsExpected()
        {
            Assert.That(this.GetInstance().Digits, Is.EqualTo(PoolsTestHelper.ExpectedDigits));
        }

        [Test]
        public void ExtraPool_PropertyValueCheck_PropertyValueAsExpected()
        {
            Assert.That(this.GetInstance().Extras, Is.EqualTo(PoolsTestHelper.ExpectedExtras));
        }

        [Test]
        public void OtherPool_PropertyValueCheck_PropertyValueAsExpected()
        {
            Assert.That(this.GetInstance().Latins, Is.EqualTo(PoolsTestHelper.ExpectedLatins));
        }

        [Test]
        public void Collect_WithoutArguments_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(), Is.EqualTo(PoolsTestHelper.ExpectedEntire));
        }

        [Test]
        public void Collect_WithLowersPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Lowers), Is.EqualTo(PoolsTestHelper.ExpectedLowers));
        }

        [Test]
        public void Collect_WithUppersPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Uppers), Is.EqualTo(PoolsTestHelper.ExpectedUppers));
        }

        [Test]
        public void Collect_WithDigitsPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Digits), Is.EqualTo(PoolsTestHelper.ExpectedDigits));
        }

        [Test]
        public void Collect_WithExtrasPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Extras), Is.EqualTo(PoolsTestHelper.ExpectedExtras));
        }

        [Test]
        public void Collect_WithOthersPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Latins), Is.EqualTo(PoolsTestHelper.ExpectedLatins));
        }

        [Test]
        public void Collect_WithCommonPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Common), Is.EqualTo(PoolsTestHelper.ExpectedCommon));
        }

        [Test]
        public void Collect_WithUnitedPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.United), Is.EqualTo(PoolsTestHelper.ExpectedUnited));
        }

        [Test]
        public void Collect_WithEntirePool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Entire), Is.EqualTo(PoolsTestHelper.ExpectedEntire));
        }

        [Test]
        public void Collect_WithUppersAndLowersPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Uppers | Pools.Lowers), Is.EqualTo(PoolsTestHelper.ExpectedLowers + PoolsTestHelper.ExpectedUppers));
        }

        [Test]
        public void Collect_WithDigitsAndUppersPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Digits | Pools.Uppers), Is.EqualTo(PoolsTestHelper.ExpectedUppers + PoolsTestHelper.ExpectedDigits));
        }

        [Test]
        public void Collect_WithOthersAndExtrasPool_ResultAsExpected()
        {
            Assert.That(this.GetInstance().Collect(Pools.Latins | Pools.Extras), Is.EqualTo(PoolsTestHelper.ExpectedExtras + PoolsTestHelper.ExpectedLatins));
        }

        private IPoolsCollector GetInstance()
        {
            return new PoolsCollector();
        }
    }
}
