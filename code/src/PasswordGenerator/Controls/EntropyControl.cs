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

using Plexdata.Utilities.Password.Defines;
using System;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class EntropyControl : UserControl
    {
        private Double entropy = 0d;
        private Strength strength = Strength.Unknown;
        private String summary = null;

        public EntropyControl()
        {
            this.InitializeComponent();

            this.Entropy = 0d;
            this.Strength = Strength.Unknown;
            this.Summary = String.Empty;
        }

        public Double Entropy
        {
            get
            {
                return this.entropy;
            }
            set
            {
                if (value < 0d)
                {
                    value = 0d;
                }

                this.entropy = value;
                this.txtEntropy.Text = $"{Math.Truncate(this.entropy).ToString("N0")} Bits";
            }
        }

        public Double Percent
        {
            get
            {
                return this.prgStrength.Percent;
            }
            set
            {
                this.prgStrength.Percent = value;
            }
        }

        public Strength Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;

                switch (strength)
                {
                    case Strength.VeryWeak:
                        this.prgStrength.Value = 20;
                        this.prgStrength.Label = "Very Weak";
                        break;
                    case Strength.Weak:
                        this.prgStrength.Value = 40;
                        this.prgStrength.Label = "Weak";
                        break;
                    case Strength.Reasonable:
                        this.prgStrength.Value = 60;
                        this.prgStrength.Label = "Reasonable";
                        break;
                    case Strength.Strong:
                        this.prgStrength.Value = 80;
                        this.prgStrength.Label = "Strong";
                        break;
                    case Strength.VeryStrong:
                        this.prgStrength.Value = 100;
                        this.prgStrength.Label = "Very Strong";
                        break;
                    default:
                        this.prgStrength.Value = 0;
                        this.prgStrength.Label = "Unknown";
                        break;
                }
            }
        }

        public String Summary
        {
            get
            {
                return this.summary;
            }
            set
            {
                value = value ?? String.Empty;

                this.txtSummary.Text = value;
            }
        }
    }
}
