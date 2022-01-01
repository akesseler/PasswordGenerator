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

using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class ExtendedSettingsControl : UserControl, ISettingsControl<IGeneratorSettings>
    {
        private IGeneratorSettings controlSettings;

        public ExtendedSettingsControl()
        {
            this.InitializeComponent();

            this.txtUppers.SetWatermark(true);
            this.txtLowers.SetWatermark(true);
            this.txtDigits.SetWatermark(true);
            this.txtExtras.SetWatermark(true);
            this.txtOthers.SetWatermark(true);
        }

        public void Attach(IGeneratorSettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            this.chbUppers.Checked = this.controlSettings.Uppers.Enabled;
            this.txtUppers.Text = this.controlSettings.Uppers.Values;
            this.chbLowers.Checked = this.controlSettings.Lowers.Enabled;
            this.txtLowers.Text = this.controlSettings.Lowers.Values;
            this.chbDigits.Checked = this.controlSettings.Digits.Enabled;
            this.txtDigits.Text = this.controlSettings.Digits.Values;
            this.chbExtras.Checked = this.controlSettings.Extras.Enabled;
            this.txtExtras.Text = this.controlSettings.Extras.Values;
            this.chbOthers.Checked = this.controlSettings.Others.Enabled;
            this.txtOthers.Text = this.controlSettings.Others.Values;

            this.controlSettings.PropertyChanged += this.OnSettingsPropertyChanged;
        }

        public void Apply()
        {
            if (this.controlSettings != null)
            {
                this.controlSettings.Uppers.Enabled = this.chbUppers.Checked;
                this.controlSettings.Uppers.Values = this.txtUppers.Text;
                this.controlSettings.Lowers.Enabled = this.chbLowers.Checked;
                this.controlSettings.Lowers.Values = this.txtLowers.Text;
                this.controlSettings.Digits.Enabled = this.chbDigits.Checked;
                this.controlSettings.Digits.Values = this.txtDigits.Text;
                this.controlSettings.Extras.Enabled = this.chbExtras.Checked;
                this.controlSettings.Extras.Values = this.txtExtras.Text;
                this.controlSettings.Others.Enabled = this.chbOthers.Checked;
                this.controlSettings.Others.Values = this.txtOthers.Text;
            }
        }

        public void Detach()
        {
            if (this.controlSettings != null)
            {
                this.controlSettings.PropertyChanged -= this.OnSettingsPropertyChanged;
                this.controlSettings = null;
            }
        }

        private void OnSettingsPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            if (String.Equals(args.PropertyName, nameof(this.controlSettings.Uppers), StringComparison.InvariantCultureIgnoreCase))
            {
                this.chbUppers.Checked = this.controlSettings.Uppers.Enabled;
                this.txtUppers.Text = this.controlSettings.Uppers.Values;
            }
            else if (String.Equals(args.PropertyName, nameof(this.controlSettings.Lowers), StringComparison.InvariantCultureIgnoreCase))
            {
                this.chbLowers.Checked = this.controlSettings.Lowers.Enabled;
                this.txtLowers.Text = this.controlSettings.Lowers.Values;
            }
            else if (String.Equals(args.PropertyName, nameof(this.controlSettings.Digits), StringComparison.InvariantCultureIgnoreCase))
            {
                this.chbDigits.Checked = this.controlSettings.Digits.Enabled;
                this.txtDigits.Text = this.controlSettings.Digits.Values;
            }
            else if (String.Equals(args.PropertyName, nameof(this.controlSettings.Extras), StringComparison.InvariantCultureIgnoreCase))
            {
                this.chbExtras.Checked = this.controlSettings.Extras.Enabled;
                this.txtExtras.Text = this.controlSettings.Extras.Values;
            }
            else if (String.Equals(args.PropertyName, nameof(this.controlSettings.Others), StringComparison.InvariantCultureIgnoreCase))
            {
                this.chbOthers.Checked = this.controlSettings.Others.Enabled;
                this.txtOthers.Text = this.controlSettings.Others.Values;
            }
        }

        private void OnResetButtonClick(Object sender, EventArgs args)
        {
            if (sender == this.btnUppers)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Uppers));
            }
            else if (sender == this.btnLowers)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Lowers));
            }
            else if (sender == this.btnDigits)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Digits));
            }
            else if (sender == this.btnExtras)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Extras));
            }
            else if (sender == this.btnOthers)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Others));
            }
        }
    }
}
