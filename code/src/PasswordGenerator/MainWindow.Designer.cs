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

namespace Plexdata.PasswordGenerator
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.tbsMain = new System.Windows.Forms.ToolStrip();
            this.tbbExit = new System.Windows.Forms.ToolStripButton();
            this.tssMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbPlay = new System.Windows.Forms.ToolStripButton();
            this.tssMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbSettings = new System.Windows.Forms.ToolStripButton();
            this.tbbBulb = new System.Windows.Forms.ToolStripSplitButton();
            this.tbmSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbmInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.sbsMain = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvcContent = new Plexdata.PasswordGenerator.Controls.TabViewControl();
            this.tbpCommon = new System.Windows.Forms.TabPage();
            this.gusCommon = new Plexdata.PasswordGenerator.Controls.CommonGeneratorControl();
            this.tbpQwerty = new System.Windows.Forms.TabPage();
            this.gusQwerty = new Plexdata.PasswordGenerator.Controls.QwertyGeneratorControl();
            this.tbpExchange = new System.Windows.Forms.TabPage();
            this.gusExchange = new Plexdata.PasswordGenerator.Controls.ExchangeGeneratorControl();
            this.tbpExtended = new System.Windows.Forms.TabPage();
            this.gusExtended = new Plexdata.PasswordGenerator.Controls.ExtendedGeneratorControl();
            this.tbpSecurity = new System.Windows.Forms.TabPage();
            this.gusSecurity = new Plexdata.PasswordGenerator.Controls.SecurityGeneratorControl();
            this.tbpInspection = new System.Windows.Forms.TabPage();
            this.gusInspection = new Plexdata.PasswordGenerator.Controls.PasswordInspectionControl();
            this.tbsMain.SuspendLayout();
            this.sbsMain.SuspendLayout();
            this.tvcContent.SuspendLayout();
            this.tbpCommon.SuspendLayout();
            this.tbpQwerty.SuspendLayout();
            this.tbpExchange.SuspendLayout();
            this.tbpExtended.SuspendLayout();
            this.tbpSecurity.SuspendLayout();
            this.tbpInspection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsMain
            // 
            this.tbsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tbsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbExit,
            this.tssMain1,
            this.tbbSave,
            this.tbbPlay,
            this.tssMain2,
            this.tbbSettings,
            this.tbbBulb});
            this.tbsMain.Location = new System.Drawing.Point(0, 0);
            this.tbsMain.Name = "tbsMain";
            this.tbsMain.Padding = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.tbsMain.Size = new System.Drawing.Size(484, 41);
            this.tbsMain.TabIndex = 0;
            // 
            // tbbExit
            // 
            this.tbbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbExit.Image = global::Plexdata.PasswordGenerator.Properties.Resources.exit_28x28;
            this.tbbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbExit.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tbbExit.Name = "tbbExit";
            this.tbbExit.Size = new System.Drawing.Size(32, 32);
            this.tbbExit.Text = "Exit";
            this.tbbExit.ToolTipText = "Close window and exit program.";
            this.tbbExit.Click += new System.EventHandler(this.OnExitButtonClick);
            // 
            // tssMain1
            // 
            this.tssMain1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tssMain1.Name = "tssMain1";
            this.tssMain1.Size = new System.Drawing.Size(6, 35);
            // 
            // tbbSave
            // 
            this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSave.Image = global::Plexdata.PasswordGenerator.Properties.Resources.save_28x28;
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(32, 32);
            this.tbbSave.Text = "Save";
            this.tbbSave.ToolTipText = "Save current passwords into an external file.";
            this.tbbSave.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // tbbPlay
            // 
            this.tbbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPlay.Image = global::Plexdata.PasswordGenerator.Properties.Resources.play_28x28;
            this.tbbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPlay.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tbbPlay.Name = "tbbPlay";
            this.tbbPlay.Size = new System.Drawing.Size(32, 32);
            this.tbbPlay.Text = "Play";
            this.tbbPlay.ToolTipText = "Run generator with current settings.";
            this.tbbPlay.Click += new System.EventHandler(this.OnPlayButtonClick);
            // 
            // tssMain2
            // 
            this.tssMain2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tssMain2.Name = "tssMain2";
            this.tssMain2.Size = new System.Drawing.Size(6, 35);
            // 
            // tbbSettings
            // 
            this.tbbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSettings.Image = global::Plexdata.PasswordGenerator.Properties.Resources.settings_28x28;
            this.tbbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSettings.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tbbSettings.Name = "tbbSettings";
            this.tbbSettings.Size = new System.Drawing.Size(32, 32);
            this.tbbSettings.Text = "Settings";
            this.tbbSettings.ToolTipText = "Show settings dialog.";
            this.tbbSettings.Click += new System.EventHandler(this.OnSettingsButtonClick);
            // 
            // tbbBulb
            // 
            this.tbbBulb.AutoToolTip = false;
            this.tbbBulb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbBulb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbmSummary,
            this.tbmInfo});
            this.tbbBulb.Image = global::Plexdata.PasswordGenerator.Properties.Resources.bulb_28x28;
            this.tbbBulb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbBulb.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tbbBulb.Name = "tbbBulb";
            this.tbbBulb.Size = new System.Drawing.Size(44, 32);
            this.tbbBulb.Text = "Bulb";
            this.tbbBulb.ButtonClick += new System.EventHandler(this.OnBulbButtonClick);
            // 
            // tbmSummary
            // 
            this.tbmSummary.Image = global::Plexdata.PasswordGenerator.Properties.Resources.help_16x16;
            this.tbmSummary.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbmSummary.Name = "tbmSummary";
            this.tbmSummary.Size = new System.Drawing.Size(180, 22);
            this.tbmSummary.Text = "Summary...";
            this.tbmSummary.Click += new System.EventHandler(this.OnMenuSummaryClick);
            // 
            // tbmInfo
            // 
            this.tbmInfo.Image = global::Plexdata.PasswordGenerator.Properties.Resources.info_16x16;
            this.tbmInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbmInfo.Name = "tbmInfo";
            this.tbmInfo.Size = new System.Drawing.Size(180, 22);
            this.tbmInfo.Text = "Info...";
            this.tbmInfo.Click += new System.EventHandler(this.OnMenuInfoClick);
            // 
            // sbsMain
            // 
            this.sbsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.tssValue});
            this.sbsMain.Location = new System.Drawing.Point(0, 489);
            this.sbsMain.Name = "sbsMain";
            this.sbsMain.Size = new System.Drawing.Size(484, 22);
            this.sbsMain.TabIndex = 3;
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(22, 17);
            this.tssLabel.Text = "???";
            // 
            // tssValue
            // 
            this.tssValue.Name = "tssValue";
            this.tssValue.Size = new System.Drawing.Size(22, 17);
            this.tssValue.Text = "???";
            // 
            // tvcContent
            // 
            this.tvcContent.Controls.Add(this.tbpCommon);
            this.tvcContent.Controls.Add(this.tbpQwerty);
            this.tvcContent.Controls.Add(this.tbpExchange);
            this.tvcContent.Controls.Add(this.tbpExtended);
            this.tvcContent.Controls.Add(this.tbpSecurity);
            this.tvcContent.Controls.Add(this.tbpInspection);
            this.tvcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvcContent.Location = new System.Drawing.Point(0, 41);
            this.tvcContent.Name = "tvcContent";
            this.tvcContent.SelectedIndex = 0;
            this.tvcContent.Size = new System.Drawing.Size(484, 448);
            this.tvcContent.TabIndex = 2;
            this.tvcContent.SelectedIndexChanged += new System.EventHandler(this.OnContentViewSelectedIndexChanged);
            // 
            // tbpCommon
            // 
            this.tbpCommon.Controls.Add(this.gusCommon);
            this.tbpCommon.Location = new System.Drawing.Point(4, 22);
            this.tbpCommon.Margin = new System.Windows.Forms.Padding(0);
            this.tbpCommon.Name = "tbpCommon";
            this.tbpCommon.Padding = new System.Windows.Forms.Padding(5);
            this.tbpCommon.Size = new System.Drawing.Size(476, 422);
            this.tbpCommon.TabIndex = 0;
            this.tbpCommon.Text = "Common";
            this.tbpCommon.UseVisualStyleBackColor = true;
            // 
            // gusCommon
            // 
            this.gusCommon.BackColor = System.Drawing.Color.Transparent;
            this.gusCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusCommon.Location = new System.Drawing.Point(5, 5);
            this.gusCommon.Margin = new System.Windows.Forms.Padding(0);
            this.gusCommon.Name = "gusCommon";
            this.gusCommon.Size = new System.Drawing.Size(466, 412);
            this.gusCommon.TabIndex = 0;
            // 
            // tbpQwerty
            // 
            this.tbpQwerty.Controls.Add(this.gusQwerty);
            this.tbpQwerty.Location = new System.Drawing.Point(4, 22);
            this.tbpQwerty.Margin = new System.Windows.Forms.Padding(0);
            this.tbpQwerty.Name = "tbpQwerty";
            this.tbpQwerty.Padding = new System.Windows.Forms.Padding(5);
            this.tbpQwerty.Size = new System.Drawing.Size(476, 422);
            this.tbpQwerty.TabIndex = 4;
            this.tbpQwerty.Text = "Qwerty";
            this.tbpQwerty.UseVisualStyleBackColor = true;
            // 
            // gusQwerty
            // 
            this.gusQwerty.BackColor = System.Drawing.Color.Transparent;
            this.gusQwerty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusQwerty.Location = new System.Drawing.Point(5, 5);
            this.gusQwerty.Margin = new System.Windows.Forms.Padding(0);
            this.gusQwerty.Name = "gusQwerty";
            this.gusQwerty.Size = new System.Drawing.Size(466, 412);
            this.gusQwerty.TabIndex = 0;
            // 
            // tbpExchange
            // 
            this.tbpExchange.Controls.Add(this.gusExchange);
            this.tbpExchange.Location = new System.Drawing.Point(4, 22);
            this.tbpExchange.Margin = new System.Windows.Forms.Padding(0);
            this.tbpExchange.Name = "tbpExchange";
            this.tbpExchange.Padding = new System.Windows.Forms.Padding(5);
            this.tbpExchange.Size = new System.Drawing.Size(476, 422);
            this.tbpExchange.TabIndex = 2;
            this.tbpExchange.Text = "Exchange";
            this.tbpExchange.UseVisualStyleBackColor = true;
            // 
            // gusExchange
            // 
            this.gusExchange.BackColor = System.Drawing.Color.Transparent;
            this.gusExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusExchange.Location = new System.Drawing.Point(5, 5);
            this.gusExchange.Margin = new System.Windows.Forms.Padding(0);
            this.gusExchange.Name = "gusExchange";
            this.gusExchange.Size = new System.Drawing.Size(466, 412);
            this.gusExchange.TabIndex = 0;
            // 
            // tbpExtended
            // 
            this.tbpExtended.Controls.Add(this.gusExtended);
            this.tbpExtended.Location = new System.Drawing.Point(4, 22);
            this.tbpExtended.Margin = new System.Windows.Forms.Padding(0);
            this.tbpExtended.Name = "tbpExtended";
            this.tbpExtended.Padding = new System.Windows.Forms.Padding(5);
            this.tbpExtended.Size = new System.Drawing.Size(476, 422);
            this.tbpExtended.TabIndex = 1;
            this.tbpExtended.Text = "Extended";
            this.tbpExtended.UseVisualStyleBackColor = true;
            // 
            // gusExtended
            // 
            this.gusExtended.BackColor = System.Drawing.Color.Transparent;
            this.gusExtended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusExtended.Location = new System.Drawing.Point(5, 5);
            this.gusExtended.Margin = new System.Windows.Forms.Padding(0);
            this.gusExtended.Name = "gusExtended";
            this.gusExtended.Size = new System.Drawing.Size(466, 412);
            this.gusExtended.TabIndex = 1;
            // 
            // tbpSecurity
            // 
            this.tbpSecurity.Controls.Add(this.gusSecurity);
            this.tbpSecurity.Location = new System.Drawing.Point(4, 22);
            this.tbpSecurity.Margin = new System.Windows.Forms.Padding(0);
            this.tbpSecurity.Name = "tbpSecurity";
            this.tbpSecurity.Padding = new System.Windows.Forms.Padding(5);
            this.tbpSecurity.Size = new System.Drawing.Size(476, 422);
            this.tbpSecurity.TabIndex = 3;
            this.tbpSecurity.Text = "Security";
            this.tbpSecurity.UseVisualStyleBackColor = true;
            // 
            // gusSecurity
            // 
            this.gusSecurity.BackColor = System.Drawing.Color.Transparent;
            this.gusSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusSecurity.Location = new System.Drawing.Point(5, 5);
            this.gusSecurity.Margin = new System.Windows.Forms.Padding(0);
            this.gusSecurity.Name = "gusSecurity";
            this.gusSecurity.Size = new System.Drawing.Size(466, 412);
            this.gusSecurity.TabIndex = 0;
            // 
            // tbpInspection
            // 
            this.tbpInspection.Controls.Add(this.gusInspection);
            this.tbpInspection.Location = new System.Drawing.Point(4, 22);
            this.tbpInspection.Margin = new System.Windows.Forms.Padding(0);
            this.tbpInspection.Name = "tbpInspection";
            this.tbpInspection.Padding = new System.Windows.Forms.Padding(5);
            this.tbpInspection.Size = new System.Drawing.Size(476, 422);
            this.tbpInspection.TabIndex = 5;
            this.tbpInspection.Text = "Inspection";
            this.tbpInspection.UseVisualStyleBackColor = true;
            // 
            // gusInspection
            // 
            this.gusInspection.BackColor = System.Drawing.Color.Transparent;
            this.gusInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gusInspection.Location = new System.Drawing.Point(5, 5);
            this.gusInspection.Margin = new System.Windows.Forms.Padding(0);
            this.gusInspection.Name = "gusInspection";
            this.gusInspection.Size = new System.Drawing.Size(466, 412);
            this.gusInspection.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.tvcContent);
            this.Controls.Add(this.tbsMain);
            this.Controls.Add(this.sbsMain);
            this.MinimumSize = new System.Drawing.Size(500, 550);
            this.Name = "MainWindow";
            this.Text = "Password Generator";
            this.tbsMain.ResumeLayout(false);
            this.tbsMain.PerformLayout();
            this.sbsMain.ResumeLayout(false);
            this.sbsMain.PerformLayout();
            this.tvcContent.ResumeLayout(false);
            this.tbpCommon.ResumeLayout(false);
            this.tbpQwerty.ResumeLayout(false);
            this.tbpExchange.ResumeLayout(false);
            this.tbpExtended.ResumeLayout(false);
            this.tbpSecurity.ResumeLayout(false);
            this.tbpInspection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbsMain;
        private System.Windows.Forms.ToolStripButton tbbExit;
        private System.Windows.Forms.ToolStripSeparator tssMain1;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbPlay;
        private System.Windows.Forms.ToolStripSeparator tssMain2;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.ToolStripButton tbbSettings;
        private Plexdata.PasswordGenerator.Controls.TabViewControl tvcContent;
        private System.Windows.Forms.TabPage tbpCommon;
        private System.Windows.Forms.TabPage tbpExtended;
        private System.Windows.Forms.TabPage tbpExchange;
        private Controls.ExtendedGeneratorControl gusExtended;
        private Controls.ExchangeGeneratorControl gusExchange;
        private Controls.CommonGeneratorControl gusCommon;
        private System.Windows.Forms.TabPage tbpSecurity;
        private Controls.SecurityGeneratorControl gusSecurity;
        private System.Windows.Forms.StatusStrip sbsMain;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssValue;
        private System.Windows.Forms.TabPage tbpQwerty;
        private Controls.QwertyGeneratorControl gusQwerty;
        private System.Windows.Forms.TabPage tbpInspection;
        private Controls.PasswordInspectionControl gusInspection;
        private System.Windows.Forms.ToolStripSplitButton tbbBulb;
        private System.Windows.Forms.ToolStripMenuItem tbmInfo;
        private System.Windows.Forms.ToolStripMenuItem tbmSummary;
    }
}

