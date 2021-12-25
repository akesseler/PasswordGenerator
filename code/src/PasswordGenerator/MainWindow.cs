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

using Plexdata.PasswordGenerator.Controls;
using Plexdata.PasswordGenerator.Dialogs;
using Plexdata.PasswordGenerator.Events;
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.PasswordGenerator.Settings;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator
{
    // List of more interesting information as well as examples.
    // Example password security calculation:   http://www.passwordmeter.com
    // Example of exclude similar characters:   https://passwordsgenerator.net
    // Example of password patterns (and more): https://keepass.info/help/base/pwgenerator.html
    // Example of a common password generator:  https://www.gaijin.at/de/tools/password-generator
    // How to calculate password strength:      http://cubicspot.blogspot.com/2011/11/how-to-calculate-password-strength.html?m=1

    public partial class MainWindow : Form
    {
        #region Private Fields

        private ProgramSettings settings = null;

        #endregion

        #region Construction

        public MainWindow()
            : base()
        {
            this.InitializeComponent();

            this.Icon = Properties.Resources.MainIcon;
            this.Text = InfoDialog.Title;
            this.tssLabel.Text = String.Empty;
            this.tssValue.Text = String.Empty;
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            if (SettingsSerializer.Load(Program.SettingsFilename, out ProgramSettings settings))
            {
                this.settings = settings;
            }
            else
            {
                this.settings = new ProgramSettings();
            }

            this.settings.MainWindow.EnsureDisplayAttributes(this);

            if (this.settings.MainWindow.LastVisible < 0 || this.settings.MainWindow.LastVisible > this.tvcContent.TabCount)
            {
                this.settings.MainWindow.LastVisible = 0;
            }

            this.tvcContent.SelectedIndex = this.settings.MainWindow.LastVisible;

            this.gusCommon.UpdateStatus += this.OnControlUpdateStatus;
            this.gusExchange.UpdateStatus += this.OnControlUpdateStatus;
            this.gusExtended.UpdateStatus += this.OnControlUpdateStatus;
            this.gusSecurity.UpdateStatus += this.OnControlUpdateStatus;

            this.gusExchange.ShowSettings += this.OnControlShowSettings;

            this.gusCommon.Attach(this.settings.CommonData);
            this.gusExchange.Attach(this.settings.ExchangeData);
            this.gusExtended.Attach(this.settings.ExtendedData);
            this.gusSecurity.Attach(this.settings.SecurityData);
        }

        protected override void OnFormClosing(FormClosingEventArgs args)
        {
            this.settings.MainWindow.LastVisible = this.tvcContent.SelectedIndex;

            SettingsSerializer.Save(Program.SettingsFilename, this.settings);

            base.OnFormClosing(args);
        }

        protected override void OnMove(EventArgs args)
        {
            base.OnMove(args);
            this.settings?.MainWindow.ApplyLocation(this);
        }

        protected override void OnResizeEnd(EventArgs args)
        {
            base.OnResizeEnd(args);
            this.settings?.MainWindow.ApplyDimension(this);
        }

        #endregion

        #region Private Events

        private void OnExitButtonClick(Object sender, EventArgs args)
        {
            Application.Exit();
        }

        private void OnSaveButtonClick(Object sender, EventArgs args)
        {
            IResultWriter affected = this.tvcContent.SelectedTab.Controls[0] as IResultWriter;

            if (affected == null || !affected.HasResult)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Title = "Save Passwords",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                FileName = $"passwords-{DateTime.Now:yyyyMMddHHmmss}.txt",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using (Stream stream = dialog.OpenFile())
                {
                    affected.WriteResult(stream, Encoding.UTF8);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                    $"Could not save file. See message below for more details. {Environment.NewLine.Repeat(2)}{exception.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPlayButtonClick(Object sender, EventArgs args)
        {
            // Some kind of quick bug fix for NumberUpDown and its value validation.
            // When entering text into that control and pressing play button immediately afterwards,
            // then the validating event will not occur. But to force that validation it is required
            // to cause losing the focus on that control. Otherwise the previous value will be captured.
            // Therefore, cause a focus change to give the control a chance to run its validation.
            base.Focus();

            IGeneratorControl affected = this.tvcContent.SelectedTab.Controls[0] as IGeneratorControl;

            affected?.Generate(this.settings.GeneratorData);
        }

        private void OnSettingsButtonClick(Object sender, EventArgs args)
        {
            SettingsDialog.Show(this, this.settings);
        }

        private void OnInfoButtonClick(Object sender, EventArgs args)
        {
            InfoDialog dialog = new InfoDialog();

            dialog.ShowDialog(this);
        }

        private void OnControlUpdateStatus(Object sender, UpdateStatusEventArgs args)
        {
            if (args != null)
            {
                this.tssLabel.Text = args.Label;
                this.tssValue.Text = args.Value;
            }
            else
            {
                this.tssLabel.Text = String.Empty;
                this.tssValue.Text = String.Empty;
            }
        }

        private void OnControlShowSettings(Object sender, ShowSettingsEventArgs args)
        {
            if (sender.GetType() == typeof(ExchangeGeneratorControl))
            {
                SettingsDialog.Show(this, this.settings, args.Settings);
            }
        }

        private void OnContentViewSelectedIndexChanged(Object sender, EventArgs args)
        {
            this.tssLabel.Text = String.Empty;
            this.tssValue.Text = String.Empty;
        }

        #endregion
    }
}
