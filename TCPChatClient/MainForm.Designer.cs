namespace Chat_Client
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.outText = new System.Windows.Forms.RichTextBox();
            this.stsusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.stsusStrip.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(354, 292);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(92, 23);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButtonClick);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 294);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(336, 20);
            this.messageBox.TabIndex = 1;
            this.messageBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageBox_KeyPress);
            // 
            // outText
            // 
            this.outText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outText.Location = new System.Drawing.Point(12, 27);
            this.outText.Name = "outText";
            this.outText.ReadOnly = true;
            this.outText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.outText.Size = new System.Drawing.Size(336, 261);
            this.outText.TabIndex = 2;
            this.outText.Text = "";
            this.outText.WordWrap = false;
            // 
            // stsusStrip
            // 
            this.stsusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusConnection});
            this.stsusStrip.Location = new System.Drawing.Point(0, 319);
            this.stsusStrip.Name = "stsusStrip";
            this.stsusStrip.Size = new System.Drawing.Size(446, 22);
            this.stsusStrip.TabIndex = 3;
            this.stsusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // statusConnection
            // 
            this.statusConnection.Name = "statusConnection";
            this.statusConnection.Size = new System.Drawing.Size(68, 17);
            this.statusConnection.Text = "Connected:";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(446, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // menuOptions
            // 
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(61, 20);
            this.menuOptions.Text = "Options";
            this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(37, 20);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 341);
            this.Controls.Add(this.stsusStrip);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.outText);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.sendButton);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "MEGACHAT";
            this.stsusStrip.ResumeLayout(false);
            this.stsusStrip.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.StatusStrip stsusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusConnection;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        public System.Windows.Forms.RichTextBox outText;
    }
}

