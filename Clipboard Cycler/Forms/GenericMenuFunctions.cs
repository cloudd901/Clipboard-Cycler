using PCAFFINITY;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public static class GenericMenuFunctions
    {
        public static void AboutToolStripMenuItem()
        {
            Forms.AboutBox1 about = new Forms.AboutBox1();
            about.ShowDialog();
        }

        public static void CopyFromListToCombo(ComboBox c, Label l)
        {
            c.Items.Clear();
            foreach (string s in Program.MyList)
            {
                c.Items.Add(Settings.TrimWS ? s.Trim() : s);
            }

            CopyFromReset(c, l);
        }

        public static void CreateUniqueListToolStripMenuItem(object sender, ComboBox combo, Label lcount)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                Settings.UniqueList = item.Checked;
            }

            if (Settings.UniqueList)
            {
                Program.MyList = Program.MyList.Distinct().ToList();
                CopyFromListToCombo(combo, lcount);
            }
        }

        public static void DisableHotkeyErrorsToolStripMenuItem(object sender)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                Settings.HideHotkeyErrors = item.Checked;
            }
        }

        public static void ModeToolStripMenuItem(object sender, Form f)
        {
            int index = GetToolStripIndex(sender) + 1;
            if (index != Settings.Mode)
            {
                Actions.SetForm((short)index, f);
            }
        }

        public static void NewToolStripMenuItem(Form f, ComboBox combo, Label lcount, Label ltext)
        {
            f.Text = Program.MyTitle;
            Program.MySaveFile = null;
            Program.MyList.Clear();
            Program.MyIndex = 0;
            combo.Items.Clear();
            try
            {
                combo.SelectedIndex = 0;
            }
            catch
            {
                // Ignore
            }

            combo.Text = "";
            lcount.Text = "0/0";
            ltext.Text = "Last Paste:";
        }

        public static void OpenToolStripMenu(Form f)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Text Files *.txt|*.txt|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                Program.MySaveFile = new FileInfo(open.FileName);
                f.Text = Program.MyTitle + " - " + Program.MySaveFile.Name;
                Actions.HandleFileOpen(File.ReadAllText(Program.MySaveFile.FullName));
            }
        }

        public static void PauseToolStripMenuItem(object sender, HotkeyCommand hotkeyComm)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                hotkeyComm.SetHotkeysGlobally = item.Checked;

                if (item.Checked && hotkeyComm.IsRegistered)
                {
                    hotkeyComm.StopHotkeys();
                }
                else if (!item.Checked)
                {
                    hotkeyComm.StartHotkeys();
                }
            }
        }

        public static void RemoveItemToolStripMenuItem(ComboBox combo, Label lcount = null)
        {
            try
            {
                int temp = Program.MyIndex;
                Program.MyList.RemoveAt(Program.MyIndex);
                CopyFromListToCombo(combo, lcount);
                temp = temp < 1 ? 0 : temp >= combo.Items.Count ? temp - 1 : temp;
                combo.SelectedIndex = temp;
                Program.MyIndex = combo.SelectedIndex;
            }
            catch
            {
                // Ignore
            }
        }

        public static void SaveAsToolStripMenu(Form f)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Text File *.txt|*.txt|All files (*.*)|*.*"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                Program.MySaveFile = new FileInfo(save.FileName);
                File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
                f.Text = Program.MyTitle + " - " + Program.MySaveFile.Name;
            }
        }

        public static void SaveToolStripMenu(Form f)
        {
            if (Program.MySaveFile != null)
            {
                File.WriteAllText(Program.MySaveFile.FullName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    InitialDirectory = Directory.GetCurrentDirectory(),
                    Filter = "Text File *.txt|*.txt|All files (*.*)|*.*"
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Program.MySaveFile = new FileInfo(save.FileName);
                    File.WriteAllText(save.FileName, string.Join(Environment.NewLine, Program.MyList.ToArray()));
                    f.Text = "Clipboard Cycler - " + Program.MySaveFile.Name;
                }
            }
        }

        public static void SortListToolStripMenuItem(object sender, ComboBox combo = null, Label lcount = null)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                Settings.SortList = item.Checked;
            }

            if (combo != null)
            {
                combo.Sorted = Settings.SortList && combo.Items.Count > 0;
                CopyFromComboToList(combo, lcount);
            }
        }

        public static void TrimWhitespaceToolStripMenuItem(object sender, ComboBox combo = null, Label lcount = null)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                Settings.TrimWS = item.Checked;
            }

            if (combo != null)
            {
                CopyFromListToCombo(combo, lcount);
                CopyFromComboToList(combo, lcount);
            }
        }

        public static void UseEscToDblClickToolStripMenuItem(object sender, HotkeyCommand hotkeyComm, Label ltext = null)
        {
            if (sender is ToolStripMenuItem item)
            {
                item.Checked = !item.Checked;
                Settings.UseEscape = item.Checked;
            }

            if (hotkeyComm != null)
            {
                if (Settings.UseEscape)
                {
                    if (ltext?.Text.Contains("Esc = Double Click") == false)
                    {
                        ltext.Text += "\r\nEsc = Double Click";
                    }

                    if (!hotkeyComm.HotkeyDictionary.Values.Contains("Escape", StringComparer.InvariantCultureIgnoreCase))
                    {
                        hotkeyComm.HotkeyAddKey("Escape");
                        if (hotkeyComm.IsRegistered)
                        {
                            hotkeyComm.RestartHotkeys();
                        }
                    }
                }
                else
                {
                    if (ltext?.Text.Contains("Esc = Double Click") == true)
                    {
                        ltext.Text = ltext.Text.Replace("Esc = Double Click", "");
                    }

                    if (hotkeyComm.HotkeyDictionary.Values.Contains("Escape", StringComparer.InvariantCultureIgnoreCase))
                    {
                        hotkeyComm.HotkeyRemoveKey("Escape");
                        if (hotkeyComm.IsRegistered)
                        {
                            hotkeyComm.RestartHotkeys();
                        }
                    }
                }
            }
        }

        public static void UseToolStripMenuItem(object sender)
        {
            int choice = GetToolStripIndex(sender);

            Settings.UseSendCTRLV = choice == 2;
            Settings.UseSendKeys = choice == 3;
            Settings.UseSendKeysDelay = choice == 4;

            ((ToolStripMenuItem)((ToolStripItem)sender).Owner.Items[2]).Checked = Settings.UseSendCTRLV;
            ((ToolStripMenuItem)((ToolStripItem)sender).Owner.Items[3]).Checked = Settings.UseSendKeys;
            ((ToolStripMenuItem)((ToolStripItem)sender).Owner.Items[4]).Checked = Settings.UseSendKeysDelay;
        }

        private static void CopyFromComboToList(ComboBox c, Label l)
        {
            Program.MyList.Clear();
            foreach (string s in c.Items)
            {
                Program.MyList.Add(Settings.TrimWS ? s.Trim() : s);
            }

            CopyFromReset(c, l);
        }

        private static void CopyFromReset(ComboBox c, Label l)
        {
            Program.MyIndex = 0;
            try
            {
                c.SelectedIndex = 0;
            }
            catch
            {
            }

            if (l != null)
            {
                l.Text = c.Items.Count > 0 ? "1/" + c.Items.Count : l.Text = "0/0";
            }
        }

        private static int GetToolStripIndex(object sender)
        {
            return ((ToolStripItem)sender).Owner.Items.IndexOf((ToolStripItem)sender);
        }
    }
}