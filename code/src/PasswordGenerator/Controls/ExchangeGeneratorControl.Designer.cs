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
    partial class ExchangeGeneratorControl
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.txtSource = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.txtResult = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.grpAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(8, 57);
            this.lblResult.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(60, 26);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "&Result";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(8, 25);
            this.lblSource.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(60, 26);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "&Source";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpAttributes
            // 
            this.grpAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAttributes.Controls.Add(this.lblResult);
            this.grpAttributes.Controls.Add(this.txtSource);
            this.grpAttributes.Controls.Add(this.txtResult);
            this.grpAttributes.Controls.Add(this.lblSource);
            this.grpAttributes.Location = new System.Drawing.Point(0, 0);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.grpAttributes.Size = new System.Drawing.Size(500, 100);
            this.grpAttributes.TabIndex = 2;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Values";
            // 
            // txtSource
            // 
            this.txtSource.AcceptSpaces = true;
            this.txtSource.AllowMultiple = true;
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(76, 25);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(416, 26);
            this.txtSource.TabIndex = 1;
            this.txtSource.Tag = "Source Password...";
            // 
            // txtResult
            // 
            this.txtResult.AcceptSpaces = true;
            this.txtResult.AllowMultiple = true;
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(76, 57);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(416, 26);
            this.txtResult.TabIndex = 3;
            this.txtResult.Tag = "Result Password...";
            // 
            // ExchangeGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpAttributes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExchangeGeneratorControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblResult;
        private LimitedTextBox txtSource;
        private System.Windows.Forms.Label lblSource;
        private LimitedTextBox txtResult;
        private System.Windows.Forms.GroupBox grpAttributes;
    }
}
