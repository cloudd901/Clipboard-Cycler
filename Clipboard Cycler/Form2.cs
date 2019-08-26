﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio;

namespace Clipboard_Cycler
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cycleWFunctionsToolStripMenuItem.Checked = true;
            useClipboardPasteToolStripMenuItem.Checked = Program.allSettings.UseClipboard;
            useClipboardPasteToolStripMenuItem.Checked = !Program.allSettings.UseClipboard;
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CycleOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.SetForm(1);
        }

        private void CycleWFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.SetForm(1);
        }

        private void FunctionsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.SetForm(3);
        }

        private void PasteOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.SetForm(4);
        }

        private void UseClipboardPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.allSettings.UseClipboard = true;
            useClipboardPasteToolStripMenuItem.Checked = true;
            useSendKeysToolStripMenuItem.Checked = false;
        }

        private void UseSendKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.allSettings.UseClipboard = false;
            useClipboardPasteToolStripMenuItem.Checked = false;
            useSendKeysToolStripMenuItem.Checked = true;
        }
    }
}
