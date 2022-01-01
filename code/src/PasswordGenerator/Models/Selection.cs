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
using System.Text;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Models
{
    [XmlType("selection")]
    [DebuggerDisplay("Enabled = {this.Enabled}, Values = {this.Values}")]
    public class Selection
    {
        private Boolean enabled = false;
        private String values = String.Empty;

        public Selection()
            : this(null)
        {
        }

        public Selection(String values)
        {
            this.Enabled = !String.IsNullOrEmpty(values);
            this.Values = values;
        }

        public Selection(String values, Boolean enabled)
            : this(values)
        {
            this.enabled = enabled;
        }

        [XmlIgnore]
        public Boolean IsValid
        {
            get
            {
                return this.Enabled && !String.IsNullOrWhiteSpace(this.Values);
            }
        }

        [XmlAttribute("enabled")]
        public Boolean Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;
                }
            }
        }

        [XmlAttribute("values")]
        public String Values
        {
            get
            {
                return this.values;
            }
            set
            {
                if (this.values != value)
                {
                    this.values = value?.Trim() ?? String.Empty;
                }
            }
        }

        public void CollectValues(StringBuilder builder)
        {
            if (builder is null || !this.IsValid)
            {
                return;
            }

            builder.Append(this.Values);
        }
    }
}
