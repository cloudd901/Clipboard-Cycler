using PCAFFINITY;
using System;
using System.Drawing;
using System.IO;
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
    public partial class Form3 : HotkeysExtensionForm
    {
        private RoundedButtons MyRoundedButtons1;

        private RoundedButtons MyRoundedButtons2;

        public Form3()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();
        }

        private HotkeyCommand HotkeyComm { get; set; }

        public void CopyFromReset()
        {
            Program.MyIndex = 0;
            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch
            {
                //  Ignore
            }

            label2.Text = comboBox1.Items.Count > 0 ? "1/" + comboBox1.Items.Count : label2.Text = "0/0";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = open.FileName;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = open.FileName;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = open.FileName;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = open.FileName;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.EndOfListPasted = false;
            Program.MyIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SavedList = String.Join("~`", comboBox1.Items.Cast<string>());
            Settings.WinSize = this.Size;
            Settings.WinLoc = this.Location;
            Settings.Form3Fields[0] = textBox1.Text;
            Settings.Form3Fields[1] = textBox2.Text;
            Settings.Form3Fields[2] = textBox3.Text;
            Settings.Form3Fields[3] = textBox4.Text;
            Settings.Form3Fields[4] = textBox5.Text;
            Settings.Save();
            HotkeyComm?.Dispose();
            HotkeyComm = null;

            if (!Actions.SwitchingForms)
            {
                Environment.Exit(0);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
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
            MyRoundedButtons1.PaintButton(button6);

            MyRoundedButtons2 = new RoundedButtons()
            {
                Btn_ShadowLocation = ShadowPosition.BottomRight,
                MainShadowColor = Color.LightSteelBlue,
                Btn_CornerRadius = 9,
                Btn_ShadowWidth = ShadowSize.None,
                Btn_TextPadding = new Padding(0, 0, 0, 5),
                Btn_LineWidth = 0,
                MainTextColor = Color.Black,
                HighlightBGColor = Color.LightSteelBlue
            };
            MyRoundedButtons2.PaintButton(button1);
            MyRoundedButtons2.PaintButton(button2);
            MyRoundedButtons2.PaintButton(button3);
            MyRoundedButtons2.PaintButton(button4);
            MyRoundedButtons2.PaintButton(button5);

            Text = Program.MyTitle;
            Size = Settings.WinSize;
            Location = Settings.WinLoc;
            textBox1.Text = Settings.Form3Fields[0];
            textBox2.Text = Settings.Form3Fields[1];
            textBox3.Text = Settings.Form3Fields[2];
            textBox4.Text = Settings.Form3Fields[3];
            textBox5.Text = Settings.Form3Fields[4];

            SetMenuItems();
            SetGUIandHotkeys();

            Actions.HandleFileOpen(Settings.SavedList.Replace("~`", Environment.NewLine));
        }

        private void Form3_Shown(object sender, EventArgs e)
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
            else if (action == Actions.MyActions.Run)
            {
                string s = "";
                if ((string)optional == "F4")
                {
                    s = textBox1.Text;
                }
                if ((string)optional == "F5")
                {
                    s = textBox2.Text;
                }
                if ((string)optional == "F6")
                {
                    s = textBox3.Text;
                }
                if ((string)optional == "F7")
                {
                    s = textBox4.Text;
                }
                if ((string)optional == "F8")
                {
                    s = textBox5.Text;
                }

                string[] a = null;
                if (s.Contains('"'))
                {
                    string args = s.Split('"')[1];
                    s = s.Replace($"\"{args}\"", "").Trim();
                    a = args.Split(',').Select(x => x.Trim()).ToArray();
                }

                Actions.RunProcess(s, a);
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
                    label4.Enabled = false;
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

            SetHotkeys(new string[8] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" });
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
                    HotkeyComm.HotkeyRemoveKey("Escape");
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
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