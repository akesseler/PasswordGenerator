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

using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Models
{
    [XmlType("value")]
    [DebuggerDisplay("Source = {this.Source}, Target = {this.Target}")]
    public class Exchange
    {
        private const Char space = ' ';

        private String source;
        private String target;

        public Exchange()
            : this(String.Empty, String.Empty)
        {
        }

        public Exchange(String source, String target)
        {
            this.Source = source;
            this.Target = target;
        }

        [XmlIgnore]
        public Boolean IsValid
        {
            get
            {
                // Strings consisting of one single space character are actually permitted.
                if (!String.IsNullOrEmpty(this.Source) && this.Source[0] == Exchange.space)
                {
                    return !String.IsNullOrWhiteSpace(this.Target);
                }
                else
                {
                    return !String.IsNullOrWhiteSpace(this.Source) && !String.IsNullOrWhiteSpace(this.Target);
                }
            }
        }

        [XmlAttribute("source")]
        public String Source
        {
            get
            {
                return this.source;
            }
            set
            {
                if (this.source != value)
                {
                    value = value ?? String.Empty;

                    // Strings consisting of one single space character are actually permitted.
                    if (value.Length == 1 && value[0] == Exchange.space)
                    {
                        this.source = value;
                    }
                    else
                    {
                        this.source = value.Trim();
                    }
                }
            }
        }

        [XmlAttribute("target")]
        public String Target
        {
            get
            {
                return this.target;
            }
            set
            {
                if (this.target != value)
                {
                    this.target = value?.Trim() ?? String.Empty;
                }
            }
        }
    }
}
