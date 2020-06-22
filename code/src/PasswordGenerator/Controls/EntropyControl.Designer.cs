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
    partial class EntropyControl
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
            this.group1 = new System.Windows.Forms.GroupBox();
            this.txtSummary = new System.Windows.Forms.Label();
            this.txtEntropy = new System.Windows.Forms.Label();
            this.lblEntropy = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.prgStrength = new Plexdata.PasswordGenerator.Controls.StrengthPanel();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group1.BackColor = System.Drawing.Color.Transparent;
            this.group1.Controls.Add(this.txtSummary);
            this.group1.Controls.Add(this.txtEntropy);
            this.group1.Controls.Add(this.prgStrength);
            this.group1.Controls.Add(this.lblEntropy);
            this.group1.Controls.Add(this.lblSummary);
            this.group1.Controls.Add(this.lblStrength);
            this.group1.Location = new System.Drawing.Point(3, 3);
            this.group1.Margin = new System.Windows.Forms.Padding(0);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(5);
            this.group1.Size = new System.Drawing.Size(450, 144);
            this.group1.TabIndex = 0;
            this.group1.TabStop = false;
            this.group1.Text = "Calculated Password Entropy";
            // 
            // txtSummary
            // 
            this.txtSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummary.Location = new System.Drawing.Point(80, 78);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(362, 60);
            this.txtSummary.TabIndex = 9;
            this.txtSummary.Text = "???";
            // 
            // txtEntropy
            // 
            this.txtEntropy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntropy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntropy.Location = new System.Drawing.Point(80, 25);
            this.txtEntropy.Margin = new System.Windows.Forms.Padding(3);
            this.txtEntropy.Name = "txtEntropy";
            this.txtEntropy.Size = new System.Drawing.Size(362, 23);
            this.txtEntropy.TabIndex = 8;
            this.txtEntropy.Text = "???";
            this.txtEntropy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEntropy
            // 
            this.lblEntropy.AutoSize = true;
            this.lblEntropy.Location = new System.Drawing.Point(8, 29);
            this.lblEntropy.Name = "lblEntropy";
            this.lblEntropy.Size = new System.Drawing.Size(46, 13);
            this.lblEntropy.TabIndex = 6;
            this.lblEntropy.Text = "Entropy:";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(8, 82);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(53, 13);
            this.lblSummary.TabIndex = 6;
            this.lblSummary.Text = "Summary:";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(8, 55);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(50, 13);
            this.lblStrength.TabIndex = 6;
            this.lblStrength.Text = "Strength:";
            // 
            // prgStrength
            // 
            this.prgStrength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgStrength.BackColor = System.Drawing.Color.Transparent;
            this.prgStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prgStrength.ForeColor = System.Drawing.SystemColors.WindowText;
            this.prgStrength.Label = "";
            this.prgStrength.Location = new System.Drawing.Point(80, 51);
            this.prgStrength.Name = "prgStrength";
            this.prgStrength.Padding = new System.Windows.Forms.Padding(1);
            this.prgStrength.Percent = 0D;
            this.prgStrength.Size = new System.Drawing.Size(362, 23);
            this.prgStrength.TabIndex = 7;
            this.prgStrength.Value = 0;
            // 
            // EntropyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.group1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EntropyControl";
            this.Size = new System.Drawing.Size(450, 150);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group1;
        private StrengthPanel prgStrength;
        private System.Windows.Forms.Label lblEntropy;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label txtEntropy;
        private System.Windows.Forms.Label txtSummary;
        private System.Windows.Forms.Label lblSummary;
    }
}
