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
using Plexdata.PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    public class ExchangeSettings : NotifySettings, IExchangeSettings
    {
        private static Exchange[] DefaultValues = null;

        private Exchange[] values = null;

        static ExchangeSettings()
        {
            ExchangeSettings.DefaultValues = new Exchange[]
            {
                new Exchange("a", "@"),
                new Exchange("A", "4"),
                new Exchange("B", "8"),
                new Exchange("e", "3"),
                new Exchange("E", "3"),
                new Exchange("g", "9"),
                new Exchange("i", "1"),
                new Exchange("I", "1"),
                new Exchange("o", "0"),
                new Exchange("O", "0"),
                new Exchange("s", "5"),
                new Exchange("S", "$"),
                new Exchange(" ", "_"),
            };
        }

        public ExchangeSettings()
            : base()
        {
            this.Values = ExchangeSettings.DefaultValues;
        }

        [XmlArray("values")]
        public Exchange[] Values
        {
            get
            {
                return this.values;
            }
            set
            {
                if (value is null)
                {
                    value = new Exchange[0];
                }

                // Needed because of the serializer may overwrite it with any 
                // empty if nothing could be found in the configuration file.
                if (this.values != null && value.Length < 1)
                {
                    return;
                }

                if (this.values != value)
                {
                    this.values = value;
                    base.RaisePropertyChanged(nameof(this.Values));
                }
            }
        }

        public IEnumerable<(Char From, Char Into)> CollectValues()
        {
            foreach (Exchange value in this.Values)
            {
                if (value.IsValid)
                {
                    yield return (From: value.Source[0], Into: value.Target[0]);
                }
            }
        }

        public void Reset(String property)
        {
            if (String.Equals(property, nameof(this.Values), StringComparison.InvariantCultureIgnoreCase))
            {
                this.values = ExchangeSettings.DefaultValues;
                base.RaisePropertyChanged(nameof(this.Values));
            }
        }
    }
}
