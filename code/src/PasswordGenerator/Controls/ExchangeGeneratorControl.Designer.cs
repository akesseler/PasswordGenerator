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
            this.components = new System.ComponentModel.Container();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.txtSource = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.txtResult = new Plexdata.PasswordGenerator.Controls.LimitedTextBox();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.panMessage = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.LinkLabel();
            this.lblHead = new System.Windows.Forms.Label();
            this.grpAttributes.SuspendLayout();
            this.panMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(8, 55);
            this.lblResult.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "&Result:";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(8, 29);
            this.lblSource.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(56, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "&Password:";
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
            this.grpAttributes.Size = new System.Drawing.Size(500, 82);
            this.grpAttributes.TabIndex = 0;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Exchange Values";
            // 
            // txtSource
            // 
            this.txtSource.AcceptSpaces = true;
            this.txtSource.AllowMultiple = true;
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(80, 25);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(412, 20);
            this.txtSource.TabIndex = 1;
            this.txtSource.Tag = "Source Password...";
            this.tipMain.SetToolTip(this.txtSource, "Type or paste a password to be exchanged.");
            // 
            // txtResult
            // 
            this.txtResult.AcceptSpaces = true;
            this.txtResult.AllowMultiple = true;
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(80, 51);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(412, 20);
            this.txtResult.TabIndex = 3;
            this.txtResult.Tag = "Result Password...";
            this.tipMain.SetToolTip(this.txtResult, "Run generator to exchange letters of the source password.");
            // 
            // panMessage
            // 
            this.panMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMessage.Controls.Add(this.lblText);
            this.panMessage.Controls.Add(this.lblHead);
            this.panMessage.Location = new System.Drawing.Point(0, 88);
            this.panMessage.Name = "panMessage";
            this.panMessage.Size = new System.Drawing.Size(500, 70);
            this.panMessage.TabIndex = 1;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.LinkArea = new System.Windows.Forms.LinkArea(61, 8);
            this.lblText.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblText.Location = new System.Drawing.Point(80, 4);
            this.lblText.Margin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(412, 66);
            this.lblText.TabIndex = 1;
            this.lblText.TabStop = true;
            this.lblText.Text = "You may adjust the characters to be exchanged in the program settings.";
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
            // ExchangeGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panMessage);
            this.Controls.Add(this.grpAttributes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExchangeGeneratorControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.panMessage.ResumeLayout(false);
            this.panMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblResult;
        private LimitedTextBox txtSource;
        private System.Windows.Forms.Label lblSource;
        private LimitedTextBox txtResult;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.Panel panMessage;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.LinkLabel lblText;
    }
}
