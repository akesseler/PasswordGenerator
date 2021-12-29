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
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Helpers;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class PasswordInspectionControl : UserControl, IGeneratorControl, IStatusRequester
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        #endregion

        #region Private Fields

        private readonly IPasswordCounter passwordCounter = null;
        private readonly Color color1 = Color.FromArgb(unchecked((Int32)0xffFFCCCC));
        private readonly Color color2 = Color.FromArgb(unchecked((Int32)0xffCCFFCC));

        #endregion

        #region Construction

        public PasswordInspectionControl()
            : base()
        {
            this.InitializeComponent();

            this.passwordCounter = OnlineFactory.Create<IPasswordCounter>();

            StandardContextMenu contextMenu = StandardContextMenu.Create(this.OnContextMenuItemClick);
            contextMenu.Opening += this.OnContextMenuOpening;

            this.txtSource.ContextMenu = null;
            this.txtSource.ContextMenuStrip = contextMenu;

            this.txtSource.SetWatermark(true);
            this.txtResult.Text = String.Empty;
            this.txtResult.BackColor = Color.Transparent;
            this.txtResult.TextAlign = ContentAlignment.TopLeft;

            this.lblText.LinkArea = new LinkArea();

            String url1 = "https://haveibeenpwned.com/passwords";
            String url2 = "https://haveibeenpwned.com/api/v3";

            this.lblText.Text = String.Format(
                "On this view you can run an online check for your source password.{0}{0}" +
                "For this purpose an API request for so-called “pwned passwords” is sent to URL https://api.pwnedpasswords.com/range.{0}{0}" +
                "Note that the plain password is never sent to that API.{0}{0}" +
                "More information about “pwned passwords” can be found under {1}.{0}{0}" +
                "More information about the API can be found under {2}.",
                Environment.NewLine, url1, url2);

            this.lblText.Links.Add(this.lblText.Text.IndexOf(url1), url1.Length, url1);
            this.lblText.Links.Add(this.lblText.Text.IndexOf(url2), url2.Length, url2);
        }

        #endregion

        #region Public Methods

        public async void Generate(IGeneratorSettings generatorSettings)
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

            try
            {
                this.RaiseUpdateStatus(null, "Running...");
                this.Cursor = Cursors.WaitCursor;

                this.txtResult.Text = String.Empty;
                this.txtResult.BackColor = Color.Transparent;
                this.txtResult.TextAlign = ContentAlignment.TopLeft;

                Int64 result = await this.passwordCounter.GetPwnCountAsync(source, new CancellationToken());

                if (result > 0)
                {
                    this.txtResult.Text = $"Bad news! This password has been seen at least {result:N0} times before.";
                    this.txtResult.BackColor = this.color1;
                    this.txtResult.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    this.txtResult.Text = "Good news! This password may not have been seen yet.";
                    this.txtResult.BackColor = this.color2;
                    this.txtResult.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            catch (Exception exception)
            {
                this.txtResult.Text = exception.Message;
                this.txtResult.BackColor = Color.Transparent;
                this.txtResult.TextAlign = ContentAlignment.TopLeft;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.RaiseUpdateStatus();
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
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

        #region Private Methods

        private void OnSettingsLinkClicked(Object sender, LinkLabelLinkClickedEventArgs args)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Process.Start(args.Link.LinkData.ToString());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);

                MessageBox.Show(base.ParentForm,
                    "An error occurred while trying to open the URL in the default browser.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
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
                }
                else if (parent.IsCut(source))
                {
                    if (parent.SourceControl == this.txtSource)
                    {
                        Clipboard.SetText(this.txtSource.Text);
                        this.txtSource.Text = String.Empty;
                        this.txtResult.Text = String.Empty;
                        this.txtResult.BackColor = Color.Transparent;
                        this.txtResult.TextAlign = ContentAlignment.TopLeft;
                    }
                }
                else if (parent.IsPaste(source))
                {
                    if (parent.SourceControl == this.txtSource && Clipboard.ContainsText())
                    {
                        this.txtSource.Text = Clipboard.GetText().ClearLineEndings();
                    }
                }
                else if (parent.IsClear(source))
                {
                    if (parent.SourceControl == this.txtSource)
                    {
                        this.txtSource.Text = String.Empty;
                        this.txtResult.Text = String.Empty;
                        this.txtResult.BackColor = Color.Transparent;
                        this.txtResult.TextAlign = ContentAlignment.TopLeft;
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        #endregion
    }
}
