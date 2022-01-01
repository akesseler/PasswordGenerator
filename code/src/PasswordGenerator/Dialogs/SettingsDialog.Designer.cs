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

namespace Plexdata.PasswordGenerator.Dialogs
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panContent = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.view = new Plexdata.PasswordGenerator.Controls.TabViewControl();
            this.page1 = new System.Windows.Forms.TabPage();
            this.control1 = new Plexdata.PasswordGenerator.Controls.ExtendedSettingsControl();
            this.page2 = new System.Windows.Forms.TabPage();
            this.control2 = new Plexdata.PasswordGenerator.Controls.ExchangeSettingsControl();
            this.page3 = new System.Windows.Forms.TabPage();
            this.control3 = new Plexdata.PasswordGenerator.Controls.SecuritySettingsControl();
            this.panButtons.SuspendLayout();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.view.SuspendLayout();
            this.page1.SuspendLayout();
            this.page2.SuspendLayout();
            this.page3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButtons
            // 
            this.panButtons.BackColor = System.Drawing.Color.Transparent;
            this.panButtons.Controls.Add(this.btnApply);
            this.panButtons.Controls.Add(this.btnCancel);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtons.Location = new System.Drawing.Point(0, 315);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(584, 47);
            this.panButtons.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(416, 12);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(497, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panContent
            // 
            this.panContent.BackColor = System.Drawing.Color.White;
            this.panContent.Controls.Add(this.splitter);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(584, 315);
            this.panContent.TabIndex = 0;
            // 
            // splitter
            // 
            this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitter.IsSplitterFixed = true;
            this.splitter.Location = new System.Drawing.Point(12, 12);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.AutoScroll = true;
            this.splitter.Panel1.Controls.Add(this.radio3);
            this.splitter.Panel1.Controls.Add(this.radio2);
            this.splitter.Panel1.Controls.Add(this.radio1);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.view);
            this.splitter.Size = new System.Drawing.Size(560, 297);
            this.splitter.SplitterDistance = 80;
            this.splitter.TabIndex = 0;
            this.splitter.TabStop = false;
            // 
            // radio3
            // 
            this.radio3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radio3.FlatAppearance.BorderSize = 0;
            this.radio3.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.radio3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.radio3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.radio3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio3.Location = new System.Drawing.Point(0, 160);
            this.radio3.Name = "radio3";
            this.radio3.Size = new System.Drawing.Size(80, 80);
            this.radio3.TabIndex = 2;
            this.radio3.Text = "Security Generator Settings";
            this.radio3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio3.UseVisualStyleBackColor = true;
            this.radio3.Click += new System.EventHandler(this.OnToggleButtonClick);
            // 
            // radio2
            // 
            this.radio2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radio2.FlatAppearance.BorderSize = 0;
            this.radio2.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.radio2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.radio2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.radio2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio2.Location = new System.Drawing.Point(0, 80);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(80, 80);
            this.radio2.TabIndex = 1;
            this.radio2.Text = "Exchange Generator Settings";
            this.radio2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio2.UseVisualStyleBackColor = true;
            this.radio2.Click += new System.EventHandler(this.OnToggleButtonClick);
            // 
            // radio1
            // 
            this.radio1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radio1.FlatAppearance.BorderSize = 0;
            this.radio1.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.radio1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.radio1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.radio1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio1.Location = new System.Drawing.Point(0, 0);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(80, 80);
            this.radio1.TabIndex = 0;
            this.radio1.Text = "Extended Generator Settings";
            this.radio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio1.UseVisualStyleBackColor = true;
            this.radio1.Click += new System.EventHandler(this.OnToggleButtonClick);
            // 
            // view
            // 
            this.view.Controls.Add(this.page1);
            this.view.Controls.Add(this.page2);
            this.view.Controls.Add(this.page3);
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Margin = new System.Windows.Forms.Padding(0);
            this.view.Name = "view";
            this.view.Padding = new System.Drawing.Point(0, 0);
            this.view.SelectedIndex = 0;
            this.view.Size = new System.Drawing.Size(476, 297);
            this.view.TabIndex = 0;
            this.view.TabStop = false;
            this.view.TabsVisible = false;
            // 
            // page1
            // 
            this.page1.BackColor = System.Drawing.Color.White;
            this.page1.Controls.Add(this.control1);
            this.page1.Location = new System.Drawing.Point(4, 22);
            this.page1.Margin = new System.Windows.Forms.Padding(0);
            this.page1.Name = "page1";
            this.page1.Size = new System.Drawing.Size(468, 271);
            this.page1.TabIndex = 0;
            this.page1.Text = "Page 1";
            // 
            // control1
            // 
            this.control1.BackColor = System.Drawing.Color.Transparent;
            this.control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control1.Location = new System.Drawing.Point(0, 0);
            this.control1.Margin = new System.Windows.Forms.Padding(0);
            this.control1.Name = "control1";
            this.control1.Padding = new System.Windows.Forms.Padding(5);
            this.control1.Size = new System.Drawing.Size(468, 271);
            this.control1.TabIndex = 0;
            // 
            // page2
            // 
            this.page2.BackColor = System.Drawing.Color.White;
            this.page2.Controls.Add(this.control2);
            this.page2.Location = new System.Drawing.Point(4, 22);
            this.page2.Margin = new System.Windows.Forms.Padding(0);
            this.page2.Name = "page2";
            this.page2.Size = new System.Drawing.Size(468, 271);
            this.page2.TabIndex = 1;
            this.page2.Text = "Page 2";
            // 
            // control2
            // 
            this.control2.BackColor = System.Drawing.Color.Transparent;
            this.control2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control2.Location = new System.Drawing.Point(0, 0);
            this.control2.Margin = new System.Windows.Forms.Padding(0);
            this.control2.Name = "control2";
            this.control2.Padding = new System.Windows.Forms.Padding(5);
            this.control2.Size = new System.Drawing.Size(468, 271);
            this.control2.TabIndex = 1;
            // 
            // page3
            // 
            this.page3.BackColor = System.Drawing.Color.White;
            this.page3.Controls.Add(this.control3);
            this.page3.Location = new System.Drawing.Point(4, 22);
            this.page3.Margin = new System.Windows.Forms.Padding(0);
            this.page3.Name = "page3";
            this.page3.Size = new System.Drawing.Size(468, 271);
            this.page3.TabIndex = 2;
            this.page3.Text = "Page 3";
            // 
            // control3
            // 
            this.control3.BackColor = System.Drawing.Color.Transparent;
            this.control3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control3.Location = new System.Drawing.Point(0, 0);
            this.control3.Margin = new System.Windows.Forms.Padding(0);
            this.control3.Name = "control3";
            this.control3.Padding = new System.Windows.Forms.Padding(5);
            this.control3.Size = new System.Drawing.Size(468, 271);
            this.control3.TabIndex = 2;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panButtons);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panButtons.ResumeLayout(false);
            this.panContent.ResumeLayout(false);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.view.ResumeLayout(false);
            this.page1.ResumeLayout(false);
            this.page2.ResumeLayout(false);
            this.page3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panContent;
        private Controls.ExtendedSettingsControl control1;
        private Controls.TabViewControl view;
        private System.Windows.Forms.TabPage page1;
        private System.Windows.Forms.TabPage page2;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private Controls.ExchangeSettingsControl control2;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.TabPage page3;
        private Controls.SecuritySettingsControl control3;
    }
}