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
using Plexdata.Utilities.Keyboard.Defines;
using Plexdata.Utilities.Keyboard.Exceptions;
using Plexdata.Utilities.Keyboard.Factories;
using Plexdata.Utilities.Keyboard.Interfaces;
using System;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Controls
{
    public partial class QwertyGeneratorControl : UserControl, IGeneratorControl
    {
        #region Private Fields

        private readonly IQwertyValidator qwertyValidator = null;

        #endregion

        #region Construction

        public QwertyGeneratorControl()
            : base()
        {
            this.InitializeComponent();

            this.qwertyValidator = KeyboardFactory.Create<IQwertyValidator>();

            this.txtSource.SetWatermark(true);
            this.txtResult.Text = String.Empty;
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

            try
            {
                this.qwertyValidator.Validate(source.ToLower(), KeyType.Lower);

                this.txtResult.Text = "Doesn't seem to be a QWERTY password.";
            }
            catch (QwertyException exception)
            {
                this.txtResult.Text = exception.Message;
            }
        }

        #endregion
    }
}
