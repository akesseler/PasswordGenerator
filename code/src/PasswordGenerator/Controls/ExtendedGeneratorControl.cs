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

using Plexdata.PasswordGenerator.Events;
using Plexdata.PasswordGenerator.Factories;
using Plexdata.PasswordGenerator.Helpers;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class ExtendedGeneratorControl : UserControl, IGeneratorControl, IGeneratorControl<IExtendedSettings>, IStatusRequester, IResultWriter
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        #endregion

        #region Private Fields

        private IExtendedSettings controlSettings = null;
        private readonly IEntropyCalculator entropyCalculator = null;
        private readonly IStrengthCalculator strengthCalculator = null;

        #endregion

        #region Construction

        public ExtendedGeneratorControl()
            : base()
        {
            this.InitializeComponent();
            this.lstPasswords.Items.Clear();

            this.entropyCalculator = CalculatorFactory.Create<IEntropyCalculator>();
            this.strengthCalculator = CalculatorFactory.Create<IStrengthCalculator>();

            StandardContextMenu contextMenu = StandardContextMenu.Create(this.OnContextMenuItemClick);
            contextMenu.Opening += this.OnContextMenuOpening;

            this.numLength.ContextMenuStrip = contextMenu;
            this.numAmount.ContextMenuStrip = contextMenu;
            this.lstPasswords.ContextMenuStrip = contextMenu;
        }

        #endregion

        #region Public Properties

        public Boolean HasResult
        {
            get
            {
                return this.lstPasswords.Items.Count > 0;
            }
        }

        #endregion

        #region Public Methods

        public void Generate(IGeneratorSettings generatorSettings)
        {
            if (generatorSettings is null) { throw new ArgumentNullException(nameof(generatorSettings)); }

            if (!generatorSettings.IsValid)
            {
                MessageBox.Show(base.ParentForm,
                    "Provide at least one of the character pools.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.chbDelete.Checked)
            {
                this.lstPasswords.Items.Clear();
            }

            IExtendedGenerator generator = GeneratorFactory.Create<IExtendedGenerator>();

            this.lstPasswords.Items.AddRange(generator.Generate(this.controlSettings, generatorSettings).ToArray());
        }

        public void WriteResult(Stream stream, Encoding encoding)
        {
            if (stream == null || !stream.CanWrite || encoding == null)
            {
                return;
            }

            using (TextWriter writer = new StreamWriter(stream, encoding))
            {
                foreach (Object password in this.lstPasswords.Items)
                {
                    writer.WriteLine(password.ToString());
                }
            }
        }

        public void Attach(IExtendedSettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            this.numLength.Number = this.controlSettings.Length;
            this.numAmount.Number = this.controlSettings.Amount;
            this.chbDelete.Checked = this.controlSettings.Delete;

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
            if (sender is IExtendedSettings settings)
            {
                if (args.PropertyName.Equals(nameof(settings.Length)))
                {
                    this.numLength.Number = settings.Length;
                }
                else if (args.PropertyName.Equals(nameof(settings.Amount)))
                {
                    this.numAmount.Number = settings.Amount;
                }
                else if (args.PropertyName.Equals(nameof(settings.Delete)))
                {
                    this.chbDelete.Checked = settings.Delete;
                }
            }
        }

        private void OnEditLengthChanged(Object sender, EventArgs args)
        {
            this.controlSettings.Length = this.numLength.Number;
        }

        private void OnEditAmountChanged(Object sender, EventArgs args)
        {
            this.controlSettings.Amount = this.numAmount.Number;
        }

        private void OnEditDeleteChanged(Object sender, EventArgs args)
        {
            this.controlSettings.Delete = this.chbDelete.Checked;
        }

        private void OnContextMenuOpening(Object sender, CancelEventArgs args)
        {
            try
            {
                StandardContextMenu source = StandardContextMenu.MenuFromSender(sender, out Control control);

                if (source == null) { return; }

                source.DisableAll();

                if (control == this.numLength)
                {
                    source.Clear.Enabled = true;
                }
                else if (control == this.numAmount)
                {
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
                    if (parent.SourceControl == this.numLength)
                    {
                        Clipboard.SetText(this.numLength.Text);
                    }
                    else if (parent.SourceControl == this.numAmount)
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
                    if (parent.SourceControl == this.numLength)
                    {
                        this.controlSettings.Reset(nameof(this.controlSettings.Length));
                    }
                    else if (parent.SourceControl == this.numAmount)
                    {
                        this.controlSettings.Reset(nameof(this.controlSettings.Amount));
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
                    String value = "";

                    switch (this.strengthCalculator.Calculate(entropy))
                    {
                        case Strength.VeryWeak:
                            value = $"Very Weak ({Math.Truncate(entropy):N0} Bits)";
                            break;
                        case Strength.Weak:
                            value = $"Weak ({Math.Truncate(entropy):N0} Bits)";
                            break;
                        case Strength.Reasonable:
                            value = $"Reasonable ({Math.Truncate(entropy):N0} Bits)";
                            break;
                        case Strength.Strong:
                            value = $"Strong ({Math.Truncate(entropy):N0} Bits)";
                            break;
                        case Strength.VeryStrong:
                            value = $"Very Strong ({Math.Truncate(entropy):N0} Bits)";
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

        #endregion

        #region Private Methods

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
