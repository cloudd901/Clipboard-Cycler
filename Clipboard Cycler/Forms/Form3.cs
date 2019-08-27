using HotkeyCommanderF;
using HotkeyCommanderF.HKCFormExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public partial class Form3 : HotkeysExtensionForm
    {
        public Form3()
        {
            InitializeComponent();

            //Set window properties
            this.Location = Settings.WinLoc;
            cycleOnlyToolStripMenuItem.Checked = true;
            useClipboardPasteToolStripMenuItem.Checked = Settings.UseClipboard;
            useSendKeysToolStripMenuItem.Checked = (!Settings.UseClipboard);
            createUniqueListToolStripMenuItem.Checked = Settings.UniqueList;
            sortListToolStripMenuItem.Checked = Settings.SortList;

            //Configure Hotkeys
            HotkeyCommand hotkeyComm = new HotkeyCommand(this, comboBox1, new short[] { 1, 2, 3 });
            hotkeyComm.HKCountingLabel = label2;
            hotkeyComm.HKTextLabel = label3;
            hotkeyComm.InitiateHotKeys();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
            Settings.WinLoc = this.Location;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        private void CycleOnlyToolStripMenuItem_Click(object sender, EventArgs e) => Actions.SetForm(1);

        private void CycleWFunctionsToolStripMenuItem_Click(object sender, EventArgs e) => Actions.SetForm(2);

        private void FunctionsOnlyToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void PasteOnlyToolStripMenuItem_Click(object sender, EventArgs e) => Actions.SetForm(4);

        private void UseClipboardPasteToolStripMenuItem_Click_1(object sender, EventArgs e) => UsingClipboard(true);

        private void UseSendKeysToolStripMenuItem_Click_1(object sender, EventArgs e) => UsingClipboard(false);

        private void UsingClipboard(bool b)
        {
            Settings.UseClipboard = b;
            useClipboardPasteToolStripMenuItem.Checked = b;
            useSendKeysToolStripMenuItem.Checked = !b;
        }

        private void CreateUniqueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createUniqueListToolStripMenuItem.Checked)
            { createUniqueListToolStripMenuItem.Checked = false; }
            else
            { createUniqueListToolStripMenuItem.Checked = true; }

            if (createUniqueListToolStripMenuItem.Checked)
            { Settings.UniqueList = true; }
            else
            { Settings.UniqueList = false; }

            if (Settings.UniqueList)
            {
                List<string> tempList = new List<string>();
                foreach (string s in comboBox1.Items)
                { tempList.Add(s); }
                tempList = tempList.Distinct().ToList();
                comboBox1.Items.Clear();
                foreach (string s in tempList)
                { comboBox1.Items.Add(s); }
                try { comboBox1.SelectedIndex = 0; } catch { }
                label2.Text = "1/" + comboBox1.Items.Count;
            }
        }

        private void SortListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sortListToolStripMenuItem.Checked)
            { sortListToolStripMenuItem.Checked = false; }
            else
            { sortListToolStripMenuItem.Checked = true; }

            if (sortListToolStripMenuItem.Checked)
            { Settings.SortList = true; }
            else
            { Settings.SortList = false; }

            if (Settings.SortList)
            {
                comboBox1.Sorted = true;
                try { comboBox1.SelectedIndex = 0; } catch { }
                label2.Text = "1/" + comboBox1.Items.Count;
            }
            else
            {
                comboBox1.Sorted = false;
                try { comboBox1.SelectedIndex = 0; } catch { }
                label2.Text = "1/" + comboBox1.Items.Count;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try { comboBox1.SelectedIndex = 0; } catch { }
            comboBox1.Text = "";
            label2.Text = "0\\0";
            label3.Text = "Last Paste:";
        }
    }
}
