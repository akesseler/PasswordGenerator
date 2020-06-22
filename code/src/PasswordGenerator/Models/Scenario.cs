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

using Plexdata.PasswordGenerator.Settings;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Models
{
    [XmlType("scenario")]
    [DebuggerDisplay("Name = {this.Name}, Guesses = {this.Guesses}")]
    public class Scenario : NotifySettings
    {
        private String name = null;
        private String text = null;
        private String note = null;
        private Double guesses = 0d;

        public Scenario()
            : base()
        {
            this.Note = "Note that typical attacks will be online password guessing limited to, at most, a few hundred guesses per second.";
        }

        public Scenario(String name, String text, Double guesses)
            : this()
        {
            this.Name = name;
            this.Text = text;
            this.Guesses = guesses;
        }

        public Scenario(String name, String text, String note, Double guesses)
            : this(name, text, guesses)
        {
            this.Note = note;
        }

        [XmlIgnore]
        public static Scenario New
        {
            get
            {
                return new Scenario("Name", "Text", null, 1000d);
            }
        }

        [XmlElement("name")]
        public String Name
        {
            get
            {
                return this.name ?? String.Empty;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Name), "Name must not be null or empty or consist only of white spaces.");
                }

                if (this.name != value)
                {
                    this.name = value;
                    base.RaisePropertyChanged(nameof(this.Name));
                }
            }
        }

        [XmlElement("text")]
        public String Text
        {
            get
            {
                return this.text ?? String.Empty;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Text), "Text must not be null or empty or consist only of white spaces.");
                }

                if (this.text != value)
                {
                    this.text = value;
                    base.RaisePropertyChanged(nameof(this.Text));
                }
            }
        }

        [XmlElement("note")]
        public String Note
        {
            get
            {
                return this.note ?? String.Empty;
            }
            set
            {
                value = value ?? String.Empty;

                if (this.note != value)
                {
                    this.note = value;
                    base.RaisePropertyChanged(nameof(this.Note));
                }
            }
        }

        [XmlAttribute("guesses")]
        public Double Guesses
        {
            get
            {
                return this.guesses;
            }
            set
            {
                if (value <= 0d)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Guesses), "Number of guesses per second must be greater than zero.");
                }

                if (this.guesses != value)
                {
                    this.guesses = value;
                    base.RaisePropertyChanged(nameof(this.Guesses));
                }
            }
        }
    }
}
