using HotkeyCommanderF;
using HotkeyCommanderF.HKCFormExtension;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public partial class Form1 : HotkeysExtensionForm
    {
        public Form1()
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
            HotkeyCommand hotkeyComm = new HotkeyCommand(this, new short[] { 1, 2, 3 });
            hotkeyComm.InitiateHotKeys();

            hotkeyComm.KeyActionCall += Actions.onKeyAction; //Do work on keypress
            Actions.ActionComplete += OnActionComplete; //Followup on completed task
        }

        private void OnActionComplete(string myAction, dynamic optional = null)
        {
            /*
             * Modify the Form after the Action is Completed.
             * Use myAction to determine what action occurred.
             * Use Optional for additional information sent from Actions.
             */

            //optional.GetType();
            //MessageBox.Show($"Done- Action:{myAction} Added:{optional.ToString()}");

            if (myAction == "copy")
            {
                CopyFromListToCombo();
            }

            else if (myAction == "paste")
            {
                label3.Text = "Last Paste: " + (string)optional;
                try
                { comboBox1.SelectedIndex++; }
                catch { }
                Program.myIndex = comboBox1.SelectedIndex;
            }
        }//Fires from Actions after an action has been completed.

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
            Settings.WinLoc = this.Location;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.myIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        private void ModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetToolStripIndex(sender) + 1;
            if (index != Settings.Mode) { Actions.SetForm((short)index); }
        }

        private void UseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetToolStripIndex(sender) == 0)
            { UsingClipboard(true); }
            else { UsingClipboard(false); }
        }

        private int GetToolStripIndex(object sender)
        { return (int)((ToolStripItem)sender).Owner.Items.IndexOf((ToolStripItem)sender); }

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
                Program.myList = Program.myList.Distinct().ToList();
                CopyFromListToCombo();
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

            if (Settings.SortList && comboBox1.Items.Count > 0)
            { comboBox1.Sorted = true; }
            else
            { comboBox1.Sorted = false; }

            CopyFromComboToList();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.myList.Clear();
            Program.myIndex = 0;
            comboBox1.Items.Clear();
            try { comboBox1.SelectedIndex = 0; } catch { }
            comboBox1.Text = "";
            label2.Text = "0/0";
            label3.Text = "Last Paste:";
        }

        private void CopyFromListToCombo()
        {
            comboBox1.Items.Clear();
            foreach (string s in Program.myList)
            { comboBox1.Items.Add(s); }
            Program.myIndex = 0;
            try { comboBox1.SelectedIndex = 0; } catch { }
            if (comboBox1.Items.Count > 0) { label2.Text = "1/" + comboBox1.Items.Count; }
            else { label2.Text = "0/0"; }
        }
        private void CopyFromComboToList()
        {
            Program.myList.Clear();
            foreach (string s in comboBox1.Items)
            { Program.myList.Add(s); }
            Program.myIndex = 0;
            try { comboBox1.SelectedIndex = 0; } catch { }
            if (comboBox1.Items.Count > 0) { label2.Text = "1/" + comboBox1.Items.Count; }
            else { label2.Text = "0/0"; }
        }
    }
}
