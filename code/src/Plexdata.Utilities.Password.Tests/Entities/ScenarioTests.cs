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
using Plexdata.Utilities.Password.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Plexdata.Utilities.Password.Tests.Entities
{
    [Category("UnitTest")]
    [ExcludeFromCodeCoverage]
    public class ScenarioTests
    {
        [Test]
        public void Scenario_DefaultConstruction_PropertiesAsExpected()
        {
            Scenario actual = new Scenario();

            Assert.That(actual.Name, Is.Empty);
            Assert.That(actual.Text, Is.Empty);
            Assert.That(actual.Note, Is.EqualTo("Note that typical attacks will be online password guessing limited to, at most, a few hundred guesses per second."));
            Assert.That(actual.Guesses, Is.Zero);
        }

        [Test]
        public void Scenario_ThreeParameterConstruction_PropertiesAsExpected()
        {
            Scenario actual = new Scenario("name", "text", 42D);

            Assert.That(actual.Name, Is.EqualTo("name"));
            Assert.That(actual.Text, Is.EqualTo("text"));
            Assert.That(actual.Note, Is.EqualTo("Note that typical attacks will be online password guessing limited to, at most, a few hundred guesses per second."));
            Assert.That(actual.Guesses, Is.EqualTo(42D));
        }

        [Test]
        public void Scenario_FourParameterConstruction_PropertiesAsExpected()
        {
            Scenario actual = new Scenario("name", "text", "note", 42D);

            Assert.That(actual.Name, Is.EqualTo("name"));
            Assert.That(actual.Text, Is.EqualTo("text"));
            Assert.That(actual.Note, Is.EqualTo("note"));
            Assert.That(actual.Guesses, Is.EqualTo(42D));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Name_ValueIsInvalid_ThrowArgumentOutOfRangeException(String value)
        {
            Scenario actual = new Scenario();

            Assert.That(() => actual.Name = value, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Name_ValueIsValid_PropertyAsExpected()
        {
            Scenario actual = new Scenario() { Name = "value" };

            Assert.That(actual.Name, Is.EqualTo("value"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Text_ValueIsInvalid_ThrowArgumentOutOfRangeException(String value)
        {
            Scenario actual = new Scenario();

            Assert.That(() => actual.Text = value, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Text_ValueIsValid_PropertyAsExpected()
        {
            Scenario actual = new Scenario() { Text = "value" };

            Assert.That(actual.Text, Is.EqualTo("value"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Note_ValueIsInvalid_ThrowArgumentOutOfRangeException(String value)
        {
            Scenario actual = new Scenario();

            Assert.That(() => actual.Note = value, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Note_ValueIsValid_PropertyAsExpected()
        {
            Scenario actual = new Scenario() { Note = "value" };

            Assert.That(actual.Note, Is.EqualTo("value"));
        }

        [TestCase(0d)]
        [TestCase(-1d)]
        public void Guesses_ValueIsInvalid_ThrowArgumentOutOfRangeException(Double value)
        {
            Scenario actual = new Scenario();

            Assert.That(() => actual.Guesses = value, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Guesses_ValueIsValid_PropertyAsExpected()
        {
            Scenario actual = new Scenario() { Guesses = 0.00000000000000001d };

            Assert.That(actual.Guesses, Is.EqualTo(0.00000000000000001d));
        }
    }
}
