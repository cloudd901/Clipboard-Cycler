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
        private HotkeyCommand HotkeyComm { get; set; } = null;

        public Form1()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();

            Text = Program.MyTitle;
            Size = Settings.WinSize;
            Location = Settings.WinLoc;

            SetMenuItems();
            SetGUIandHotkeys();

            Actions.HandleFileOpen(Settings.SavedList.Replace("~`", Environment.NewLine));
        }

        private void SetGUIandHotkeys()
        {
            cycleOnlyToolStripMenuItem.Checked = Settings.Mode == 1 ? true : false;
            cycleWFunctionsToolStripMenuItem.Checked = Settings.Mode == 2 ? true : false;
            functionsOnlyToolStripMenuItem.Checked = Settings.Mode == 3 ? true : false;
            cycleAndPasteToolStripMenuItem.Checked = Settings.Mode == 4 ? true : false;
            pasteOnlyToolStripMenuItem.Checked = Settings.Mode == 5 ? true : false;

            SetHotkeys(new string[] { "F1", "F2", "F3" });
        }

        private void SetHotkeys(string[] hklist)
        {
            if (HotkeyComm == null)
            {
                HotkeyComm = new HotkeyCommand(this);
                HotkeyComm.SetHotkeysGlobally = true;
                HotkeyComm.SetSuppressExceptions = false;
                HotkeyComm.KeyActionCall += Actions.onKeyAction; //Do work on keypress using the Action class
                HotkeyComm.KeyRegisteredCall += Registrations;
                HotkeyComm.KeyUnregisteredCall += UnRegistrations;
                Actions.ActionComplete += OnActionComplete; //Followup on completed task from the Action class
            }
            if (HotkeyComm.IsRegistered) { HotkeyComm._StopHotkeys(); }
            HotkeyComm.HotkeyRegisterList(hklist, true);
            if (Settings.UseEscape)
            {
                if (!label1.Text.Contains("Esc = Double Click")) { label1.Text += "\r\nEsc = Double Click"; }
                if (!HotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { HotkeyComm.HotkeyRegister("Escape"); }
            }
            else if (!Settings.UseEscape)
            {

                if (label1.Text.Contains("Esc = Double Click")) { label1.Text = label1.Text.Replace("Esc = Double Click", ""); }
                if (HotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { HotkeyComm.HotkeyUnregister("Escape"); }
            }
            HotkeyComm._StartHotkeys();
            if (Program.Failed && !Settings.HideHotkeyErrors) { MessageBox.Show("One or more Hotkeys failed to register."); }
        }
        private void Registrations(bool result, string key, short id)
        {
            if (result == false)
            {
                if (key == "F1" || key == "F2") { comboBox1.Enabled = false; }
                Program.Failed = true;
            }
            Program.ProgramHotkeys.Add(id, key);
        }
        private void UnRegistrations(string key, short id)
        {
            Program.ProgramHotkeys.Remove(id);
        }
        private void OnActionComplete(Actions.myActions action, dynamic optional = null)
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
                Program.MyIndex = comboBox1.SelectedIndex;
                if (Program.EndOfListPasted) { label2.Text = "End/" + comboBox1.Items.Count; }
            }
            else if (action == Actions.myActions.Esc)
            {
                Program.Mouse._DoubleClick();
            }
        }//Fires from Actions after an action has been completed.

        private void CopyFromListToCombo()
        {
            comboBox1.Items.Clear();
            foreach (string s in Program.MyList)
            { comboBox1.Items.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }
        private void CopyFromComboToList()
        {
            Program.MyList.Clear();
            foreach (string s in comboBox1.Items)
            { Program.MyList.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }
        private void CopyFromReset()
        {
            Program.MyIndex = 0;
            try { comboBox1.SelectedIndex = 0; } catch { }
            label2.Text = comboBox1.Items.Count > 0 ? "1/" + comboBox1.Items.Count : label2.Text = "0/0";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SavedList = String.Join("~`", comboBox1.Items.Cast<string>());
            Settings.WinSize = this.Size;
            Settings.WinLoc = this.Location;
            Settings.Save();
            if (HotkeyComm != null) { HotkeyComm.Dispose(); HotkeyComm = null; }
            if (!Actions.SwitchingForms) { Environment.Exit(0); }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.EndOfListPasted = false;
            Program.MyIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }
        private void Label1_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.EndsWith("\r\n")) { ((Label)sender).Text = ((Label)sender).Text.Trim(); }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Actions.SwitchingForms = false;
        }

    }
}
