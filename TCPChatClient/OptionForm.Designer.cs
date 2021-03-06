﻿namespace Chat_Client
{
    partial class OptionForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.ServerTab = new System.Windows.Forms.TabPage();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.serverLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.personTab = new System.Windows.Forms.TabPage();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.encryptCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ServerTab.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.personTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(311, 241);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.portTextBox);
            this.ServerTab.Controls.Add(this.portLabel);
            this.ServerTab.Controls.Add(this.serverTextBox);
            this.ServerTab.Controls.Add(this.serverLabel);
            this.ServerTab.Location = new System.Drawing.Point(4, 22);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServerTab.Size = new System.Drawing.Size(374, 210);
            this.ServerTab.TabIndex = 0;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(184, 6);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(75, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(149, 9);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(69, 6);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(74, 20);
            this.serverTextBox.TabIndex = 1;
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(6, 9);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(54, 13);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Server IP:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ServerTab);
            this.tabControl.Controls.Add(this.personTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(4, -1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(382, 236);
            this.tabControl.TabIndex = 0;
            // 
            // personTab
            // 
            this.personTab.Controls.Add(this.nicknameTextBox);
            this.personTab.Controls.Add(this.nicknameLabel);
            this.personTab.Location = new System.Drawing.Point(4, 22);
            this.personTab.Name = "personTab";
            this.personTab.Padding = new System.Windows.Forms.Padding(3);
            this.personTab.Size = new System.Drawing.Size(374, 210);
            this.personTab.TabIndex = 1;
            this.personTab.Text = "Personalization";
            this.personTab.UseVisualStyleBackColor = true;
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Location = new System.Drawing.Point(69, 6);
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(298, 20);
            this.nicknameTextBox.TabIndex = 1;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Location = new System.Drawing.Point(6, 9);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(58, 13);
            this.nicknameLabel.TabIndex = 0;
            this.nicknameLabel.Text = "Nickname:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.keyTextBox);
            this.tabPage1.Controls.Add(this.encryptCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 210);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Encryption";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // keyTextBox
            // 
            this.keyTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.keyTextBox.Location = new System.Drawing.Point(37, 33);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.Size = new System.Drawing.Size(100, 20);
            this.keyTextBox.TabIndex = 1;
            this.keyTextBox.Click += new System.EventHandler(this.keyTextBox_Click);
            // 
            // encryptCheckBox
            // 
            this.encryptCheckBox.AutoSize = true;
            this.encryptCheckBox.Location = new System.Drawing.Point(6, 6);
            this.encryptCheckBox.Name = "encryptCheckBox";
            this.encryptCheckBox.Size = new System.Drawing.Size(76, 17);
            this.encryptCheckBox.TabIndex = 0;
            this.encryptCheckBox.Text = "Encryption";
            this.encryptCheckBox.UseVisualStyleBackColor = true;
            this.encryptCheckBox.CheckedChanged += new System.EventHandler(this.encryptCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(230, 241);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(391, 269);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.ServerTab.ResumeLayout(false);
            this.ServerTab.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.personTab.ResumeLayout(false);
            this.personTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabPage ServerTab;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TabPage personTab;
        private System.Windows.Forms.TextBox nicknameTextBox;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.CheckBox encryptCheckBox;
    }
}