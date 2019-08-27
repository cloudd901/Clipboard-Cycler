namespace Clipboard_Cycler
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleWFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useClipboardPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSendKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createUniqueListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.modeToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(295, 28);
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
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.newToolStripMenuItem.Text = "&New/Clear";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem1.Image")));
            this.openToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.openToolStripMenuItem1.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(159, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.saveToolStripMenuItem1.Text = "&Save As";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cycleOnlyToolStripMenuItem,
            this.cycleWFunctionsToolStripMenuItem,
            this.functionsOnlyToolStripMenuItem,
            this.pasteOnlyToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.modeToolStripMenuItem.Text = "&Window";
            // 
            // cycleOnlyToolStripMenuItem
            // 
            this.cycleOnlyToolStripMenuItem.Name = "cycleOnlyToolStripMenuItem";
            this.cycleOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cycleOnlyToolStripMenuItem.Text = "Cycle Only";
            this.cycleOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // cycleWFunctionsToolStripMenuItem
            // 
            this.cycleWFunctionsToolStripMenuItem.Name = "cycleWFunctionsToolStripMenuItem";
            this.cycleWFunctionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cycleWFunctionsToolStripMenuItem.Text = "Cycle w/ Functions";
            this.cycleWFunctionsToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // functionsOnlyToolStripMenuItem
            // 
            this.functionsOnlyToolStripMenuItem.Name = "functionsOnlyToolStripMenuItem";
            this.functionsOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.functionsOnlyToolStripMenuItem.Text = "Functions Only";
            this.functionsOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // pasteOnlyToolStripMenuItem
            // 
            this.pasteOnlyToolStripMenuItem.Name = "pasteOnlyToolStripMenuItem";
            this.pasteOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pasteOnlyToolStripMenuItem.Text = "Paste Only";
            this.pasteOnlyToolStripMenuItem.Click += new System.EventHandler(this.ModeToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useClipboardPasteToolStripMenuItem,
            this.useSendKeysToolStripMenuItem,
            this.toolStripSeparator1,
            this.createUniqueListToolStripMenuItem,
            this.toolStripSeparator4,
            this.sortListToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.toolsToolStripMenuItem.Text = "&Settings";
            // 
            // useClipboardPasteToolStripMenuItem
            // 
            this.useClipboardPasteToolStripMenuItem.Name = "useClipboardPasteToolStripMenuItem";
            this.useClipboardPasteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.useClipboardPasteToolStripMenuItem.Text = "Use Clipboard Paste";
            this.useClipboardPasteToolStripMenuItem.Click += new System.EventHandler(this.UseToolStripMenuItem_Click);
            // 
            // useSendKeysToolStripMenuItem
            // 
            this.useSendKeysToolStripMenuItem.Name = "useSendKeysToolStripMenuItem";
            this.useSendKeysToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.useSendKeysToolStripMenuItem.Text = "Use Send Keys";
            this.useSendKeysToolStripMenuItem.Click += new System.EventHandler(this.UseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // createUniqueListToolStripMenuItem
            // 
            this.createUniqueListToolStripMenuItem.Name = "createUniqueListToolStripMenuItem";
            this.createUniqueListToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createUniqueListToolStripMenuItem.Text = "Create Unique List";
            this.createUniqueListToolStripMenuItem.Click += new System.EventHandler(this.CreateUniqueListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // sortListToolStripMenuItem
            // 
            this.sortListToolStripMenuItem.Name = "sortListToolStripMenuItem";
            this.sortListToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sortListToolStripMenuItem.Text = "Sort List";
            this.sortListToolStripMenuItem.Click += new System.EventHandler(this.SortListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.aboutToolStripMenuItem1.Text = "&About...";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-1, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "F1 (Copy)     F2 (Paste)     F3 (Enter)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 34);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(216, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "0/0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Paste:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 126);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clipboard Cycler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleWFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteOnlyToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem useClipboardPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useSendKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem createUniqueListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

