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

using Plexdata.PasswordGenerator.Extensions;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using ScenarioModel = Plexdata.PasswordGenerator.Models.Scenario;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class SecuritySettingsControl : UserControl, ISettingsControl<ISecuritySettings>
    {
        private Boolean editing = false;
        private ISecuritySettings controlSettings;

        public SecuritySettingsControl()
        {
            this.InitializeComponent();

            this.numGuesses.Minimum = Decimal.One;
            this.numGuesses.Maximum = Decimal.MaxValue;
            this.numGuesses.Increment = Decimal.One;

            this.txtName.SetWatermark(true);
            this.txtText.SetWatermark(true);
            this.txtNote.SetWatermark(true);
        }

        public void Attach(ISecuritySettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            BindingList<ScenarioModel> scenarios = new BindingList<ScenarioModel>(
                this.controlSettings.Scenarios.Select(x => new ScenarioModel()
                {
                    Name = x.Name,
                    Text = x.Text,
                    Note = x.Note,
                    Guesses = x.Guesses
                }).ToList()
            );

            this.values.DisplayMember = nameof(ScenarioModel.Name);
            this.values.DataSource = scenarios;
        }

        public void Apply()
        {
            if (this.controlSettings != null)
            {
                if (this.editing)
                {
                    this.btnSave.PerformClick();
                }

                if (this.values.DataSource is BindingList<ScenarioModel> scenarios)
                {
                    this.controlSettings.Scenarios = scenarios.ToArray();
                }
            }
        }

        public void Detach()
        {
            if (this.controlSettings != null)
            {
                this.controlSettings = null;
            }
        }

        private void OnValuesViewSelectedValueChanged(Object sender, EventArgs args)
        {
            this.SetEditing(false);
            this.SetValues(this.values.SelectedValue as ScenarioModel);
        }

        private void OnButtonAppendClick(Object sender, EventArgs args)
        {
            if (this.values.DataSource is BindingList<ScenarioModel> scenarios)
            {
                scenarios.Add(ScenarioModel.New);
                this.values.SelectedIndex = scenarios.Count - 1;
                this.btnEdit.PerformClick();
            }
        }

        private void OnButtonDeleteClick(Object sender, EventArgs args)
        {
            if (this.values.DataSource is BindingList<ScenarioModel> scenarios && this.values.SelectedValue is ScenarioModel selected)
            {
                Int32 index = this.values.SelectedIndex;

                scenarios.Remove(selected);

                Int32 count = this.values.Items.Count;

                if (count > 0)
                {
                    if (index >= count - 1)
                    {
                        index = count - 1;
                    }

                    this.values.SelectedIndex = index;
                }
            }
        }

        private void OnButtonEditClick(Object sender, EventArgs args)
        {
            this.SetEditing(true);
        }

        private void OnButtonSaveClick(Object sender, EventArgs args)
        {
            if (this.values.SelectedValue is ScenarioModel selected)
            {
                try
                {
                    selected.Name = this.txtName.Text;
                    selected.Text = this.txtText.Text;
                    selected.Note = this.txtNote.Text;
                    selected.Guesses = Convert.ToDouble(this.numGuesses.Value);

                    this.SetEditing(false);
                }
                catch
                {
                    MessageBox.Show(base.ParentForm,
                        "Could not save data.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnEditDataValidation(Object sender, CancelEventArgs args)
        {
            if (sender is TextBox control)
            {
                this.validator.SetError(control, String.Empty);

                if (String.IsNullOrWhiteSpace(control.Text))
                {
                    this.validator.SetError(control, "Please provide a valid value.");
                    this.validator.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                    args.Cancel = true;
                }
            }
        }

        private void SetEditing(Boolean enabled)
        {
            this.txtName.Enabled = enabled;
            this.txtText.Enabled = enabled;
            this.txtNote.Enabled = enabled;
            this.numGuesses.Enabled = enabled;
            this.btnEdit.Enabled = !enabled;
            this.btnSave.Enabled = enabled;

            this.editing = enabled;
        }

        private void SetValues(ScenarioModel scenario)
        {
            if (scenario == null)
            {
                this.txtName.Text = String.Empty;
                this.txtText.Text = String.Empty;
                this.txtNote.Text = String.Empty;
                this.numGuesses.Value = this.numGuesses.Minimum;
            }
            else
            {
                this.txtName.Text = scenario.Name;
                this.txtText.Text = scenario.Text;
                this.txtNote.Text = scenario.Note;
                this.numGuesses.Value = Convert.ToDecimal(scenario.Guesses);
            }
        }
    }
}
