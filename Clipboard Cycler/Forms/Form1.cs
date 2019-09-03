using HotkeyCommands;
using HotkeyCommands.HKCFormExtension;
using MouseCommands;
using System;
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
    public partial class Form1 : HotkeysExtensionForm
    {
        public HotkeyCommand hotkeyComm;
        public MouseCommand mouse = new MouseCommand();

        public Form1()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();

            Text = Program.myTitle;
            Size = Settings.WinSize;
            Location = Settings.WinLoc;

            SetMenuItems();
            SetGUIandHotkeys();
            
            Actions.HandleFileOpen(Settings.SavedList.Replace("~`", Environment.NewLine));

        }
        public void SetGUIandHotkeys()
        {
            cycleOnlyToolStripMenuItem.Checked = Settings.Mode == 1 ? true : false;
            cycleWFunctionsToolStripMenuItem.Checked = Settings.Mode == 2 ? true : false;
            functionsOnlyToolStripMenuItem.Checked = Settings.Mode == 3 ? true : false;
            pasteOnlyToolStripMenuItem.Checked = Settings.Mode == 4 ? true : false;

            if (Settings.Mode == 1)
            {
                SetHotkeys(new string[] { "F1", "F2", "F3" });
            }
            else
            {
                //Actions.SetForm(Settings.Mode);
            }
        }

        public void SetHotkeys(string[] hklist)
        {
            if (hotkeyComm == null)
            {
                hotkeyComm = new HotkeyCommand(this);
                hotkeyComm.SetHotkeysGlobally = true;
                hotkeyComm.SetSuppressExceptions = false;
                hotkeyComm.KeyActionCall += Actions.onKeyAction; //Do work on keypress using the Action class
                Actions.ActionComplete += OnActionComplete; //Followup on completed task from the Action class
                hotkeyComm.KeyRegisteredCall += Registrations;
            }
            if (hotkeyComm.IsRegistered) { hotkeyComm._StopHotkeys(); }
            hotkeyComm.HotkeyRegisterList(hklist, true);
            if (Settings.UseEscape)
            {
                if (!label1.Text.Contains("Esc = Double Click")) { label1.Text += "\r\nEsc = Double Click"; }
                if (!hotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { hotkeyComm.HotkeyRegister("Escape"); }
            }
            else if (!Settings.UseEscape)
            {

                if (label1.Text.Contains("Esc = Double Click")) { label1.Text = label1.Text.Replace("Esc = Double Click", ""); }
                if (hotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { hotkeyComm.HotkeyUnregister("Escape"); }
            }
            hotkeyComm._StartHotkeys();
            if (Program.failed) { MessageBox.Show("One or more Hotkeys failed to register."); }
        }
        private void Registrations(bool result, string key)
        {
            if (result == false)
            {
                if (key == "F1" || key == "F2") { comboBox1.Enabled = false; }
                Program.failed = true;
            }
        }
        public void OnActionComplete(Actions.myActions action, dynamic optional = null)
        {
            /*
             * Modify the Form after the Action is Completed.
             * Use myAction to determine what action occurred.
             * Use Optional for additional information sent from Actions.
             */

            if (action == Actions.myActions.Copy)
            {
                CopyFromListToCombo();
            }
            else if (action == Actions.myActions.Paste)
            {
                label3.Text = "Last Paste: " + (string)optional;
                try
                { comboBox1.SelectedIndex++; }
                catch { }
                Program.myIndex = comboBox1.SelectedIndex;
                if (Program.endOfListPasted) { label2.Text = "End/" + comboBox1.Items.Count; }
            }
            else if (action == Actions.myActions.Esc)
            {
                mouse._DoubleClick();
            }
        }//Fires from Actions after an action has been completed.

        public void CopyFromListToCombo()
        {
            comboBox1.Items.Clear();
            foreach (string s in Program.myList)
            { comboBox1.Items.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }
        public void CopyFromComboToList()
        {
            Program.myList.Clear();
            foreach (string s in comboBox1.Items)
            { Program.myList.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }
        public void CopyFromReset()
        {
            Program.myIndex = 0;
            try { comboBox1.SelectedIndex = 0; } catch { }
            label2.Text = comboBox1.Items.Count > 0 ? "1/" + comboBox1.Items.Count : label2.Text = "0/0";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SavedList = String.Join("~`", comboBox1.Items.Cast<string>());
            Settings.WinSize = this.Size;
            Settings.WinLoc = this.Location;
            Settings.Save();
            if (hotkeyComm != null) { hotkeyComm.Dispose(); }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.endOfListPasted = false;
            Program.myIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }
        private void Label1_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.EndsWith("\r\n")) { ((Label)sender).Text = ((Label)sender).Text.Trim(); }
        }
    }
}
