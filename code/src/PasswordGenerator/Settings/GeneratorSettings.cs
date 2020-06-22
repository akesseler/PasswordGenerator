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

using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.PasswordGenerator.Models;
using System;
using System.Text;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    public class GeneratorSettings : NotifySettings, IGeneratorSettings
    {
        private const String defaultUpperData = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const String defaultLowerData = "abcdefghijklmnopqrstuvwxyz";
        private const String defaultDigitData = "0123456789";
        private const String defaultExtraData = "@#!\"$%&/=?'*+~,;.:-_";
        private const String defaultOtherData = "|<({[]})>\\";
        private const Boolean defaultUpperCheck = true;
        private const Boolean defaultLowerCheck = true;
        private const Boolean defaultDigitCheck = true;
        private const Boolean defaultExtraCheck = true;
        private const Boolean defaultOtherCheck = false;

        private Selection uppers = null;
        private Selection lowers = null;
        private Selection digits = null;
        private Selection extras = null;
        private Selection others = null;

        public GeneratorSettings()
            : base()
        {
            this.Uppers = new Selection(GeneratorSettings.defaultUpperData, GeneratorSettings.defaultUpperCheck);
            this.Lowers = new Selection(GeneratorSettings.defaultLowerData, GeneratorSettings.defaultLowerCheck);
            this.Digits = new Selection(GeneratorSettings.defaultDigitData, GeneratorSettings.defaultDigitCheck);
            this.Extras = new Selection(GeneratorSettings.defaultExtraData, GeneratorSettings.defaultExtraCheck);
            this.Others = new Selection(GeneratorSettings.defaultOtherData, GeneratorSettings.defaultOtherCheck);
        }

        [XmlIgnore]
        public Boolean IsValid
        {
            get
            {
                return
                    this.Uppers.IsValid ||
                    this.Lowers.IsValid ||
                    this.Digits.IsValid ||
                    this.Extras.IsValid ||
                    this.Others.IsValid;
            }
        }

        [XmlElement("uppers")]
        public Selection Uppers
        {
            get
            {
                return this.uppers;
            }
            set
            {
                if (value is null)
                {
                    value = new Selection();
                }

                if (this.uppers != value)
                {
                    this.uppers = value;
                    base.RaisePropertyChanged(nameof(this.Uppers));
                }
            }
        }

        [XmlElement("lowers")]
        public Selection Lowers
        {
            get
            {
                return this.lowers;
            }
            set
            {
                if (value is null)
                {
                    value = new Selection();
                }

                if (this.lowers != value)
                {
                    this.lowers = value;
                    base.RaisePropertyChanged(nameof(this.Lowers));
                }
            }
        }

        [XmlElement("digits")]
        public Selection Digits
        {
            get
            {
                return this.digits;
            }
            set
            {
                if (value is null)
                {
                    value = new Selection();
                }

                if (this.digits != value)
                {
                    this.digits = value;
                    base.RaisePropertyChanged(nameof(this.Digits));
                }
            }
        }

        [XmlElement("extras")]
        public Selection Extras
        {
            get
            {
                return this.extras;
            }
            set
            {
                if (value is null)
                {
                    value = new Selection();
                }

                if (this.extras != value)
                {
                    this.extras = value;
                    base.RaisePropertyChanged(nameof(this.Extras));
                }
            }
        }

        [XmlElement("others")]
        public Selection Others
        {
            get
            {
                return this.others;
            }
            set
            {
                if (value is null)
                {
                    value = new Selection();
                }

                if (this.others != value)
                {
                    this.others = value;
                    base.RaisePropertyChanged(nameof(this.Others));
                }
            }
        }

        public String Subset(String property)
        {
            if (String.Equals(property, nameof(this.Uppers), StringComparison.InvariantCultureIgnoreCase))
            {
                return GeneratorSettings.defaultUpperData;
            }
            else if (String.Equals(property, nameof(this.Lowers), StringComparison.InvariantCultureIgnoreCase))
            {
                return GeneratorSettings.defaultLowerData;
            }
            else if (String.Equals(property, nameof(this.Digits), StringComparison.InvariantCultureIgnoreCase))
            {
                return GeneratorSettings.defaultDigitData;
            }
            else if (String.Equals(property, nameof(this.Extras), StringComparison.InvariantCultureIgnoreCase))
            {
                return GeneratorSettings.defaultExtraData;
            }
            else if (String.Equals(property, nameof(this.Others), StringComparison.InvariantCultureIgnoreCase))
            {
                return GeneratorSettings.defaultOtherData;
            }
            else
            {
                return String.Empty;
            }
        }

        public String CollectSource()
        {
            StringBuilder builder = new StringBuilder(256);

            this.Uppers.CollectValues(builder);
            this.Lowers.CollectValues(builder);
            this.Digits.CollectValues(builder);
            this.Extras.CollectValues(builder);
            this.Others.CollectValues(builder);

            return builder.ToString();
        }

        public void Reset(String property)
        {
            if (String.Equals(property, nameof(this.Uppers), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Uppers = new Selection(GeneratorSettings.defaultUpperData, GeneratorSettings.defaultUpperCheck);
            }
            else if (String.Equals(property, nameof(this.Lowers), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Lowers = new Selection(GeneratorSettings.defaultLowerData, GeneratorSettings.defaultLowerCheck);
            }
            else if (String.Equals(property, nameof(this.Digits), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Digits = new Selection(GeneratorSettings.defaultDigitData, GeneratorSettings.defaultDigitCheck);
            }
            else if (String.Equals(property, nameof(this.Extras), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Extras = new Selection(GeneratorSettings.defaultExtraData, GeneratorSettings.defaultExtraCheck);
            }
            else if (String.Equals(property, nameof(this.Others), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Others = new Selection(GeneratorSettings.defaultOtherData, GeneratorSettings.defaultOtherCheck);
            }
        }
    }
}
