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
    partial class PasswordInspectionControl
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.Label();
            this.panMessage = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.LinkLabel();
            this.lblHead = new System.Windows.Forms.Label();
            this.group1.SuspendLayout();
            this.panMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(80, 25);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(412, 20);
            this.txtSource.TabIndex = 0;
            this.txtSource.Tag = "Source Password...";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(8, 29);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(56, 13);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Password:";
            // 
            // group1
            // 
            this.group1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group1.Controls.Add(this.lblResult);
            this.group1.Controls.Add(this.txtResult);
            this.group1.Controls.Add(this.lblSource);
            this.group1.Controls.Add(this.txtSource);
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Margin = new System.Windows.Forms.Padding(0);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.group1.Size = new System.Drawing.Size(500, 132);
            this.group1.TabIndex = 2;
            this.group1.TabStop = false;
            this.group1.Text = "Online Check";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(8, 55);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 14;
            this.lblResult.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Location = new System.Drawing.Point(80, 52);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(412, 70);
            this.txtResult.TabIndex = 15;
            this.txtResult.Text = "???";
            // 
            // panMessage
            // 
            this.panMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMessage.Controls.Add(this.lblText);
            this.panMessage.Controls.Add(this.lblHead);
            this.panMessage.Location = new System.Drawing.Point(0, 135);
            this.panMessage.Name = "panMessage";
            this.panMessage.Size = new System.Drawing.Size(500, 262);
            this.panMessage.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.LinkArea = new System.Windows.Forms.LinkArea(22, 10);
            this.lblText.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblText.Location = new System.Drawing.Point(80, 4);
            this.lblText.Margin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(412, 258);
            this.lblText.TabIndex = 1;
            this.lblText.TabStop = true;
            this.lblText.Text = "Designer data... The real value is set in the code.";
            this.lblText.UseCompatibleTextRendering = true;
            this.lblText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSettingsLinkClicked);
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHead.Location = new System.Drawing.Point(3, 5);
            this.lblHead.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(42, 17);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "Note:";
            // 
            // PasswordInspectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panMessage);
            this.Controls.Add(this.group1);
            this.Name = "PasswordInspectionControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.panMessage.ResumeLayout(false);
            this.panMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label txtResult;
        private System.Windows.Forms.Panel panMessage;
        private System.Windows.Forms.LinkLabel lblText;
        private System.Windows.Forms.Label lblHead;
    }
}
