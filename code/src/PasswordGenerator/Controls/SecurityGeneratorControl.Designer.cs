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
    partial class SecurityGeneratorControl
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
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.txtGuesses = new System.Windows.Forms.Label();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.lblGuesses = new System.Windows.Forms.Label();
            this.lblScenario = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lblHead = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.layout1 = new System.Windows.Forms.TableLayoutPanel();
            this.panWarning = new System.Windows.Forms.Panel();
            this.cntEntropy = new Plexdata.PasswordGenerator.Controls.EntropyControl();
            this.cntDuration = new Plexdata.PasswordGenerator.Controls.DurationControl();
            this.group1.SuspendLayout();
            this.layout1.SuspendLayout();
            this.panWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(8, 29);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "&Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(80, 25);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(412, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Tag = "Source Password...";
            this.tooltip.SetToolTip(this.txtPassword, "Type or paste a password to be verified.");
            // 
            // group1
            // 
            this.group1.Controls.Add(this.txtGuesses);
            this.group1.Controls.Add(this.cmbScenario);
            this.group1.Controls.Add(this.lblGuesses);
            this.group1.Controls.Add(this.lblScenario);
            this.group1.Controls.Add(this.lblPassword);
            this.group1.Controls.Add(this.txtPassword);
            this.group1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Margin = new System.Windows.Forms.Padding(0);
            this.group1.Name = "group1";
            this.group1.Padding = new System.Windows.Forms.Padding(5, 9, 5, 5);
            this.group1.Size = new System.Drawing.Size(500, 108);
            this.group1.TabIndex = 2;
            this.group1.TabStop = false;
            this.group1.Text = "Source Information";
            // 
            // txtGuesses
            // 
            this.txtGuesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuesses.Location = new System.Drawing.Point(80, 78);
            this.txtGuesses.Margin = new System.Windows.Forms.Padding(3);
            this.txtGuesses.Name = "txtGuesses";
            this.txtGuesses.Size = new System.Drawing.Size(412, 20);
            this.txtGuesses.TabIndex = 4;
            this.txtGuesses.Text = "0";
            this.txtGuesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tooltip.SetToolTip(this.txtGuesses, "Number of guesses a computer system can perform per second.");
            // 
            // cmbScenario
            // 
            this.cmbScenario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Location = new System.Drawing.Point(80, 51);
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.Size = new System.Drawing.Size(412, 21);
            this.cmbScenario.TabIndex = 3;
            this.cmbScenario.SelectedValueChanged += new System.EventHandler(this.OnScenarioSelectedValueChanged);
            // 
            // lblGuesses
            // 
            this.lblGuesses.AutoSize = true;
            this.lblGuesses.Location = new System.Drawing.Point(8, 82);
            this.lblGuesses.Name = "lblGuesses";
            this.lblGuesses.Size = new System.Drawing.Size(51, 13);
            this.lblGuesses.TabIndex = 2;
            this.lblGuesses.Text = "Guesses:";
            // 
            // lblScenario
            // 
            this.lblScenario.AutoSize = true;
            this.lblScenario.Location = new System.Drawing.Point(8, 55);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(52, 13);
            this.lblScenario.TabIndex = 2;
            this.lblScenario.Text = "&Scenario:";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblHead.Location = new System.Drawing.Point(3, 5);
            this.lblHead.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(68, 17);
            this.lblHead.TabIndex = 4;
            this.lblHead.Text = "Attention:";
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(81, 5);
            this.lblText.Margin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(419, 62);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Be aware, all information shown on this view are based on assumptions! Therefore," +
    " use this information carefully.";
            // 
            // layout1
            // 
            this.layout1.ColumnCount = 1;
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout1.Controls.Add(this.panWarning, 0, 3);
            this.layout1.Controls.Add(this.group1, 0, 0);
            this.layout1.Controls.Add(this.cntEntropy, 0, 1);
            this.layout1.Controls.Add(this.cntDuration, 0, 2);
            this.layout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout1.Location = new System.Drawing.Point(0, 0);
            this.layout1.Margin = new System.Windows.Forms.Padding(0);
            this.layout1.Name = "layout1";
            this.layout1.RowCount = 4;
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layout1.Size = new System.Drawing.Size(500, 400);
            this.layout1.TabIndex = 7;
            // 
            // panWarning
            // 
            this.panWarning.Controls.Add(this.lblText);
            this.panWarning.Controls.Add(this.lblHead);
            this.panWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panWarning.Location = new System.Drawing.Point(0, 333);
            this.panWarning.Margin = new System.Windows.Forms.Padding(0);
            this.panWarning.Name = "panWarning";
            this.panWarning.Size = new System.Drawing.Size(500, 67);
            this.panWarning.TabIndex = 8;
            // 
            // cntEntropy
            // 
            this.cntEntropy.BackColor = System.Drawing.Color.Transparent;
            this.cntEntropy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntEntropy.Entropy = 0D;
            this.cntEntropy.Location = new System.Drawing.Point(0, 108);
            this.cntEntropy.Margin = new System.Windows.Forms.Padding(0);
            this.cntEntropy.Name = "cntEntropy";
            this.cntEntropy.Percent = 0D;
            this.cntEntropy.Size = new System.Drawing.Size(500, 154);
            this.cntEntropy.Strength = Plexdata.Utilities.Password.Defines.Strength.Unknown;
            this.cntEntropy.Summary = null;
            this.cntEntropy.TabIndex = 6;
            // 
            // cntDuration
            // 
            this.cntDuration.BackColor = System.Drawing.Color.Transparent;
            this.cntDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntDuration.Location = new System.Drawing.Point(0, 262);
            this.cntDuration.Margin = new System.Windows.Forms.Padding(0);
            this.cntDuration.Name = "cntDuration";
            this.cntDuration.Size = new System.Drawing.Size(500, 71);
            this.cntDuration.TabIndex = 3;
            // 
            // SecurityGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.layout1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SecurityGeneratorControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.layout1.ResumeLayout(false);
            this.panWarning.ResumeLayout(false);
            this.panWarning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.Label lblScenario;
        private DurationControl cntDuration;
        private System.Windows.Forms.Label txtGuesses;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblGuesses;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label lblText;
        private EntropyControl cntEntropy;
        private System.Windows.Forms.TableLayoutPanel layout1;
        private System.Windows.Forms.Panel panWarning;
    }
}
