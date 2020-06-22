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

using Plexdata.PasswordGenerator.Attributes;
using Plexdata.PasswordGenerator.Enumerations;
using Plexdata.PasswordGenerator.Events;
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Factories;
using Plexdata.PasswordGenerator.Helpers;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    // TODO: Support custom password phrase for WEP key generation...
    public partial class CommonGeneratorControl : UserControl, IGeneratorControl, IGeneratorControl<ICommonSettings>, IStatusRequester
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        #endregion

        #region Private Classes

        private class CommonSubset
        {
            public CommonSubset(CommonType type, AnnotationAttribute source)
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }

                this.Display = source.Display;
                this.Remarks = source.Remarks;
                this.Type = type;
                this.IsLengthEnabled = this.GetLengthEnabled(type);
                this.LengthMinimum = this.GetLengthMinimum(type);
                this.LengthMaximum = this.GetLengthMaximum(type);
                this.LengthValue = this.GetLengthValue(type);
                this.IsPoolsEnabled = this.GetPoolsEnabled(type);
            }

            public String Display { get; private set; }

            public String Remarks { get; private set; }

            public CommonType Type { get; private set; }

            public Boolean IsLengthEnabled { get; private set; }

            public Int32 LengthMinimum { get; private set; }

            public Int32 LengthMaximum { get; private set; }

            public Int32 LengthValue { get; set; }

            public Boolean IsPoolsEnabled { get; private set; }

            private Boolean GetLengthEnabled(CommonType value)
            {
                switch (value)
                {
                    case CommonType.Nothing:
                    case CommonType.InternetPassword1:
                    case CommonType.InternetPassword2:
                    case CommonType.InternetPassword3:
                    case CommonType.PasswordManager1:
                    case CommonType.PasswordManager2:
                    case CommonType.PasswordManager3:
                    case CommonType.WepKey64Bit:
                    case CommonType.WepKey128Bit:
                    case CommonType.WepKey152Bit:
                    case CommonType.WepKey256Bit:
                    case CommonType.WpaKey: // No rules found
                        return false;
                    case CommonType.Wpa2Key:
                        return true;
                    default:
                        throw new NotSupportedException($"Password type of \"{value}\" is not yet supported.");
                }
            }

            private Int32 GetLengthMinimum(CommonType value)
            {
                switch (value)
                {
                    case CommonType.Nothing:
                        return 0;
                    case CommonType.InternetPassword1:
                        return 8;
                    case CommonType.InternetPassword2:
                        return 10;
                    case CommonType.InternetPassword3:
                        return 14;
                    case CommonType.PasswordManager1:
                        return 16;
                    case CommonType.PasswordManager2:
                        return 32;
                    case CommonType.PasswordManager3:
                        return 64;
                    case CommonType.WepKey64Bit:
                        return 10;
                    case CommonType.WepKey128Bit:
                        return 26;
                    case CommonType.WepKey152Bit:
                        return 32;
                    case CommonType.WepKey256Bit:
                        return 58;
                    case CommonType.WpaKey: // No rules found
                        return 0;
                    case CommonType.Wpa2Key:
                        return 8;
                    default:
                        throw new NotSupportedException($"Password type of \"{value}\" is not yet supported.");
                }
            }

            private Int32 GetLengthMaximum(CommonType value)
            {
                switch (value)
                {
                    case CommonType.Nothing:
                    case CommonType.InternetPassword1:
                    case CommonType.InternetPassword2:
                    case CommonType.InternetPassword3:
                    case CommonType.PasswordManager1:
                    case CommonType.PasswordManager2:
                    case CommonType.PasswordManager3:
                    case CommonType.WepKey64Bit:
                    case CommonType.WepKey128Bit:
                    case CommonType.WepKey152Bit:
                    case CommonType.WepKey256Bit:
                    case CommonType.WpaKey: // No rules found
                        return this.GetLengthMinimum(value);
                    case CommonType.Wpa2Key:
                        return 63;
                    default:
                        throw new NotSupportedException($"Password type of \"{value}\" is not yet supported.");
                }
            }

            private Int32 GetLengthValue(CommonType value)
            {
                switch (value)
                {
                    case CommonType.Nothing:
                    case CommonType.InternetPassword1:
                    case CommonType.InternetPassword2:
                    case CommonType.InternetPassword3:
                    case CommonType.PasswordManager1:
                    case CommonType.PasswordManager2:
                    case CommonType.PasswordManager3:
                    case CommonType.WepKey64Bit:
                    case CommonType.WepKey128Bit:
                    case CommonType.WepKey152Bit:
                    case CommonType.WepKey256Bit:
                    case CommonType.WpaKey: // No rules found
                        return this.GetLengthMinimum(value);
                    case CommonType.Wpa2Key:
                        return 20; // Government recommendation
                    default:
                        throw new NotSupportedException($"Password type of \"{value}\" is not yet supported.");
                }
            }

            private Boolean GetPoolsEnabled(CommonType value)
            {
                switch (value)
                {
                    case CommonType.Nothing:
                    case CommonType.InternetPassword1:
                    case CommonType.InternetPassword2:
                    case CommonType.InternetPassword3:
                        return false;
                    case CommonType.PasswordManager1:
                    case CommonType.PasswordManager2:
                    case CommonType.PasswordManager3:
                    case CommonType.WepKey64Bit:
                    case CommonType.WepKey128Bit:
                    case CommonType.WepKey152Bit:
                    case CommonType.WepKey256Bit:
                        return true;
                    case CommonType.WpaKey: // No rules found
                        return false;
                    case CommonType.Wpa2Key:
                        return true;
                    default:
                        throw new NotSupportedException($"Password type of \"{value}\" is not yet supported.");
                }
            }
        }

        #endregion

        #region Private Fields

        private ICommonSettings controlSettings = null;
        private readonly IEntropyCalculator entropyCalculator = null;
        private readonly IStrengthCalculator strengthCalculator = null;

        #endregion

        #region Construction

        public CommonGeneratorControl()
            : base()
        {
            this.InitializeComponent();
            this.lstPasswords.Items.Clear();

            this.entropyCalculator = CalculatorFactory.Create<IEntropyCalculator>();
            this.strengthCalculator = CalculatorFactory.Create<IStrengthCalculator>();

            StandardContextMenu contextMenu = StandardContextMenu.Create(this.OnContextMenuItemClick);
            contextMenu.Opening += this.OnContextMenuOpening;

            this.numLength.ContextMenuStrip = StandardContextMenu.Empty;
            this.numAmount.ContextMenuStrip = contextMenu;
            this.lstPasswords.ContextMenuStrip = contextMenu;
        }

        #endregion

        #region Public Methods

        public void Generate(IGeneratorSettings generatorSettings)
        {
            if (generatorSettings is null) { throw new ArgumentNullException(nameof(generatorSettings)); }

            if (this.cmbTypes.SelectedValue is CommonSubset selected)
            {
                if (selected.Type == CommonType.Nothing)
                {
                    MessageBox.Show(
                        "Please choose one of the password types.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (selected.IsPoolsEnabled && !this.chkUppers.Checked && !this.chkLowers.Checked && !this.chkDigits.Checked && !this.chkExtras.Checked)
                {
                    MessageBox.Show(
                        "Please choose at least one of the character pools.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.chbDelete.Checked)
                {
                    this.lstPasswords.Items.Clear();
                }

                ICommonGenerator generator = GeneratorFactory.Create<ICommonGenerator>();

                this.lstPasswords.Items.AddRange(generator.Generate(this.controlSettings, generatorSettings).ToArray());
            }
        }

        public void Attach(ICommonSettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            if (this.cmbTypes.DataSource is IEnumerable<CommonSubset> items)
            {
                foreach (CommonSubset item in items)
                {
                    if (item.Type == this.controlSettings.Type)
                    {
                        this.cmbTypes.SelectedItem = item;
                        break;
                    }
                }
            }

            this.numAmount.Number = this.controlSettings.Amount;
            this.chkUppers.Checked = this.controlSettings.IsUppers;
            this.chkLowers.Checked = this.controlSettings.IsLowers;
            this.chkDigits.Checked = this.controlSettings.IsDigits;
            this.chkExtras.Checked = this.controlSettings.IsExtras;

            this.controlSettings.PropertyChanged += this.OnControlSettingsPropertyChanged;
        }

        public void Detach()
        {
            if (this.controlSettings != null)
            {
                this.controlSettings.PropertyChanged -= this.OnControlSettingsPropertyChanged;
                this.controlSettings = null;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            this.cmbTypes.DisplayMember = nameof(CommonSubset.Display);
            this.cmbTypes.DataSource = this.GetDataSource();
        }

        protected void RaiseUpdateStatus()
        {
            this.RaiseUpdateStatus(null, null);
        }

        protected void RaiseUpdateStatus(String value)
        {
            this.RaiseUpdateStatus(null, value);
        }

        protected void RaiseUpdateStatus(String label, String value)
        {
            this.UpdateStatus?.Invoke(this, new UpdateStatusEventArgs(label, value));
        }

        #endregion

        #region Private Events

        private void OnControlSettingsPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            if (sender is ICommonSettings settings)
            {
            }
        }

        private void OnTypesSelectedValueChanged(Object sender, EventArgs args)
        {
            if (this.cmbTypes.SelectedValue is CommonSubset selected)
            {
                this.txtRemarks.Text = selected.Remarks;

                this.numLength.Minimum = selected.LengthMinimum;
                this.numLength.Maximum = selected.LengthMaximum;
                this.numLength.Number = selected.LengthMinimum;
                this.numLength.Number = selected.LengthValue;
                this.numLength.Enabled = selected.IsLengthEnabled;

                this.chkUppers.Enabled = selected.IsPoolsEnabled;
                this.chkLowers.Enabled = selected.IsPoolsEnabled;
                this.chkDigits.Enabled = selected.IsPoolsEnabled;
                this.chkExtras.Enabled = selected.IsPoolsEnabled;

                if (this.controlSettings != null)
                {
                    this.controlSettings.Type = selected.Type;
                }
            }
        }

        private void OnNumberValueChanged(Object sender, EventArgs args)
        {
            if (this.controlSettings == null) { return; }

            if (sender == this.numLength)
            {
                this.controlSettings.Length = this.numLength.Number;
            }
            else if (sender == this.numAmount)
            {
                this.controlSettings.Amount = this.numAmount.Number;
            }
        }

        private void OnPoolsCheckedChanged(Object sender, EventArgs args)
        {
            if (this.controlSettings == null) { return; }

            if (sender == this.chkUppers)
            {
                this.controlSettings.IsUppers = this.chkUppers.Checked;
            }
            else if (sender == this.chkLowers)
            {
                this.controlSettings.IsLowers = this.chkLowers.Checked;
            }
            else if (sender == this.chkDigits)
            {
                this.controlSettings.IsDigits = this.chkDigits.Checked;
            }
            else if (sender == this.chkExtras)
            {
                this.controlSettings.IsExtras = this.chkExtras.Checked;
            }
        }

        private void OnPasswordsSelectedIndexChanged(Object sender, EventArgs args)
        {
            if (this.lstPasswords.SelectedIndices.Count == 1)
            {
                try
                {
                    String password = this.lstPasswords.Items[this.lstPasswords.SelectedIndices[0]] as String;

                    if (password.Contains('\t'))
                    {
                        password = password.Split('\t').First();
                    }

                    Double entropy = this.entropyCalculator.Calculate(password);
                    Strength strength = this.strengthCalculator.Calculate(entropy);

                    String label = "Estimated Password Strength:";
                    String value = String.Empty;

                    switch (this.strengthCalculator.Calculate(entropy))
                    {
                        case Strength.VeryWeak:
                            value = $"Very Weak ({Math.Truncate(entropy).ToString("N0")} Bits)";
                            break;
                        case Strength.Weak:
                            value = $"Weak ({Math.Truncate(entropy).ToString("N0")} Bits)";
                            break;
                        case Strength.Reasonable:
                            value = $"Reasonable ({Math.Truncate(entropy).ToString("N0")} Bits)";
                            break;
                        case Strength.Strong:
                            value = $"Strong ({Math.Truncate(entropy).ToString("N0")} Bits)";
                            break;
                        case Strength.VeryStrong:
                            value = $"Very Strong ({Math.Truncate(entropy).ToString("N0")} Bits)";
                            break;
                        default:
                            return;
                    }

                    this.RaiseUpdateStatus(label, value);
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception);
                }
            }
            else
            {
                this.RaiseUpdateStatus();
            }
        }

        private void OnContextMenuOpening(Object sender, CancelEventArgs args)
        {
            try
            {
                StandardContextMenu source = StandardContextMenu.MenuFromSender(sender, out Control control);

                if (source == null) { return; }

                source.DisableAll();

                if (control == this.numAmount)
                {
                    source.Copy.Enabled = true;
                    source.Clear.Enabled = true;
                }
                else if (control == this.lstPasswords)
                {

                    source.Copy.Enabled = this.lstPasswords.SelectedIndices.Count > 0;
                    source.Cut.Enabled = this.lstPasswords.SelectedIndices.Count > 0;
                    source.Clear.Enabled = this.lstPasswords.Items.Count > 0;
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private void OnContextMenuItemClick(Object sender, EventArgs args)
        {
            try
            {
                ToolStripItem source = StandardContextMenu.ItemFromSender(sender, out StandardContextMenu parent);

                if (source == null) { return; }

                if (parent.IsCopy(source))
                {
                    if (parent.SourceControl == this.numAmount)
                    {
                        Clipboard.SetText(this.numAmount.Text);
                    }
                    else if (parent.SourceControl == this.lstPasswords)
                    {
                        this.CopySelectedPasswords(false);
                    }
                }
                else if (parent.IsCut(source))
                {
                    if (parent.SourceControl == this.lstPasswords)
                    {
                        this.CopySelectedPasswords(true);
                    }
                }
                else if (parent.IsClear(source))
                {
                    if (parent.SourceControl == this.numAmount)
                    {
                        this.numAmount.Value = this.numAmount.Minimum;
                    }
                    else if (parent.SourceControl == this.lstPasswords)
                    {
                        this.lstPasswords.Items.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        #endregion

        #region Private Methods

        private IEnumerable<CommonSubset> GetDataSource()
        {
            List<CommonSubset> result = new List<CommonSubset>();

            foreach (CommonType current in Enum.GetValues(typeof(CommonType)))
            {
                AnnotationAttribute attribute = current.GetAnnotation<CommonType>();

                if (attribute == null || !attribute.Visible)
                {
                    continue;
                }

                result.Add(new CommonSubset(current, attribute));
            }

            return result;
        }

        private void CopySelectedPasswords(Boolean remove)
        {
            String clipboard = String.Empty;

            foreach (Object selected in this.lstPasswords.SelectedItems)
            {
                clipboard += String.Format("{0}{1}", selected.ToString(), Environment.NewLine);
            }

            Clipboard.SetText(clipboard.TrimEnd(Environment.NewLine.ToArray()));

            if (!remove) { return; }

            while (this.lstPasswords.SelectedItems.Count > 0)
            {
                this.lstPasswords.Items.Remove(this.lstPasswords.SelectedItems[0]);
            }
        }

        #endregion
    }
}
