using PCAFFINITY;
using System;
using System.IO;
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
    public partial class Form5 : HotkeysExtensionForm
    {
        public Form5()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();

            Text = Program.MyTitle;
            Size = Settings.WinSize;
            Location = Settings.WinLoc;
            textBox1.Text = Settings.Form5Fields[0];
            textBox2.Text = Settings.Form5Fields[1];
            textBox3.Text = Settings.Form5Fields[2];
            textBox4.Text = Settings.Form5Fields[3];
            textBox5.Text = Settings.Form5Fields[4];
            textBox6.Text = Settings.Form5Fields[5];
            textBox7.Text = Settings.Form5Fields[6];
            textBox8.Text = Settings.Form5Fields[7];
            textBox9.Text = Settings.Form5Fields[8];
            textBox10.Text = Settings.Form5Fields[9];
            textBox11.Text = Settings.Form5Fields[10];
            textBox12.Text = Settings.Form5Fields[11];

            SetMenuItems();
            SetGUIandHotkeys();

            Actions.HandleFileOpen(Settings.SavedList.Replace("~`", Environment.NewLine));
        }

        private HotkeyCommand HotkeyComm { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox1.Text = open.FileName; }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.WinSize = this.Size;
            Settings.WinLoc = this.Location;
            Settings.Form5Fields[0] = textBox1.Text;
            Settings.Form5Fields[1] = textBox2.Text;
            Settings.Form5Fields[2] = textBox3.Text;
            Settings.Form5Fields[3] = textBox4.Text;
            Settings.Form5Fields[4] = textBox5.Text;
            Settings.Form5Fields[5] = textBox6.Text;
            Settings.Form5Fields[6] = textBox7.Text;
            Settings.Form5Fields[7] = textBox8.Text;
            Settings.Form5Fields[8] = textBox9.Text;
            Settings.Form5Fields[9] = textBox10.Text;
            Settings.Form5Fields[10] = textBox11.Text;
            Settings.Form5Fields[11] = textBox12.Text;
            Settings.Save();
            if (HotkeyComm != null)
            {
                HotkeyComm.Dispose();
                HotkeyComm = null;
            }

            if (!Actions.SwitchingForms)
            {
                Environment.Exit(0);
            }
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            Actions.SwitchingForms = false;
        }

        private void OnActionComplete(Actions.MyActions action, dynamic optional = null)
        {
            /*
             * Modify the Form after the Action is Completed.
             * Use myAction to determine what action occurred.
             * Use Optional for additional information sent from Actions.
             */

            if (action == Actions.MyActions.Paste2)
            {
                string key = (string)optional;
                if (key == "F1")
                { Actions.PasteString(textBox1.Text); }
                else if (key == "F2")
                { Actions.PasteString(textBox2.Text); }
                else if (key == "F3")
                { Actions.PasteString(textBox3.Text); }
                else if (key == "F4")
                { Actions.PasteString(textBox4.Text); }
                else if (key == "F5")
                { Actions.PasteString(textBox5.Text); }
                else if (key == "F6")
                { Actions.PasteString(textBox6.Text); }
                else if (key == "F7")
                { Actions.PasteString(textBox7.Text); }
                else if (key == "F8")
                { Actions.PasteString(textBox8.Text); }
                else if (key == "F9")
                { Actions.PasteString(textBox9.Text); }
                else if (key == "F10")
                { Actions.PasteString(textBox10.Text); }
                else if (key == "F11")
                { Actions.PasteString(textBox11.Text); }
                else if (key == "F12" || key == "{Shift}F12" || key == "{CTRL}F12" || key == "{ALT}F12")
                { Actions.PasteString(textBox12.Text); }
            }
            else if (action == Actions.MyActions.Esc)
            {
                Program.Mouse._DoubleClick();
            }
        }

        private void Registrations(bool result, string key, short id)
        {
            if (!result)
            {
                Program.Failed = true;
                if (key == "F1") { label1.Enabled = false; }
                else if (key == "F2") { label2.Enabled = false; }
                else if (key == "F3") { label3.Enabled = false; }
                else if (key == "F4") { label4.Enabled = false; }
                else if (key == "F5") { label5.Enabled = false; }
                else if (key == "F6") { label6.Enabled = false; }
                else if (key == "F7") { label7.Enabled = false; }
                else if (key == "F8") { label8.Enabled = false; }
                else if (key == "F9") { label9.Enabled = false; }
                else if (key == "F10") { label10.Enabled = false; }
                else if (key == "F11") { label11.Enabled = false; }
                else if (key == "F12")
                {
                    Program.Failed = false; //set to false, will try again with ctrlf12
                    label12.Enabled = false;
                }
                else if (key == "{CTRL}F12") { Program.Failed = false; }//try2
                else if (key == "{Shift}F12") { Program.Failed = false; }//try3
                else if (key == "{ALT}F12") { }//try4
            }

            if (result && key == "{Shift}F12")
            {
                label12.Enabled = true;
                label12.Text = "{Shift}F12 =";
                textBox12.Location = new System.Drawing.Point(69, 231);
                textBox12.Size = new System.Drawing.Size(158, 18);
            }
            else if (result && key == "{CTRL}F12")
            {
                label12.Enabled = true;
                label12.Text = "{CTRL}F12 =";
                textBox12.Location = new System.Drawing.Point(69, 231);
                textBox12.Size = new System.Drawing.Size(158, 18);
            }
            else if (result && key == "{ALT}F12")
            {
                label12.Enabled = true;
                label12.Text = "{ALT}F12 =";
                textBox12.Location = new System.Drawing.Point(69, 231);
                textBox12.Size = new System.Drawing.Size(158, 18);
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

            SetHotkeys(new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" });
            if (!label12.Enabled)
            {
                //F12 Hotkey failed. Try using an alternate F12 Hotkey:
                HotkeyComm.StopHotkeys();
                HotkeyComm.HotkeyRemoveKey("F12");
                HotkeyComm.HotkeyAddKey("{CTRL}F12");
                HotkeyComm.StartHotkeys();
                if (!label12.Enabled)
                {
                    //F12 Hotkey failed. Try using an alternate F12 Hotkey:
                    HotkeyComm.StopHotkeys();
                    HotkeyComm.HotkeyRemoveKey("{CTRL}F12");
                    HotkeyComm.HotkeyAddKey("{Shift}F12");
                    HotkeyComm.StartHotkeys();
                    if (!label12.Enabled)
                    {
                        //F12 Hotkey failed. Try using an alternate F12 Hotkey:
                        HotkeyComm.StopHotkeys();
                        HotkeyComm.HotkeyRemoveKey("{Shift}F12");
                        HotkeyComm.HotkeyAddKey("{ALT}F12");
                        HotkeyComm.StartHotkeys();
                        if (!label12.Enabled)
                        {
                            HotkeyComm.StopHotkeys();
                            HotkeyComm.HotkeyRemoveKey("{ALT}F12");
                            HotkeyComm.StartHotkeys();
                        }
                    }
                }
            }
            if (Program.Failed && !Settings.HideHotkeyErrors) { MessageBox.Show("One or more Hotkeys failed to register."); }
        }

        private void SetHotkeys(string[] hklist)
        {
            if (HotkeyComm == null)
            {
                HotkeyComm = new HotkeyCommand(this);
                HotkeyComm.SetHotkeysGlobally = true;
                HotkeyComm.SetSuppressExceptions = false;
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
            HotkeyComm.StartHotkeys();
        }

        private void UnRegistrations(string key, short id)
        {
            Program.ProgramHotkeys.Remove(id);
        }

        //Fires from Actions after an action has been completed.
    }
}