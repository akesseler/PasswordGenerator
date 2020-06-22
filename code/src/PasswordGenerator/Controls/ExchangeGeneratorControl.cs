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
using Plexdata.PasswordGenerator.Factories;
using Plexdata.PasswordGenerator.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class ExchangeGeneratorControl : UserControl, IGeneratorControl, IGeneratorControl<IExchangeSettings>, IStatusRequester
    {
        #region Public Events

        public event UpdateStatusEventHandler UpdateStatus;

        #endregion

        #region Private Fields

        private IExchangeSettings controlSettings = null;

        #endregion

        #region Construction

        public ExchangeGeneratorControl()
            : base()
        {
            this.InitializeComponent();

            this.txtSource.SetWatermark(true);
            this.txtResult.SetWatermark(true);
        }

        #endregion

        #region Public Methods

        public void Generate(IGeneratorSettings generatorSettings)
        {
            if (generatorSettings is null) { throw new ArgumentNullException(nameof(generatorSettings)); }

            String source = this.txtSource.Text;

            if (String.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show(
                    "Provide a source password to be processed.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IExchangeGenerator generator = GeneratorFactory.Create<IExchangeGenerator>();

            this.txtResult.Text = generator.Generate(this.controlSettings, this.txtSource.Text);
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

        #endregion

        #region Private Methods

        private void OnControlSettingsPropertyChanged(Object sender, PropertyChangedEventArgs args)
        {
            if (sender is IExchangeSettings settings)
            {
            }
        }

        #endregion
    }
}
