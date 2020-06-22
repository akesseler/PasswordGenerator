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

using Plexdata.PasswordGenerator.Enumerations;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    public class CommonSettings : NotifySettings, ICommonSettings
    {
        private CommonType type;
        private Int32 amount;
        private Int32 length;
        private Boolean uppers;
        private Boolean lowers;
        private Boolean digits;
        private Boolean extras;

        public CommonSettings()
            : base()
        {
            this.Type = CommonType.InternetPassword2;
            this.Amount = 5;
            this.Length = 0;
            this.IsUppers = true;
            this.IsLowers = true;
            this.IsDigits = true;
            this.IsExtras = false;
        }

        [XmlAttribute("type")]
        public CommonType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    base.RaisePropertyChanged(nameof(this.Type));
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
                if (this.amount != value)
                {
                    this.amount = value;
                    base.RaisePropertyChanged(nameof(this.Amount));
                }
            }
        }

        [XmlIgnore]
        public Int32 Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (this.length != value)
                {
                    this.length = value;
                    base.RaisePropertyChanged(nameof(this.Length));
                }
            }
        }

        [XmlAttribute("uppers")]
        public Boolean IsUppers
        {
            get
            {
                return this.uppers;
            }
            set
            {
                if (this.uppers != value)
                {
                    this.uppers = value;
                    base.RaisePropertyChanged(nameof(this.IsUppers));
                }
            }
        }

        [XmlAttribute("lowers")]
        public Boolean IsLowers
        {
            get
            {
                return this.lowers;
            }
            set
            {
                if (this.lowers != value)
                {
                    this.lowers = value;
                    base.RaisePropertyChanged(nameof(this.IsLowers));
                }
            }
        }

        [XmlAttribute("digits")]
        public Boolean IsDigits
        {
            get
            {
                return this.digits;
            }
            set
            {
                if (this.digits != value)
                {
                    this.digits = value;
                    base.RaisePropertyChanged(nameof(this.IsDigits));
                }
            }
        }

        [XmlAttribute("extras")]
        public Boolean IsExtras
        {
            get
            {
                return this.extras;
            }
            set
            {
                if (this.extras != value)
                {
                    this.extras = value;
                    base.RaisePropertyChanged(nameof(this.IsExtras));
                }
            }
        }
    }
}
