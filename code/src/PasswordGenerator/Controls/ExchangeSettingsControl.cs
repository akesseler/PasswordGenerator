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

using Plexdata.PasswordGenerator.Interfaces;
using Plexdata.PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class ExchangeSettingsControl : UserControl, ISettingsControl<IExchangeSettings>
    {
        private IExchangeSettings controlSettings;

        public ExchangeSettingsControl()
        {
            this.InitializeComponent();
        }

        public void Attach(IExchangeSettings controlSettings)
        {
            if (controlSettings is null) { throw new ArgumentNullException(nameof(controlSettings)); }

            this.Detach();

            this.controlSettings = controlSettings;

            this.SetValues(this.controlSettings.Values);

            this.controlSettings.PropertyChanged += this.OnSettingsPropertyChanged;
        }

        public void Apply()
        {
            if (this.controlSettings != null)
            {
                List<Exchange> values = new List<Exchange>();

                foreach (DataGridViewRow row in this.data1.Rows)
                {
                    String source = row.Cells[0]?.Value?.ToString() ?? String.Empty;
                    String target = row.Cells[1]?.Value?.ToString() ?? String.Empty;

                    if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(target))
                    {
                        continue;
                    }

                    values.Add(new Exchange(source[0].ToString(), target[0].ToString()));
                }

                this.controlSettings.Values = values.ToArray();
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
            this.SetValues(this.controlSettings.Values);
        }

        private void OnManageButtonClick(Object sender, EventArgs args)
        {
            if (sender == this.btnDelete)
            {
                if (this.data1.SelectedRows.Count == this.data1.RowCount)
                {
                    this.data1.Rows.Clear();
                }
                else
                {
                    foreach (DataGridViewRow row in this.data1.SelectedRows)
                    {
                        this.data1.Rows.RemoveAt(row.Index);
                    }
                }
            }
            else if (sender == this.btnAppend)
            {
                var row = this.AddRow("?", "?");
                this.data1.CurrentCell = row.Cells[0];
                this.data1.BeginEdit(true);
            }
            else if (sender == this.btnReset)
            {
                this.controlSettings.Reset(nameof(this.controlSettings.Values));
            }
        }

        private void SetValues(IEnumerable<Exchange> values)
        {
            this.data1.Rows.Clear();

            foreach (Exchange value in values)
            {
                this.AddRow(value.Source, value.Target);
            }
        }

        private DataGridViewRow AddRow(String source, String target)
        {
            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(this.data1, new String[] { source, target });

            this.data1.Rows.Add(row);

            return row;
        }
    }
}
