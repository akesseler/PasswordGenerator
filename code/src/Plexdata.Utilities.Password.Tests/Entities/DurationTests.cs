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
using Plexdata.Utilities.Password.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Entities
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class DurationTests
    {
        [TestCase(-1)]
        [TestCase(Double.NaN)]
        public void FromSeconds_SecondsInvalid_ThrowsArgumentOutOfRangeException(Double seconds)
        {
            Assert.That(() => Duration.FromSeconds(seconds), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase(Double.PositiveInfinity)]
        [TestCase(Double.NegativeInfinity)]
        public void FromSeconds_SecondsInfinity_ThrowsOverflowException(Double seconds)
        {
            Assert.That(() => Duration.FromSeconds(seconds), Throws.InstanceOf<OverflowException>());
        }

        [Test]
        public void FromSeconds_SecondsBeyondLimits_ResultIsTimeSpanMaxValue()
        {
            String expected = this.TimeSpanToString(TimeSpan.MaxValue);

            String actual = Duration.FromSeconds(Double.MaxValue).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DurationTests.SecondsFromTestClasses))]
        public void FromSeconds_SecondsFromTestClasses_ResultAsExpected(Object value)
        {
            // NOTE: These tests do not really make sense because of its calculation is same as in the tested class.

            TestClass current = value as TestClass;

            Duration actual = Duration.FromSeconds(current.Total);

            Assert.That(actual.Millennia, Is.EqualTo(current.Millennia));
            Assert.That(actual.Centuries, Is.EqualTo(current.Centuries));
            Assert.That(actual.Decades, Is.EqualTo(current.Decades));
            Assert.That(actual.Years, Is.EqualTo(current.Years));
            Assert.That(actual.Months, Is.EqualTo(current.Months));
            Assert.That(actual.Weeks, Is.EqualTo(current.Weeks));
            Assert.That(actual.Days, Is.EqualTo(current.Days));
            Assert.That(actual.Hours, Is.EqualTo(current.Hours));
            Assert.That(actual.Minutes, Is.EqualTo(current.Minutes));
            Assert.That(actual.Seconds, Is.EqualTo(current.Seconds));
            Assert.That(actual.Milliseconds, Is.EqualTo(current.Milliseconds));
        }

        private static Object[] SecondsFromTestClasses =
        {
            new TestClass(1.555),             // 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 555
            new TestClass(60.555),            // 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 555
            new TestClass(3600.555),          // 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 555
            new TestClass(86400.555),         // 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 555
            new TestClass(604800.555),        // 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 555
            new TestClass(18144000.555),      // 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 555
            new TestClass(6622560000.555),    // 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 555
            new TestClass(66225600000.555),   // 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 555
            new TestClass(662256000000.555),  // 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 555
            new TestClass(6622560000000.555), // 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 555
            new TestClass(61.555),            // 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 555
            new TestClass(3661.555),          // 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 555
            new TestClass(90061.555),         // 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 555
            new TestClass(694861.555),        // 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 555
            new TestClass(18838861.555),      // 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 555
            new TestClass(6641398861.555),    // 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 555
            new TestClass(72866998861.555),   // 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 555
            new TestClass(735122998861.555),  // 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 555
            new TestClass(7357682998861.555), // 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 555
        };

        private class TestClass
        {
            public TestClass(Double seconds)
            {
                this.Total = seconds;

                TimeSpan helper;

                if (TimeSpan.MaxValue.TotalSeconds < seconds)
                {
                    helper = TimeSpan.MaxValue;
                }
                else
                {
                    helper = TimeSpan.FromSeconds(seconds);
                }

                Int32 days = helper.Days;

                this.Millennia = Convert.ToInt32(days / (10 * 10 * 10 * 365));
                days = days % (10 * 10 * 10 * 365);

                this.Centuries = Convert.ToInt32(days / (10 * 10 * 365));
                days = days % (10 * 10 * 365);

                this.Decades = Convert.ToInt32(days / (10 * 365));
                days = days % (10 * 365);

                this.Years = Convert.ToInt32(days / 365);
                days = days % 365;

                this.Months = Convert.ToInt32(days / 30);
                days = days % 30;

                this.Weeks = Convert.ToInt32(days / 7);
                days = days % 7;

                this.Days = days;

                this.Hours = helper.Hours;
                this.Minutes = helper.Minutes;
                this.Seconds = helper.Seconds;
                this.Milliseconds = helper.Milliseconds;
            }

            public Double Total { get; private set; }
            public Int32 Millennia { get; private set; }
            public Int32 Centuries { get; private set; }
            public Int32 Decades { get; private set; }
            public Int32 Years { get; private set; }
            public Int32 Months { get; private set; }
            public Int32 Weeks { get; private set; }
            public Int32 Days { get; private set; }
            public Int32 Hours { get; private set; }
            public Int32 Minutes { get; private set; }
            public Int32 Seconds { get; private set; }
            public Int32 Milliseconds { get; private set; }

            public override String ToString()
            {
                return String.Format(
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, Total: {11}",
                    this.Millennia, this.Centuries, this.Decades, this.Years, this.Months, this.Weeks,
                    this.Days, this.Hours, this.Minutes, this.Seconds, this.Milliseconds, this.Total);
            }
        }

        private String TimeSpanToString(TimeSpan value)
        {
            return String.Format("{0}.{1:00}:{2:00}:{3:00}.{4:####}", value.Days, value.Hours, value.Minutes, value.Seconds, value.Milliseconds);
        }
    }
}
