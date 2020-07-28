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
    partial class CommonGeneratorControl
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
            this.components = new System.ComponentModel.Container();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lblTypes = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.chkExtras = new System.Windows.Forms.CheckBox();
            this.chkDigits = new System.Windows.Forms.CheckBox();
            this.chkLowers = new System.Windows.Forms.CheckBox();
            this.chkUppers = new System.Windows.Forms.CheckBox();
            this.lblPhrase = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.grpPasswords = new System.Windows.Forms.GroupBox();
            this.chbDelete = new System.Windows.Forms.CheckBox();
            this.lstPasswords = new System.Windows.Forms.ListBox();
            this.numAmount = new Plexdata.PasswordGenerator.Controls.NumberUpDown();
            this.numLength = new Plexdata.PasswordGenerator.Controls.NumberUpDown();
            this.group1.SuspendLayout();
            this.grpPasswords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTypes
            // 
            this.cmbTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(80, 25);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(412, 21);
            this.cmbTypes.TabIndex = 1;
            this.cmbTypes.SelectedValueChanged += new System.EventHandler(this.OnTypesSelectedValueChanged);
            // 
            // lblTypes
            // 
            this.lblTypes.AutoSize = true;
            this.lblTypes.Location = new System.Drawing.Point(8, 29);
            this.lblTypes.Name = "lblTypes";
            this.lblTypes.Size = new System.Drawing.Size(39, 13);
            this.lblTypes.TabIndex = 0;
            this.lblTypes.Text = "&Types:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(8, 177);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 12;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(80, 176);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(412, 50);
            this.txtRemarks.TabIndex = 13;
            this.txtRemarks.Text = "???";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(8, 54);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "&Length:";
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group1.Controls.Add(this.txtPhrase);
            this.group1.Controls.Add(this.chkExtras);
            this.group1.Controls.Add(this.chkDigits);
            this.group1.Controls.Add(this.chkLowers);
            this.group1.Controls.Add(this.chkUppers);
            this.group1.Controls.Add(this.cmbTypes);
            this.group1.Controls.Add(this.lblRemarks);
            this.group1.Controls.Add(this.txtRemarks);
            this.group1.Controls.Add(this.numAmount);
            this.group1.Controls.Add(this.numLength);
            this.group1.Controls.Add(this.lblPhrase);
            this.group1.Controls.Add(this.lblAmount);
            this.group1.Controls.Add(this.lblLength);
            this.group1.Controls.Add(this.lblTypes);
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Margin = new System.Windows.Forms.Padding(0);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.group1.Size = new System.Drawing.Size(500, 236);
            this.group1.TabIndex = 0;
            this.group1.TabStop = false;
            this.group1.Text = "Source Information";
            // 
            // txtPhrase
            // 
            this.txtPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhrase.Location = new System.Drawing.Point(80, 104);
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(412, 20);
            this.txtPhrase.TabIndex = 7;
            this.tooltip.SetToolTip(this.txtPhrase, "The custom password phrase to be used.");
            this.txtPhrase.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // chkExtras
            // 
            this.chkExtras.AutoSize = true;
            this.chkExtras.Checked = true;
            this.chkExtras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtras.Location = new System.Drawing.Point(201, 153);
            this.chkExtras.Name = "chkExtras";
            this.chkExtras.Size = new System.Drawing.Size(115, 17);
            this.chkExtras.TabIndex = 11;
            this.chkExtras.Text = "Special Characters";
            this.tooltip.SetToolTip(this.chkExtras, "The password generator should include special characters.");
            this.chkExtras.UseVisualStyleBackColor = true;
            this.chkExtras.CheckedChanged += new System.EventHandler(this.OnPoolsCheckedChanged);
            // 
            // chkDigits
            // 
            this.chkDigits.AutoSize = true;
            this.chkDigits.Checked = true;
            this.chkDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDigits.Location = new System.Drawing.Point(80, 153);
            this.chkDigits.Name = "chkDigits";
            this.chkDigits.Size = new System.Drawing.Size(102, 17);
            this.chkDigits.TabIndex = 9;
            this.chkDigits.Text = "Numerical Digits";
            this.tooltip.SetToolTip(this.chkDigits, "The password generator should include numerical digits.");
            this.chkDigits.UseVisualStyleBackColor = true;
            this.chkDigits.CheckedChanged += new System.EventHandler(this.OnPoolsCheckedChanged);
            // 
            // chkLowers
            // 
            this.chkLowers.AutoSize = true;
            this.chkLowers.Checked = true;
            this.chkLowers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowers.Location = new System.Drawing.Point(201, 130);
            this.chkLowers.Name = "chkLowers";
            this.chkLowers.Size = new System.Drawing.Size(113, 17);
            this.chkLowers.TabIndex = 10;
            this.chkLowers.Text = "Lowercase Letters";
            this.tooltip.SetToolTip(this.chkLowers, "The password generator should include lowercase letters.");
            this.chkLowers.UseVisualStyleBackColor = true;
            this.chkLowers.CheckedChanged += new System.EventHandler(this.OnPoolsCheckedChanged);
            // 
            // chkUppers
            // 
            this.chkUppers.AutoSize = true;
            this.chkUppers.Checked = true;
            this.chkUppers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUppers.Location = new System.Drawing.Point(80, 130);
            this.chkUppers.Name = "chkUppers";
            this.chkUppers.Size = new System.Drawing.Size(93, 17);
            this.chkUppers.TabIndex = 8;
            this.chkUppers.Text = "Capital Letters";
            this.tooltip.SetToolTip(this.chkUppers, "The password generator should include capital letters.");
            this.chkUppers.UseVisualStyleBackColor = true;
            this.chkUppers.CheckedChanged += new System.EventHandler(this.OnPoolsCheckedChanged);
            // 
            // lblPhrase
            // 
            this.lblPhrase.AutoSize = true;
            this.lblPhrase.Location = new System.Drawing.Point(8, 107);
            this.lblPhrase.Name = "lblPhrase";
            this.lblPhrase.Size = new System.Drawing.Size(43, 13);
            this.lblPhrase.TabIndex = 6;
            this.lblPhrase.Text = "&Phrase:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(8, 80);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "&Amount:";
            // 
            // grpPasswords
            // 
            this.grpPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPasswords.Controls.Add(this.chbDelete);
            this.grpPasswords.Controls.Add(this.lstPasswords);
            this.grpPasswords.Location = new System.Drawing.Point(0, 239);
            this.grpPasswords.Name = "grpPasswords";
            this.grpPasswords.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.grpPasswords.Size = new System.Drawing.Size(500, 161);
            this.grpPasswords.TabIndex = 1;
            this.grpPasswords.TabStop = false;
            this.grpPasswords.Text = "Passwords";
            // 
            // chbDelete
            // 
            this.chbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDelete.AutoSize = true;
            this.chbDelete.Location = new System.Drawing.Point(8, 25);
            this.chbDelete.Name = "chbDelete";
            this.chbDelete.Size = new System.Drawing.Size(131, 17);
            this.chbDelete.TabIndex = 0;
            this.chbDelete.Text = "&Delete existing results.";
            this.chbDelete.UseVisualStyleBackColor = true;
            // 
            // lstPasswords
            // 
            this.lstPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPasswords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPasswords.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPasswords.HorizontalScrollbar = true;
            this.lstPasswords.IntegralHeight = false;
            this.lstPasswords.ItemHeight = 19;
            this.lstPasswords.Items.AddRange(new object[] {
            "1111",
            "2222",
            "3333",
            "4444"});
            this.lstPasswords.Location = new System.Drawing.Point(8, 48);
            this.lstPasswords.Name = "lstPasswords";
            this.lstPasswords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPasswords.Size = new System.Drawing.Size(484, 103);
            this.lstPasswords.TabIndex = 1;
            this.lstPasswords.SelectedIndexChanged += new System.EventHandler(this.OnPasswordsSelectedIndexChanged);
            // 
            // numAmount
            // 
            this.numAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAmount.Location = new System.Drawing.Point(80, 78);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(412, 20);
            this.numAmount.TabIndex = 5;
            this.tooltip.SetToolTip(this.numAmount, "The number of passwords to be generated.");
            this.numAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAmount.ValueChanged += new System.EventHandler(this.OnNumberValueChanged);
            // 
            // numLength
            // 
            this.numLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numLength.Location = new System.Drawing.Point(80, 52);
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(412, 20);
            this.numLength.TabIndex = 3;
            this.tooltip.SetToolTip(this.numLength, "The number of characters.");
            this.numLength.ValueChanged += new System.EventHandler(this.OnNumberValueChanged);
            // 
            // CommonGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPasswords);
            this.Controls.Add(this.group1);
            this.Name = "CommonGeneratorControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.grpPasswords.ResumeLayout(false);
            this.grpPasswords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblTypes;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label txtRemarks;
        private NumberUpDown numLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.CheckBox chkExtras;
        private System.Windows.Forms.CheckBox chkDigits;
        private System.Windows.Forms.CheckBox chkLowers;
        private System.Windows.Forms.CheckBox chkUppers;
        private NumberUpDown numAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox grpPasswords;
        private System.Windows.Forms.ListBox lstPasswords;
        private System.Windows.Forms.CheckBox chbDelete;
        private System.Windows.Forms.TextBox txtPhrase;
        private System.Windows.Forms.Label lblPhrase;
    }
}
