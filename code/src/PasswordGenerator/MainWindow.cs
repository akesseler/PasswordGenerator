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

using Plexdata.PasswordGenerator.Dialogs;
using Plexdata.PasswordGenerator.Events;
using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.PasswordGenerator.Settings;
using System;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator
{
    // TODO: Remove or put somewhere else...
    // Für common => https://www.gaijin.at/de/tools/password-generator
    // Für Extended => Exclude Similar Characters Like: https://passwordsgenerator.net
    // http://cubicspot.blogspot.com/2011/11/how-to-calculate-password-strength.html?m=1
    // http://www.passwordmeter.com => Berechnung mit anzeige der einzelnen werte
    // https://keepass.info/help/base/pwgenerator.html Unten stehen die Patterns
    public partial class MainWindow : Form
    {
        #region Private Fields

        private ProgramSettings settings = null;

        #endregion

        #region Construction

        public MainWindow()
        {
            this.InitializeComponent();

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

            if (this.settings.MainWindow.LastVisible < 0 || this.settings.MainWindow.LastVisible > tvcContent.TabCount)
            {
                this.settings.MainWindow.LastVisible = 0;
            }

            this.tvcContent.SelectedIndex = this.settings.MainWindow.LastVisible;

            this.gusCommon.UpdateStatus += this.OnControlUpdateStatus;
            this.gusExtended.UpdateStatus += this.OnControlUpdateStatus;
            this.gusExchange.UpdateStatus += this.OnControlUpdateStatus;
            this.gusSecurity.UpdateStatus += this.OnControlUpdateStatus;

            this.gusCommon.Attach(this.settings.CommonData);
            this.gusExtended.Attach(this.settings.ExtendedData);
            this.gusExchange.Attach(this.settings.ExchangeData);
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
            MessageBox.Show("To be implemented", "Save");

            this.SaveSettings(this.settings.ExtendedData);
        }

        private void OnPlayButtonClick(Object sender, EventArgs args)
        {
            IGeneratorControl affected = this.tvcContent.SelectedTab.Controls[0] as IGeneratorControl;

            affected?.Generate(this.settings.GeneratorData);
        }

        private void OnSettingsButtonClick(Object sender, EventArgs args)
        {
            SettingsDialog.Show(this, this.settings);
        }

        private void OnInfoButtonClick(Object sender, EventArgs args)
        {
            MessageBox.Show("To be implemented", "Info");
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

        private void OnContentViewSelectedIndexChanged(Object sender, EventArgs args)
        {
            this.tssLabel.Text = String.Empty;
            this.tssValue.Text = String.Empty;
        }

        #endregion

        #region Private methods

        private void SaveSettings(ExtendedSettings settings)
        {
            if (settings is null)
            {
                return;
            }
        }

        #endregion
    }
}
