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
using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Entities;
using Plexdata.Utilities.Password.Factories;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScenarioModel = Plexdata.PasswordGenerator.Models.Scenario;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class SecurityGeneratorControl : UserControl, IGeneratorControl, IGeneratorControl<ISecuritySettings>, IStatusRequester, IResultWriter
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        #endregion

        #region Private Fields

        private ISecuritySettings controlSettings = null;

        #endregion

        #region Construction

        public SecurityGeneratorControl()
        {
            this.InitializeComponent();

            StandardContextMenu contextMenu = StandardContextMenu.Create(this.OnContextMenuItemClick);
            contextMenu.Opening += this.OnContextMenuOpening;

            this.txtPassword.ContextMenu = null;
            this.txtPassword.ContextMenuStrip = contextMenu;
            this.txtPassword.SetWatermark(true);
        }

        #endregion

        #region Public Properties

        public Boolean HasResult
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Methods

        public void Generate(IGeneratorSettings generatorSettings)
        {
            if (String.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                MessageBox.Show(base.ParentForm,
                    "Provide a source password to be processed.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEntropyCalculator entropyCalculator = CalculatorFactory.Create<IEntropyCalculator>();
            IStrengthCalculator strengthCalculator = CalculatorFactory.Create<IStrengthCalculator>();
            ISecurityCalculator securityCalculator = CalculatorFactory.Create<ISecurityCalculator>();

            String password = this.txtPassword.Text;
            Double entropy = entropyCalculator.Calculate(password);
            Strength strength = strengthCalculator.Calculate(entropy);
            Scenario scenario = this.cmbScenario.SelectedValue as Scenario;

            // Don't change this order.
            this.cntEntropy.Strength = strength;
            this.cntEntropy.Entropy = entropy;
            this.cntEntropy.Percent = strengthCalculator.ToPercent(entropy);
            this.cntEntropy.Summary = strengthCalculator.ToSummary(strength);

            if (entropy > 0d)
            {
                Duration duration = securityCalculator.Calculate(scenario, entropy);
                this.cntDuration.SetDuration(duration);
            }
        }

        public void WriteResult(Stream stream, Encoding encoding)
        {
            if (stream == null || !stream.CanWrite || encoding == null)
            {
                return;
            }
        }

        public void Attach(ISecuritySettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            this.controlSettings.PropertyChanged += this.OnControlSettingsPropertyChanged;

            this.InitializeControls();
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

        #region Private Methods

        private void InitializeControls()
        {
            this.cmbScenario.DisplayMember = null;
            this.cmbScenario.DataSource = null;

            List<Scenario> scenarios = new List<Scenario>()
            {
                Scenario.OnlineAttack,
                Scenario.OfflineFastAttack,
                Scenario.MassiveCrackingAttack
            };

            foreach (ScenarioModel current in this.controlSettings.Scenarios)
            {
                if (!String.IsNullOrWhiteSpace(current.Name) && !String.IsNullOrWhiteSpace(current.Text) && current.Guesses > 0d)
                {
                    if (!String.IsNullOrWhiteSpace(current.Note))
                    {
                        scenarios.Add(new Scenario(current.Name, current.Text, current.Note, current.Guesses));
                    }
                    else
                    {
                        scenarios.Add(new Scenario(current.Name, current.Text, current.Guesses));
                    }
                }
            }

            this.cmbScenario.DisplayMember = nameof(Scenario.Name);
            this.cmbScenario.DataSource = scenarios;
        }

        private void OnControlSettingsPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            if (sender is ISecuritySettings settings)
            {
                this.InitializeControls();
            }
        }

        private void OnScenarioSelectedValueChanged(Object sender, EventArgs args)
        {
            if (sender is ComboBox source)
            {
                this.tooltip.SetToolTip(source, String.Empty);

                if (source.SelectedValue is Scenario scenario)
                {
                    this.txtGuesses.Text = scenario.Guesses.ToString("N0");
                    this.tooltip.SetToolTip(source, scenario.Text);
                }
            }
        }

        private void OnContextMenuOpening(Object sender, CancelEventArgs args)
        {
            try
            {
                StandardContextMenu source = StandardContextMenu.MenuFromSender(sender, out Control control);

                if (source == null) { return; }

                source.DisableAll();

                if (control == this.txtPassword)
                {
                    source.Paste.Enabled = Clipboard.ContainsText();
                    source.Clear.Enabled = this.txtPassword.Text.Length > 0;
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

                if (parent.IsPaste(source))
                {
                    if (parent.SourceControl == this.txtPassword && Clipboard.ContainsText())
                    {
                        this.txtPassword.Text = Clipboard.GetText().ClearLineEndings();
                        this.cntEntropy.Reset();
                        this.cntDuration.Reset();
                    }
                }
                else if (parent.IsClear(source))
                {
                    if (parent.SourceControl == this.txtPassword)
                    {
                        this.txtPassword.Text = String.Empty;
                        this.cntEntropy.Reset();
                        this.cntDuration.Reset();
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
