﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    partial class Form2
    {

        private void SetMenuItems()
        {
            useEscToDblClickToolStripMenuItem.Checked = Settings.UseEscape;
            useClipboardPasteToolStripMenuItem.Checked = Settings.UseSendCTRLV;
            useSendKeysToolStripMenuItem.Checked = Settings.UseSendKeys;
            useSendKeystrokeswDelayToolStripMenuItem.Checked = Settings.UseSendKeysDelay;
            createUniqueListToolStripMenuItem.Checked = Settings.UniqueList;
            sortListToolStripMenuItem.Checked = Settings.SortList;
            trimWhitespaceToolStripMenuItem.Checked = Settings.TrimWS;
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.AboutBox1 about = new Forms.AboutBox1();
            about.ShowDialog();
        }

        private int GetToolStripIndex(object sender)
        { return (int)((ToolStripItem)sender).Owner.Items.IndexOf((ToolStripItem)sender); }
        //=================================Mode Menu Items=====================================
        //=====================================================================================
        private void ModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = GetToolStripIndex(sender) + 1;
            if (index != Settings.Mode) { Actions.SetForm((short)index, this); }
        }

        //===============================Setting Menu Items====================================
        //=====================================================================================
        private void UseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.UseSendCTRLV = false;
            Settings.UseSendKeys = false;
            Settings.UseSendKeysDelay = false;

            if (GetToolStripIndex(sender) == 2)
            { Settings.UseSendCTRLV = true; }
            else if (GetToolStripIndex(sender) == 3)
            { Settings.UseSendKeys = true; }
            else if (GetToolStripIndex(sender) == 4)
            { Settings.UseSendKeysDelay = true; }

            useClipboardPasteToolStripMenuItem.Checked = Settings.UseSendCTRLV;
            useSendKeysToolStripMenuItem.Checked = Settings.UseSendKeys;
            useSendKeystrokeswDelayToolStripMenuItem.Checked = Settings.UseSendKeysDelay;
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
        private void TrimWhitespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trimWhitespaceToolStripMenuItem.Checked)
            { trimWhitespaceToolStripMenuItem.Checked = false; }
            else
            { trimWhitespaceToolStripMenuItem.Checked = true; }

            if (trimWhitespaceToolStripMenuItem.Checked) { Settings.TrimWS = true; }
            else { Settings.TrimWS = false; }
            CopyFromListToCombo();
            CopyFromComboToList();
        }
        private void UseEscToDblClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (useEscToDblClickToolStripMenuItem.Checked)
            { useEscToDblClickToolStripMenuItem.Checked = false; }
            else
            { useEscToDblClickToolStripMenuItem.Checked = true; }

            if (useEscToDblClickToolStripMenuItem.Checked)
            { Settings.UseEscape = true; }
            else
            { Settings.UseEscape = false; }

            if (hotkeyComm != null)
            {
                if (Settings.UseEscape)
                {
                    if (!label1.Text.Contains("Esc = Double Click")) { label1.Text += "\r\nEsc = Double Click"; }
                    if (!hotkeyComm.HotkeyDictionary.Values.Contains("Escape"))
                    {
                        hotkeyComm.HotkeyRegister("Escape");
                        if (hotkeyComm.IsRegistered) { hotkeyComm._RestartHotkeys(); }
                    }
                }
                else
                {
                    if (label1.Text.Contains("Esc = Double Click")) { label1.Text = label1.Text.Replace("Esc = Double Click", ""); }
                    if (hotkeyComm.HotkeyDictionary.Values.Contains("Escape"))
                    {
                        hotkeyComm.HotkeyUnregister("Escape");
                        if (hotkeyComm.IsRegistered) { hotkeyComm._RestartHotkeys(); }
                    }
                }
            }
        }
        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pauseToolStripMenuItem.Checked)
            { pauseToolStripMenuItem.Checked = false; }
            else
            { pauseToolStripMenuItem.Checked = true; }

            if (pauseToolStripMenuItem.Checked)
            { hotkeyComm.SetHotkeysGlobally = false; if (hotkeyComm.IsRegistered) { hotkeyComm._StopHotkeys(); } }
            else
            { hotkeyComm.SetHotkeysGlobally = true; hotkeyComm._StartHotkeys(); }
        }

        //=================================File Menu Items=====================================
        //=====================================================================================
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Text = Program.myTitle;
            Program.mySaveFile = null;
            Program.myList.Clear();
            Program.myIndex = 0;
            comboBox1.Items.Clear();
            try { comboBox1.SelectedIndex = 0; } catch { }
            comboBox1.Text = "";
            label2.Text = "0/0";
            label3.Text = "Last Paste:";
        }
        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Text Files *.txt|*.txt|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Program.mySaveFile = new FileInfo(open.FileName);
                Text = Program.myTitle + " - " + Program.mySaveFile.Name;
                Actions.HandleFileOpen(File.ReadAllText(Program.mySaveFile.FullName));
            }
        }
        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Directory.GetCurrentDirectory();
            save.Filter = "Text File *.txt|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Program.mySaveFile = new FileInfo(save.FileName);
                File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.myList.ToArray()));
                Text = Program.myTitle + " - " + Program.mySaveFile.Name;
            }
        }
        private void RemoveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = Program.myIndex;
                Program.myList.RemoveAt(Program.myIndex);
                CopyFromListToCombo();
                temp = temp < 1 ? 0 : temp >= comboBox1.Items.Count ? temp - 1 : temp;
                comboBox1.SelectedIndex = temp;
                Program.myIndex = comboBox1.SelectedIndex;

            }
            catch { }
        }
        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (Program.mySaveFile != null)
            {
                File.WriteAllText(Program.mySaveFile.FullName, string.Join(Environment.NewLine, Program.myList.ToArray()));
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Directory.GetCurrentDirectory();
                save.Filter = "Text File *.txt|*.txt|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Program.mySaveFile = new FileInfo(save.FileName);
                    File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.myList.ToArray()));
                    Text = "Clipboard Cycler - " + Program.mySaveFile.Name;
                }
            }
        }
    }
}
