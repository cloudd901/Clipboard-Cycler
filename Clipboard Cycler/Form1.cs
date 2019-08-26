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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cycleOnlyToolStripMenuItem.Checked = true;
            useClipboardPasteToolStripMenuItem.Checked = Program.allSettings.UseClipboard;
            useClipboardPasteToolStripMenuItem.Checked = !Program.allSettings.UseClipboard;
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CycleOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Actions.SetForm(1);
        }

        private void CycleWFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions.SetForm(2);
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
            UsingClipboard(true);
        }

        private void UseSendKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsingClipboard(false);
        }

        private void UsingClipboard(bool b)
        {
            Program.allSettings.UseClipboard = b;
            useClipboardPasteToolStripMenuItem.Checked = b;
            useSendKeysToolStripMenuItem.Checked = !b;
        }
    }
}
