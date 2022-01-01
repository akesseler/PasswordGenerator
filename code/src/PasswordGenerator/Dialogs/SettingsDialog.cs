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
using Plexdata.PasswordGenerator.Settings;
using System;
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Dialogs
{
    public partial class SettingsDialog : Form
    {
        public ProgramSettings settings = null;

        public SettingsDialog(ProgramSettings settings)
            : base()
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            this.InitializeComponent();

            this.Icon = Properties.Resources.MainIcon;
            this.radio1.Tag = this.page1;
            this.radio2.Tag = this.page2;
            this.radio3.Tag = this.page3;

            this.radio1.Checked = true;
            this.view.SelectedTab = this.page1;
        }

        public SettingsDialog(ProgramSettings settings, String request)
            : this(settings)
        {
            if (String.Equals(ShowSettingsEventArgs.ExtendedSettings, request, StringComparison.InvariantCultureIgnoreCase))
            {
                this.radio1.Checked = true;
            }
            else if (String.Equals(ShowSettingsEventArgs.ExchangeSettings, request, StringComparison.InvariantCultureIgnoreCase))
            {
                this.radio2.Checked = true;
            }
            else if (String.Equals(ShowSettingsEventArgs.SecuritySettings, request, StringComparison.InvariantCultureIgnoreCase))
            {
                this.radio3.Checked = true;
            }
        }

        public static void Show(IWin32Window owner, ProgramSettings settings)
        {
            SettingsDialog dialog = new SettingsDialog(settings);
            dialog.ShowDialog(owner);
        }

        public static void Show(IWin32Window owner, ProgramSettings settings, String request)
        {
            SettingsDialog dialog = new SettingsDialog(settings, request);
            dialog.ShowDialog(owner);
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);

            this.control1.Attach(this.settings.GeneratorData);
            this.control2.Attach(this.settings.ExchangeData);
            this.control3.Attach(this.settings.SecurityData);
        }

        protected override void OnFormClosing(FormClosingEventArgs args)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.control1.Apply();
                this.control2.Apply();
                this.control3.Apply();
            }

            this.control1.Detach();
            this.control2.Detach();
            this.control3.Detach();

            base.OnFormClosing(args);
        }

        private void OnToggleButtonClick(Object sender, EventArgs args)
        {
            if (sender is RadioButton radio)
            {
                if (radio.Tag is TabPage page)
                {
                    this.view.SelectedTab = page;
                }
            }
        }
    }
}
