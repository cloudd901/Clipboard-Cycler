using PCAFFINITY;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
* HotkeyCommand.dll referenced in the Forms.cs using Hotkeys.
* - Set the Extension method
* - Create new instance of HotkeyCommand
* - Set Action KeyActionCall (Returns Form and string to represent key)
*
* Using Costura.Fody to package the DLL inside the released EXE.
*/

namespace Clipboard_Cycler
{
    public partial class Form4 : HotkeysExtensionForm
    {
        private RoundedButtons MyRoundedButtons1;

        public Form4()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();
        }

        private HotkeyCommand HotkeyComm { get; set; }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.EndOfListPasted = false;
            Program.MyIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SavedList = String.Join("~`", comboBox1.Items.Cast<string>());
            Settings.WinSize = this.Size;
            Settings.WinLoc = this.Location;
            Settings.Form4Fields[0] = textBox4.Text;
            Settings.Form4Fields[1] = textBox5.Text;
            Settings.Form4Fields[2] = textBox6.Text;
            Settings.Form4Fields[3] = textBox7.Text;
            Settings.Form4Fields[4] = textBox8.Text;
            Settings.Form4Fields[5] = textBox9.Text;
            Settings.Form4Fields[6] = textBox10.Text;
            Settings.Form4Fields[7] = textBox11.Text;
            Settings.Save();
            HotkeyComm?.Dispose();
            HotkeyComm = null;

            if (!Actions.SwitchingForms)
            {
                Environment.Exit(0);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MyRoundedButtons1 = new RoundedButtons()
            {
                Btn_ShadowLocation = ShadowPosition.BottomRight,
                MainLineColor = Color.LightSteelBlue,
                MainShadowColor = Color.DarkBlue,
                Btn_CornerRadius = 7,
                Btn_ShadowWidth = ShadowSize.Thin,
                HighlightLineColor = Color.DarkBlue
            };
            MyRoundedButtons1.PaintButton(button1);

            Text = Program.MyTitle;
            Size = Settings.WinSize;
            Location = Settings.WinLoc;
            textBox4.Text = Settings.Form4Fields[0];
            textBox5.Text = Settings.Form4Fields[1];
            textBox6.Text = Settings.Form4Fields[2];
            textBox7.Text = Settings.Form4Fields[3];
            textBox8.Text = Settings.Form4Fields[4];
            textBox9.Text = Settings.Form4Fields[5];
            textBox10.Text = Settings.Form4Fields[6];
            textBox11.Text = Settings.Form4Fields[7];

            SetMenuItems();
            SetGUIandHotkeys();

            Actions.HandleFileOpen(Settings.SavedList.Replace("~`", Environment.NewLine));
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            Actions.SwitchingForms = false;
        }

        private void Label1_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.EndsWith("\r\n"))
            {
                ((Label)sender).Text = ((Label)sender).Text.Trim();
            }
        }

        private void OnActionComplete(Actions.MyActions action, dynamic optional = null)
        {
            /*
             * Modify the Form after the Action is Completed.
             * Use myAction to determine what action occurred.
             * Use Optional for additional information sent from Actions.
             */

            if (action == Actions.MyActions.Copy)
            {
                GenericMenuFunctions.CopyFromListToCombo(comboBox1, label2);
            }
            else if (action == Actions.MyActions.Paste)
            {
                label3.Text = "Last Paste: " + (string)optional;
                try
                {
                    comboBox1.SelectedIndex++;
                }
                catch
                {
                    // Ignore
                }

                Program.MyIndex = comboBox1.SelectedIndex;
                if (Program.EndOfListPasted)
                {
                    label2.Text = "End/" + comboBox1.Items.Count;
                }
            }
            else if (action == Actions.MyActions.Paste2)
            {
                string pasteText = "";
                if ((string)optional == "F4")
                {
                    pasteText = textBox4.Text;
                }
                else if ((string)optional == "F5")
                {
                    pasteText = textBox5.Text;
                }
                else if ((string)optional == "F6")
                {
                    pasteText = textBox6.Text;
                }
                else if ((string)optional == "F7")
                {
                    pasteText = textBox7.Text;
                }
                else if ((string)optional == "F8")
                {
                    pasteText = textBox8.Text;
                }
                else if ((string)optional == "F9")
                {
                    pasteText = textBox9.Text;
                }
                else if ((string)optional == "F10")
                {
                    pasteText = textBox10.Text;
                }
                else if ((string)optional == "F11")
                {
                    pasteText = textBox11.Text;
                }

                Actions.PasteString(pasteText);
            }
            else if (action == Actions.MyActions.Esc)
            {
                Actions.DblClick();
            }
        }

        private void Registrations(bool result, string key, short id)
        {
            if (!result)
            {
                if (key == "F1" || key == "F2")
                {
                    comboBox1.Enabled = false;
                }
                else if (key == "F4")
                {
                    label10.Enabled = false;
                }
                else if (key == "F5")
                {
                    label5.Enabled = false;
                }
                else if (key == "F6")
                {
                    label6.Enabled = false;
                }
                else if (key == "F7")
                {
                    label7.Enabled = false;
                }
                else if (key == "F8")
                {
                    label8.Enabled = false;
                }
                else if (key == "F9")
                {
                    label9.Enabled = false;
                }
                else if (key == "F10")
                {
                    label10.Enabled = false;
                }
                else if (key == "F11")
                {
                    label11.Enabled = false;
                }

                Program.Failed = true;
            }

            Program.ProgramHotkeys.Add(id, key);
        }

        private void SetGUIandHotkeys()
        {
            cycleOnlyToolStripMenuItem.Checked = Settings.Mode == 1;
            cycleWFunctionsToolStripMenuItem.Checked = Settings.Mode == 2;
            functionsOnlyToolStripMenuItem.Checked = Settings.Mode == 3;
            cycleAndPasteToolStripMenuItem.Checked = Settings.Mode == 4;
            pasteOnlyToolStripMenuItem.Checked = Settings.Mode == 5;

            SetHotkeys(new string[11] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11" });
        }

        private void SetHotkeys(string[] hklist)
        {
            if (HotkeyComm == null)
            {
                HotkeyComm = new HotkeyCommand(this)
                {
                    SetHotkeysGlobally = true,
                    SetSuppressExceptions = false
                };
                HotkeyComm.KeyActionCall += Actions.OnKeyAction; //Do work on keypress using the Action class
                HotkeyComm.KeyRegisteredCall += Registrations;
                HotkeyComm.KeyUnregisteredCall += UnRegistrations;
                Actions.ActionComplete += OnActionComplete; //Followup on completed task from the Action class
            }

            if (HotkeyComm.IsRegistered)
            {
                HotkeyComm.StopHotkeys();
            }

            HotkeyComm.HotkeyAddKeyList(hklist, true);
            if (Settings.UseEscape)
            {
                if (!label1.Text.Contains("Esc = Double Click"))
                {
                    label1.Text += "\r\nEsc = Double Click";
                }

                if (!HotkeyComm.HotkeyDictionary.Values.Contains("Escape", StringComparer.InvariantCultureIgnoreCase))
                {
                    HotkeyComm.HotkeyAddKey("Escape");
                }
            }
            else if (!Settings.UseEscape)
            {
                if (label1.Text.Contains("Esc = Double Click"))
                {
                    label1.Text = label1.Text.Replace("Esc = Double Click", "");
                }

                if (HotkeyComm.HotkeyDictionary.Values.Contains("Escape", StringComparer.InvariantCultureIgnoreCase))
                {
                    HotkeyComm.HotkeyAddKey("Escape");
                }
            }

            HotkeyComm.StartHotkeys();
            if (Program.Failed && !Settings.HideHotkeyErrors)
            {
                MessageBox.Show("One or more Hotkeys failed to register.");
            }
        }

        private void SetMenuItems()
        {
            useEscToDblClickToolStripMenuItem.Checked = Settings.UseEscape;
            useClipboardPasteToolStripMenuItem.Checked = Settings.UseSendCTRLV;
            useSendKeysToolStripMenuItem.Checked = Settings.UseSendKeys;
            useSendKeystrokeswDelayToolStripMenuItem.Checked = Settings.UseSendKeysDelay;
            createUniqueListToolStripMenuItem.Checked = Settings.UniqueList;
            sortListToolStripMenuItem.Checked = Settings.SortList;
            trimWhitespaceToolStripMenuItem.Checked = Settings.TrimWS;
            disableHotkeyErrorsToolStripMenuItem.Checked = Settings.HideHotkeyErrors;
        }

        private void UnRegistrations(string key, short id)
        {
            Program.ProgramHotkeys.Remove(id);
        }

        #region MenuFunctions

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.AboutToolStripMenuItem();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.NewToolStripMenuItem(this, comboBox1, label2, label3);
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void CreateUniqueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.CreateUniqueListToolStripMenuItem(sender, comboBox1, label2);
        }

        private void DisableHotkeyErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.DisableHotkeyErrorsToolStripMenuItem(sender);
        }

        private void ModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.ModeToolStripMenuItem(sender, this);
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.NewToolStripMenuItem(this, comboBox1, label2, label3);
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.OpenToolStripMenu(this);
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.PauseToolStripMenuItem(sender, HotkeyComm);
        }

        private void RemoveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.RemoveItemToolStripMenuItem(comboBox1, label2);
        }

        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.SaveAsToolStripMenu(this);
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.SaveToolStripMenu(this);
        }

        private void SortListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.SortListToolStripMenuItem(sender, comboBox1, label2);
        }

        private void TrimWhitespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.TrimWhitespaceToolStripMenuItem(sender, comboBox1, label2);
        }

        private void UseEscToDblClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.UseEscToDblClickToolStripMenuItem(sender, HotkeyComm, label1);
        }

        private void UseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericMenuFunctions.UseToolStripMenuItem(sender);
        }

        #endregion MenuFunctions
    }
}