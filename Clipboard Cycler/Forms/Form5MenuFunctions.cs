using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    partial class Form5
    {
        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.AboutBox1 about = new Forms.AboutBox1();
            about.ShowDialog();
        }

        private void DisableHotkeyErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (disableHotkeyErrorsToolStripMenuItem.Checked)
            { disableHotkeyErrorsToolStripMenuItem.Checked = false; }
            else
            { disableHotkeyErrorsToolStripMenuItem.Checked = true; }

            if (disableHotkeyErrorsToolStripMenuItem.Checked)
            { Settings.HideHotkeyErrors = true; }
            else
            { Settings.HideHotkeyErrors = false; }
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

        //=================================File Menu Items=====================================
        //=====================================================================================
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Text Files *.txt|*.txt|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Program.MySaveFile = new FileInfo(open.FileName);
                Text = Program.MyTitle + " - " + Program.MySaveFile.Name;
                Actions.HandleFileOpen(File.ReadAllText(Program.MySaveFile.FullName));
            }
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pauseToolStripMenuItem.Checked)
            { pauseToolStripMenuItem.Checked = false; }
            else
            { pauseToolStripMenuItem.Checked = true; }

            if (pauseToolStripMenuItem.Checked)
            { HotkeyComm.SetHotkeysGlobally = false; if (HotkeyComm.IsRegistered) { HotkeyComm.StopHotkeys(); } }
            else
            { HotkeyComm.SetHotkeysGlobally = true; HotkeyComm.StartHotkeys(); }
        }

        private void RemoveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Directory.GetCurrentDirectory();
            save.Filter = "Text File *.txt|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Program.MySaveFile = new FileInfo(save.FileName);
                File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
                Text = Program.MyTitle + " - " + Program.MySaveFile.Name;
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.MySaveFile != null)
            {
                File.WriteAllText(Program.MySaveFile.FullName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Directory.GetCurrentDirectory();
                save.Filter = "Text File *.txt|*.txt|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Program.MySaveFile = new FileInfo(save.FileName);
                    File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
                    Text = "Clipboard Cycler - " + Program.MySaveFile.Name;
                }
            }
        }

        private void SetMenuItems()
        {
            useClipboardPasteToolStripMenuItem.Checked = Settings.UseSendCTRLV;
            useSendKeysToolStripMenuItem.Checked = Settings.UseSendKeys;
            useSendKeystrokeswDelayToolStripMenuItem.Checked = Settings.UseSendKeysDelay;
            disableHotkeyErrorsToolStripMenuItem.Checked = Settings.HideHotkeyErrors;
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

            if (HotkeyComm != null)
            {
                if (Settings.UseEscape)
                {
                    if (!label1.Text.Contains("Esc = Double Click")) { label1.Text += "\r\nEsc = Double Click"; }
                    if (!HotkeyComm.HotkeyDictionary.Values.Contains("Escape"))
                    {
                        HotkeyComm.HotkeyAddKey("Escape");
                        if (HotkeyComm.IsRegistered) { HotkeyComm.RestartHotkeys(); }
                    }
                }
                else
                {
                    if (label1.Text.Contains("Esc = Double Click")) { label1.Text = label1.Text.Replace("Esc = Double Click", ""); }
                    if (HotkeyComm.HotkeyDictionary.Values.Contains("Escape"))
                    {
                        HotkeyComm.HotkeyAddKey("Escape");
                        if (HotkeyComm.IsRegistered) { HotkeyComm.RestartHotkeys(); }
                    }
                }
            }
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
    }
}