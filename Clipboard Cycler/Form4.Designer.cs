namespace Clipboard_Cycler
{
    partial class Form4
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleWFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.useClipboardPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSendKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(295, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cycleOnlyToolStripMenuItem,
            this.cycleWFunctionsToolStripMenuItem,
            this.functionsOnlyToolStripMenuItem,
            this.pasteOnlyToolStripMenuItem,
            this.toolStripSeparator1,
            this.useClipboardPasteToolStripMenuItem,
            this.useSendKeysToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // cycleOnlyToolStripMenuItem
            // 
            this.cycleOnlyToolStripMenuItem.Name = "cycleOnlyToolStripMenuItem";
            this.cycleOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cycleOnlyToolStripMenuItem.Text = "Cycle Only";
            this.cycleOnlyToolStripMenuItem.Click += new System.EventHandler(this.CycleOnlyToolStripMenuItem_Click);
            // 
            // cycleWFunctionsToolStripMenuItem
            // 
            this.cycleWFunctionsToolStripMenuItem.Name = "cycleWFunctionsToolStripMenuItem";
            this.cycleWFunctionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cycleWFunctionsToolStripMenuItem.Text = "Cycle w/ Functions";
            this.cycleWFunctionsToolStripMenuItem.Click += new System.EventHandler(this.CycleWFunctionsToolStripMenuItem_Click);
            // 
            // functionsOnlyToolStripMenuItem
            // 
            this.functionsOnlyToolStripMenuItem.Name = "functionsOnlyToolStripMenuItem";
            this.functionsOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.functionsOnlyToolStripMenuItem.Text = "Functions Only";
            this.functionsOnlyToolStripMenuItem.Click += new System.EventHandler(this.FunctionsOnlyToolStripMenuItem_Click);
            // 
            // pasteOnlyToolStripMenuItem
            // 
            this.pasteOnlyToolStripMenuItem.Name = "pasteOnlyToolStripMenuItem";
            this.pasteOnlyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pasteOnlyToolStripMenuItem.Text = "Paste Only";
            this.pasteOnlyToolStripMenuItem.Click += new System.EventHandler(this.PasteOnlyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // useClipboardPasteToolStripMenuItem
            // 
            this.useClipboardPasteToolStripMenuItem.Name = "useClipboardPasteToolStripMenuItem";
            this.useClipboardPasteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.useClipboardPasteToolStripMenuItem.Text = "Use Clipboard Paste";
            this.useClipboardPasteToolStripMenuItem.Click += new System.EventHandler(this.UseClipboardPasteToolStripMenuItem_Click);
            // 
            // useSendKeysToolStripMenuItem
            // 
            this.useSendKeysToolStripMenuItem.Name = "useSendKeysToolStripMenuItem";
            this.useSendKeysToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.useSendKeysToolStripMenuItem.Text = "Use Send Keys";
            this.useSendKeysToolStripMenuItem.Click += new System.EventHandler(this.UseSendKeysToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.readmeToolStripMenuItem.Text = "Readme";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-2, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "F2 (Paste)     F3 (Enter)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.Text = "Clipboard Cycler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleWFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem useClipboardPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useSendKeysToolStripMenuItem;
    }
}

