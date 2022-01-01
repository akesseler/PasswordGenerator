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

using Plexdata.PasswordGenerator.Events;
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Factories;
using Plexdata.PasswordGenerator.Helpers;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class ExchangeGeneratorControl : UserControl, IGeneratorControl, IGeneratorControl<IExchangeSettings>, IStatusRequester, ISettingsRequester, IResultWriter
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        public event ShowSettingsEventHandler ShowSettings;

        #endregion

        #region Private Fields

        private IExchangeSettings controlSettings = null;

        #endregion

        #region Construction

        public ExchangeGeneratorControl()
            : base()
        {
            this.InitializeComponent();

            StandardContextMenu contextMenu = StandardContextMenu.Create(this.OnContextMenuItemClick);
            contextMenu.Opening += this.OnContextMenuOpening;

            this.txtSource.ContextMenu = null;
            this.txtSource.ContextMenuStrip = contextMenu;
            this.txtSource.SetWatermark(true);

            this.txtResult.ContextMenu = null;
            this.txtResult.ContextMenuStrip = contextMenu;
            this.txtResult.SetWatermark(true);
        }

        #endregion

        #region Public Properties

        public Boolean HasResult
        {
            get
            {
                return this.txtResult.Text.Length > 0;
            }
        }

        #endregion

        #region Public Methods

        public void Generate(IGeneratorSettings generatorSettings)
        {
            if (generatorSettings is null) { throw new ArgumentNullException(nameof(generatorSettings)); }

            String source = this.txtSource.Text;

            if (String.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show(base.ParentForm,
                    "Provide a source password to be processed.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IExchangeGenerator generator = GeneratorFactory.Create<IExchangeGenerator>();

            this.txtResult.Text = generator.Generate(this.controlSettings, this.txtSource.Text);
        }

        public void WriteResult(Stream stream, Encoding encoding)
        {
            if (stream == null || !stream.CanWrite || encoding == null)
            {
                return;
            }

            using (TextWriter writer = new StreamWriter(stream, encoding))
            {
                writer.WriteLine(this.txtResult.Text);
            }
        }

        public void Attach(IExchangeSettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

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

        protected void RaiseShowSettings()
        {
            this.ShowSettings?.Invoke(this, new ShowSettingsEventArgs(ShowSettingsEventArgs.ExchangeSettings));
        }

        #endregion

        #region Private Methods

        private void OnControlSettingsPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            if (sender is IExchangeSettings settings)
            {
            }
        }

        private void OnSettingsLinkClicked(Object sender, LinkLabelLinkClickedEventArgs args)
        {
            this.RaiseShowSettings();
        }

        private void OnContextMenuOpening(Object sender, CancelEventArgs args)
        {
            try
            {
                StandardContextMenu source = StandardContextMenu.MenuFromSender(sender, out Control control);

                if (source == null) { return; }

                source.DisableAll();

                if (control == this.txtSource)
                {
                    source.Copy.Enabled = this.txtSource.Text.Length > 0;
                    source.Cut.Enabled = this.txtSource.Text.Length > 0;
                    source.Paste.Enabled = Clipboard.ContainsText();
                    source.Clear.Enabled = this.txtSource.Text.Length > 0;
                }
                else if (control == this.txtResult)
                {
                    source.Copy.Enabled = this.txtResult.Text.Length > 0;
                    source.Clear.Enabled = this.txtResult.Text.Length > 0;
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
                    if (parent.SourceControl == this.txtSource)
                    {
                        Clipboard.SetText(this.txtSource.Text);
                    }
                    else if (parent.SourceControl == this.txtResult)
                    {
                        Clipboard.SetText(this.txtResult.Text);
                    }
                }
                else if (parent.IsCut(source))
                {
                    if (parent.SourceControl == this.txtSource)
                    {
                        Clipboard.SetText(this.txtSource.Text);
                        this.txtSource.Text = String.Empty;
                        this.txtResult.Text = String.Empty;
                    }
                }
                else if (parent.IsPaste(source))
                {
                    if (parent.SourceControl == this.txtSource && Clipboard.ContainsText())
                    {
                        this.txtSource.Text = Clipboard.GetText().ClearLineEndings();
                        this.txtResult.Text = String.Empty;
                    }
                }
                else if (parent.IsClear(source))
                {
                    if (parent.SourceControl == this.txtSource)
                    {
                        this.txtSource.Text = String.Empty;
                        this.txtResult.Text = String.Empty;
                    }
                    else if (parent.SourceControl == this.txtResult)
                    {
                        this.txtResult.Text = String.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        #endregion
    }
}
