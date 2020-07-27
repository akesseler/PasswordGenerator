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

namespace Plexdata.PasswordGenerator.Controls
{
    partial class ExtendedSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtendedSettingsControl));
            this.group1 = new System.Windows.Forms.GroupBox();
            this.btnOthers = new System.Windows.Forms.Button();
            this.btnExtras = new System.Windows.Forms.Button();
            this.btnDigits = new System.Windows.Forms.Button();
            this.btnLowers = new System.Windows.Forms.Button();
            this.btnUppers = new System.Windows.Forms.Button();
            this.txtOthers = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.chbOthers = new System.Windows.Forms.CheckBox();
            this.txtExtras = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.chbExtras = new System.Windows.Forms.CheckBox();
            this.txtDigits = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.chbDigits = new System.Windows.Forms.CheckBox();
            this.txtLowers = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.chbLowers = new System.Windows.Forms.CheckBox();
            this.txtUppers = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.chbUppers = new System.Windows.Forms.CheckBox();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group1
            // 
            this.group1.Controls.Add(this.btnOthers);
            this.group1.Controls.Add(this.btnExtras);
            this.group1.Controls.Add(this.btnDigits);
            this.group1.Controls.Add(this.btnLowers);
            this.group1.Controls.Add(this.btnUppers);
            this.group1.Controls.Add(this.txtOthers);
            this.group1.Controls.Add(this.chbOthers);
            this.group1.Controls.Add(this.txtExtras);
            this.group1.Controls.Add(this.chbExtras);
            this.group1.Controls.Add(this.txtDigits);
            this.group1.Controls.Add(this.chbDigits);
            this.group1.Controls.Add(this.txtLowers);
            this.group1.Controls.Add(this.chbLowers);
            this.group1.Controls.Add(this.txtUppers);
            this.group1.Controls.Add(this.chbUppers);
            this.group1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.group1.Size = new System.Drawing.Size(500, 300);
            this.group1.TabIndex = 1;
            this.group1.TabStop = false;
            this.group1.Text = "Character Pools";
            // 
            // btnOthers
            // 
            this.btnOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOthers.FlatAppearance.BorderSize = 0;
            this.btnOthers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.btnOthers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.btnOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOthers.Image = ((System.Drawing.Image)(resources.GetObject("btnOthers.Image")));
            this.btnOthers.Location = new System.Drawing.Point(469, 153);
            this.btnOthers.Margin = new System.Windows.Forms.Padding(0);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(26, 26);
            this.btnOthers.TabIndex = 14;
            this.btnOthers.TabStop = false;
            this.btnOthers.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // btnExtras
            // 
            this.btnExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtras.FlatAppearance.BorderSize = 0;
            this.btnExtras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.btnExtras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.btnExtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtras.Image = ((System.Drawing.Image)(resources.GetObject("btnExtras.Image")));
            this.btnExtras.Location = new System.Drawing.Point(469, 121);
            this.btnExtras.Margin = new System.Windows.Forms.Padding(0);
            this.btnExtras.Name = "btnExtras";
            this.btnExtras.Size = new System.Drawing.Size(26, 26);
            this.btnExtras.TabIndex = 11;
            this.btnExtras.TabStop = false;
            this.btnExtras.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // btnDigits
            // 
            this.btnDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDigits.FlatAppearance.BorderSize = 0;
            this.btnDigits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.btnDigits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.btnDigits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDigits.Image = ((System.Drawing.Image)(resources.GetObject("btnDigits.Image")));
            this.btnDigits.Location = new System.Drawing.Point(469, 88);
            this.btnDigits.Margin = new System.Windows.Forms.Padding(0);
            this.btnDigits.Name = "btnDigits";
            this.btnDigits.Size = new System.Drawing.Size(26, 26);
            this.btnDigits.TabIndex = 8;
            this.btnDigits.TabStop = false;
            this.btnDigits.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // btnLowers
            // 
            this.btnLowers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLowers.FlatAppearance.BorderSize = 0;
            this.btnLowers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.btnLowers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.btnLowers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowers.Image = ((System.Drawing.Image)(resources.GetObject("btnLowers.Image")));
            this.btnLowers.Location = new System.Drawing.Point(469, 57);
            this.btnLowers.Margin = new System.Windows.Forms.Padding(0);
            this.btnLowers.Name = "btnLowers";
            this.btnLowers.Size = new System.Drawing.Size(26, 26);
            this.btnLowers.TabIndex = 5;
            this.btnLowers.TabStop = false;
            this.btnLowers.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // btnUppers
            // 
            this.btnUppers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUppers.FlatAppearance.BorderSize = 0;
            this.btnUppers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(202)))), ((int)(((byte)(136)))));
            this.btnUppers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.btnUppers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUppers.Image = global::Plexdata.PasswordGenerator.Properties.Resources.reset_16x16;
            this.btnUppers.Location = new System.Drawing.Point(469, 25);
            this.btnUppers.Margin = new System.Windows.Forms.Padding(0);
            this.btnUppers.Name = "btnUppers";
            this.btnUppers.Size = new System.Drawing.Size(26, 26);
            this.btnUppers.TabIndex = 2;
            this.btnUppers.TabStop = false;
            this.btnUppers.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // txtOthers
            // 
            this.txtOthers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOthers.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOthers.Limitation = Plexdata.PasswordGenerator.Controls.LimitedTextBox.LimitationType.Other;
            this.txtOthers.Location = new System.Drawing.Point(136, 153);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(330, 26);
            this.txtOthers.TabIndex = 13;
            this.txtOthers.Tag = "Other Characters...";
            // 
            // chbOthers
            // 
            this.chbOthers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbOthers.Location = new System.Drawing.Point(8, 153);
            this.chbOthers.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.chbOthers.Name = "chbOthers";
            this.chbOthers.Size = new System.Drawing.Size(120, 26);
            this.chbOthers.TabIndex = 12;
            this.chbOthers.Text = "&Other Characters:";
            // 
            // txtExtras
            // 
            this.txtExtras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtras.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtras.Limitation = Plexdata.PasswordGenerator.Controls.LimitedTextBox.LimitationType.Extra;
            this.txtExtras.Location = new System.Drawing.Point(136, 121);
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(330, 26);
            this.txtExtras.TabIndex = 10;
            this.txtExtras.Tag = "Extra Characters...";
            // 
            // chbExtras
            // 
            this.chbExtras.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbExtras.Location = new System.Drawing.Point(8, 121);
            this.chbExtras.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.chbExtras.Name = "chbExtras";
            this.chbExtras.Size = new System.Drawing.Size(120, 26);
            this.chbExtras.TabIndex = 9;
            this.chbExtras.Text = "E&xtra Characters:";
            // 
            // txtDigits
            // 
            this.txtDigits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDigits.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDigits.Limitation = Plexdata.PasswordGenerator.Controls.LimitedTextBox.LimitationType.Digit;
            this.txtDigits.Location = new System.Drawing.Point(136, 89);
            this.txtDigits.Name = "txtDigits";
            this.txtDigits.Size = new System.Drawing.Size(330, 26);
            this.txtDigits.TabIndex = 7;
            this.txtDigits.Tag = "Digits...";
            // 
            // chbDigits
            // 
            this.chbDigits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbDigits.Location = new System.Drawing.Point(8, 89);
            this.chbDigits.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.chbDigits.Name = "chbDigits";
            this.chbDigits.Size = new System.Drawing.Size(120, 26);
            this.chbDigits.TabIndex = 6;
            this.chbDigits.Text = "&Digits:";
            // 
            // txtLowers
            // 
            this.txtLowers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowers.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowers.Limitation = Plexdata.PasswordGenerator.Controls.LimitedTextBox.LimitationType.Lower;
            this.txtLowers.Location = new System.Drawing.Point(136, 57);
            this.txtLowers.Name = "txtLowers";
            this.txtLowers.Size = new System.Drawing.Size(330, 26);
            this.txtLowers.TabIndex = 4;
            this.txtLowers.Tag = "Lower Case Letters...";
            // 
            // chbLowers
            // 
            this.chbLowers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbLowers.Location = new System.Drawing.Point(8, 57);
            this.chbLowers.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.chbLowers.Name = "chbLowers";
            this.chbLowers.Size = new System.Drawing.Size(120, 26);
            this.chbLowers.TabIndex = 3;
            this.chbLowers.Text = "Lo&wer Case Letters:";
            // 
            // txtUppers
            // 
            this.txtUppers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUppers.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUppers.Limitation = Plexdata.PasswordGenerator.Controls.LimitedTextBox.LimitationType.Upper;
            this.txtUppers.Location = new System.Drawing.Point(136, 25);
            this.txtUppers.Name = "txtUppers";
            this.txtUppers.Size = new System.Drawing.Size(330, 26);
            this.txtUppers.TabIndex = 1;
            this.txtUppers.Tag = "Capital Letters...";
            // 
            // chbUppers
            // 
            this.chbUppers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbUppers.Location = new System.Drawing.Point(8, 25);
            this.chbUppers.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.chbUppers.Name = "chbUppers";
            this.chbUppers.Size = new System.Drawing.Size(120, 26);
            this.chbUppers.TabIndex = 0;
            this.chbUppers.Text = "&Capital Letters:";
            // 
            // ExtendedSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.group1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExtendedSettingsControl";
            this.Size = new System.Drawing.Size(500, 300);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.Button btnOthers;
        private System.Windows.Forms.Button btnExtras;
        private System.Windows.Forms.Button btnDigits;
        private System.Windows.Forms.Button btnLowers;
        private System.Windows.Forms.Button btnUppers;
        private LimitedTextBox txtOthers;
        private System.Windows.Forms.CheckBox chbOthers;
        private LimitedTextBox txtExtras;
        private System.Windows.Forms.CheckBox chbExtras;
        private LimitedTextBox txtDigits;
        private System.Windows.Forms.CheckBox chbDigits;
        private LimitedTextBox txtLowers;
        private System.Windows.Forms.CheckBox chbLowers;
        private LimitedTextBox txtUppers;
        private System.Windows.Forms.CheckBox chbUppers;
    }
}
