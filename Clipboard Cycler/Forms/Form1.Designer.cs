﻿namespace Clipboard_Cycler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleWFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleAndPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useEscToDblClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.useClipboardPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSendKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSendKeystrokeswDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUniqueListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimWhitespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disableHotkeyErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.modeToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(239, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.toolStripSeparator,
            this.saveToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.removeItemToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem1.Text = "&List";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.newToolStripMenuItem.Text = "&New/Clear";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem1.Image")));
            this.openToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem1.Text = "&Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.OpenToolStripMenuItem1_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(143, 26);
            this.saveToolStripMenuItem1.Text = "&Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.SaveToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 26);
            this.toolStripMenuItem1.Text = "S&ave As";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.SaveAsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.removeItemToolStripMenuItem.Text = "&Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.RemoveItemToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cycleOnlyToolStripMenuItem,
            this.cycleWFunctionsToolStripMenuItem,
            this.functionsOnlyToolStripMenuItem,
            this.cycleAndPasteToolStripMenuItem,
            this.pasteOnlyToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.modeToolStripMenuItem.Text = "&Window";
            // 
            // cycleOnlyToolStripMenuItem
            // 
            this.cycleOnlyToolStripMenuItem.Name = "cycleOnlyToolStripMenuItem";
            this.cycleOnlyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cycleOnlyToolStripMenuItem.Text = "Cycle Only";
            this.cycleOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // cycleWFunctionsToolStripMenuItem
            // 
            this.cycleWFunctionsToolStripMenuItem.Name = "cycleWFunctionsToolStripMenuItem";
            this.cycleWFunctionsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cycleWFunctionsToolStripMenuItem.Text = "Cycle, Run, and Paste";
            this.cycleWFunctionsToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // functionsOnlyToolStripMenuItem
            // 
            this.functionsOnlyToolStripMenuItem.Name = "functionsOnlyToolStripMenuItem";
            this.functionsOnlyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.functionsOnlyToolStripMenuItem.Text = "Cycle and Run";
            this.functionsOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // cycleAndPasteToolStripMenuItem
            // 
            this.cycleAndPasteToolStripMenuItem.Name = "cycleAndPasteToolStripMenuItem";
            this.cycleAndPasteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cycleAndPasteToolStripMenuItem.Text = "Cycle and Paste";
            this.cycleAndPasteToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // pasteOnlyToolStripMenuItem
            // 
            this.pasteOnlyToolStripMenuItem.Name = "pasteOnlyToolStripMenuItem";
            this.pasteOnlyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pasteOnlyToolStripMenuItem.Text = "Paste Only";
            this.pasteOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useEscToDblClickToolStripMenuItem,
            this.toolStripSeparator4,
            this.useClipboardPasteToolStripMenuItem,
            this.useSendKeysToolStripMenuItem,
            this.useSendKeystrokeswDelayToolStripMenuItem,
            this.toolStripSeparator3,
            this.listPropertiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.pauseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.toolsToolStripMenuItem.Text = "&Settings";
            // 
            // useEscToDblClickToolStripMenuItem
            // 
            this.useEscToDblClickToolStripMenuItem.Name = "useEscToDblClickToolStripMenuItem";
            this.useEscToDblClickToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.useEscToDblClickToolStripMenuItem.Text = "Use &Esc to Dbl Click";
            this.useEscToDblClickToolStripMenuItem.Click += new System.EventHandler(this.UseEscToDblClickToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // useClipboardPasteToolStripMenuItem
            // 
            this.useClipboardPasteToolStripMenuItem.Name = "useClipboardPasteToolStripMenuItem";
            this.useClipboardPasteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.useClipboardPasteToolStripMenuItem.Text = "Use &Send Ctrl+v";
            this.useClipboardPasteToolStripMenuItem.Click += new System.EventHandler(this.UseToolStripMenuItem_Click);
            // 
            // useSendKeysToolStripMenuItem
            // 
            this.useSendKeysToolStripMenuItem.Name = "useSendKeysToolStripMenuItem";
            this.useSendKeysToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.useSendKeysToolStripMenuItem.Text = "Use &Send Keystrokes";
            this.useSendKeysToolStripMenuItem.Click += new System.EventHandler(this.UseToolStripMenuItem_Click);
            // 
            // useSendKeystrokeswDelayToolStripMenuItem
            // 
            this.useSendKeystrokeswDelayToolStripMenuItem.Name = "useSendKeystrokeswDelayToolStripMenuItem";
            this.useSendKeystrokeswDelayToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.useSendKeystrokeswDelayToolStripMenuItem.Text = "Use Send Keystrokes /w Delay";
            this.useSendKeystrokeswDelayToolStripMenuItem.Click += new System.EventHandler(this.UseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // listPropertiesToolStripMenuItem
            // 
            this.listPropertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortListToolStripMenuItem,
            this.createUniqueListToolStripMenuItem,
            this.trimWhitespaceToolStripMenuItem});
            this.listPropertiesToolStripMenuItem.Name = "listPropertiesToolStripMenuItem";
            this.listPropertiesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.listPropertiesToolStripMenuItem.Text = "&List Settings";
            // 
            // sortListToolStripMenuItem
            // 
            this.sortListToolStripMenuItem.Name = "sortListToolStripMenuItem";
            this.sortListToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sortListToolStripMenuItem.Text = "&Sort List";
            this.sortListToolStripMenuItem.Click += new System.EventHandler(this.SortListToolStripMenuItem_Click);
            // 
            // createUniqueListToolStripMenuItem
            // 
            this.createUniqueListToolStripMenuItem.Name = "createUniqueListToolStripMenuItem";
            this.createUniqueListToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.createUniqueListToolStripMenuItem.Text = "&Create Unique List";
            this.createUniqueListToolStripMenuItem.Click += new System.EventHandler(this.CreateUniqueListToolStripMenuItem_Click);
            // 
            // trimWhitespaceToolStripMenuItem
            // 
            this.trimWhitespaceToolStripMenuItem.Name = "trimWhitespaceToolStripMenuItem";
            this.trimWhitespaceToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.trimWhitespaceToolStripMenuItem.Text = "&Trim Whitespace";
            this.trimWhitespaceToolStripMenuItem.Click += new System.EventHandler(this.TrimWhitespaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.disableHotkeyErrorsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // disableHotkeyErrorsToolStripMenuItem
            // 
            this.disableHotkeyErrorsToolStripMenuItem.Name = "disableHotkeyErrorsToolStripMenuItem";
            this.disableHotkeyErrorsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.disableHotkeyErrorsToolStripMenuItem.Text = "Disable Hotkey Errors";
            this.disableHotkeyErrorsToolStripMenuItem.Click += new System.EventHandler(this.DisableHotkeyErrorsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "F1 = Copy     F2 = Paste     F3 = Enter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.TextChanged += new System.EventHandler(this.Label1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 28);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label2.Location = new System.Drawing.Point(177, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "0/0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label3.Location = new System.Drawing.Point(5, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Paste:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.GhostWhite;
            this.button1.Location = new System.Drawing.Point(180, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "List Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(239, 98);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3004, 143);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(255, 137);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clipboard Cycler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cycleOnlyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cycleWFunctionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem functionsOnlyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pasteOnlyToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem useClipboardPasteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem useSendKeysToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem useEscToDblClickToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem listPropertiesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sortListToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem trimWhitespaceToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem createUniqueListToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useSendKeystrokeswDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableHotkeyErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleAndPasteToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

