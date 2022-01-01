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

using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    public class ExtendedSettings : NotifySettings, IExtendedSettings
    {
        private const Int32 defaultLength = 8;
        private const Int32 defaultAmount = 1;
        private const Boolean defaultDelete = false;

        private Int32 length = -1;
        private Int32 amount = -1;
        private Boolean delete = false;

        public ExtendedSettings()
            : base()
        {
            this.Length = ExtendedSettings.defaultLength;
            this.Amount = ExtendedSettings.defaultAmount;
            this.Delete = ExtendedSettings.defaultDelete;
        }

        [XmlAttribute("length")]
        public Int32 Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Length), "Length must be greater than zero.");
                }

                if (this.length != value)
                {
                    this.length = value;
                    base.RaisePropertyChanged(nameof(this.Length));
                }
            }
        }

        [XmlAttribute("amount")]
        public Int32 Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Amount), "Amount must be greater than zero.");
                }

                if (this.amount != value)
                {
                    this.amount = value;
                    base.RaisePropertyChanged(nameof(this.Amount));
                }
            }
        }

        [XmlAttribute("delete")]
        public Boolean Delete
        {
            get
            {
                return this.delete;
            }
            set
            {
                if (this.delete != value)
                {
                    this.delete = value;
                    base.RaisePropertyChanged(nameof(this.Delete));
                }
            }
        }

        public void Reset(String property)
        {
            if (String.Equals(property, nameof(this.Length), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Length = ExtendedSettings.defaultLength;
            }
            else if (String.Equals(property, nameof(this.Amount), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Amount = ExtendedSettings.defaultAmount;
            }
            else if (String.Equals(property, nameof(this.Delete), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Delete = ExtendedSettings.defaultDelete;
            }
        }
    }
}
