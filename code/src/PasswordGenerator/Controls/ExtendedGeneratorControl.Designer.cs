﻿/*
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

namespace Plexdata.PasswordGenerator.Controls
{
    partial class ExtendedGeneratorControl
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
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.chbDelete = new System.Windows.Forms.CheckBox();
            this.grpPasswords = new System.Windows.Forms.GroupBox();
            this.lstPasswords = new System.Windows.Forms.ListBox();
            this.numAmount = new Plexdata.PasswordGenerator.Controls.NumberUpDown();
            this.numLength = new Plexdata.PasswordGenerator.Controls.NumberUpDown();
            this.grpAttributes.SuspendLayout();
            this.grpPasswords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAttributes
            // 
            this.grpAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAttributes.Controls.Add(this.numAmount);
            this.grpAttributes.Controls.Add(this.lblAmount);
            this.grpAttributes.Controls.Add(this.numLength);
            this.grpAttributes.Controls.Add(this.lblLength);
            this.grpAttributes.Location = new System.Drawing.Point(0, 0);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.grpAttributes.Size = new System.Drawing.Size(500, 81);
            this.grpAttributes.TabIndex = 0;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Attributes";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(8, 55);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "&Amount:";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(8, 29);
            this.lblLength.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "&Length:";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.chbDelete.CheckedChanged += new System.EventHandler(this.OnEditDeleteChanged);
            // 
            // grpPasswords
            // 
            this.grpPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPasswords.Controls.Add(this.chbDelete);
            this.grpPasswords.Controls.Add(this.lstPasswords);
            this.grpPasswords.Location = new System.Drawing.Point(0, 87);
            this.grpPasswords.Name = "grpPasswords";
            this.grpPasswords.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.grpPasswords.Size = new System.Drawing.Size(500, 313);
            this.grpPasswords.TabIndex = 1;
            this.grpPasswords.TabStop = false;
            this.grpPasswords.Text = "Passwords";
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
            this.lstPasswords.Size = new System.Drawing.Size(484, 256);
            this.lstPasswords.TabIndex = 1;
            this.lstPasswords.SelectedIndexChanged += new System.EventHandler(this.OnPasswordsSelectedIndexChanged);
            // 
            // numAmount
            // 
            this.numAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAmount.Location = new System.Drawing.Point(80, 51);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(412, 20);
            this.numAmount.TabIndex = 3;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.ValueChanged += new System.EventHandler(this.OnEditAmountChanged);
            // 
            // numLength
            // 
            this.numLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numLength.Location = new System.Drawing.Point(80, 25);
            this.numLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(412, 20);
            this.numLength.TabIndex = 1;
            this.numLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numLength.ValueChanged += new System.EventHandler(this.OnEditLengthChanged);
            // 
            // ExtendedGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPasswords);
            this.Controls.Add(this.grpAttributes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExtendedGeneratorControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.grpPasswords.ResumeLayout(false);
            this.grpPasswords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.CheckBox chbDelete;
        private NumberUpDown numAmount;
        private System.Windows.Forms.Label lblAmount;
        private NumberUpDown numLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.GroupBox grpPasswords;
        private System.Windows.Forms.ListBox lstPasswords;
    }
}
