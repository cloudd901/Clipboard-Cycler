using PCAFFINITY;
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
    public partial class Form4 : HotkeysExtensionForm
    {
        public Form4()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();

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

        private HotkeyCommand HotkeyComm { get; set; } = null;

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.EndOfListPasted = false;
            Program.MyIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        private void CopyFromComboToList()
        {
            Program.MyList.Clear();
            foreach (string s in comboBox1.Items)
            { Program.MyList.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }

        private void CopyFromListToCombo()
        {
            comboBox1.Items.Clear();
            foreach (string s in Program.MyList)
            { comboBox1.Items.Add(Settings.TrimWS ? s.Trim() : s); }
            CopyFromReset();
        }

        private void CopyFromReset()
        {
            Program.MyIndex = 0;
            try { comboBox1.SelectedIndex = 0; } catch { }
            label2.Text = comboBox1.Items.Count > 0 ? "1/" + comboBox1.Items.Count : label2.Text = "0/0";
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

        private void Form4_Shown(object sender, EventArgs e)
        {
            Actions.SwitchingForms = false;
        }

        private void Label1_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.EndsWith("\r\n")) { ((Label)sender).Text = ((Label)sender).Text.Trim(); }
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
                CopyFromListToCombo();
            }
            else if (action == Actions.MyActions.Paste)
            {
                label3.Text = "Last Paste: " + (string)optional;
                try
                { comboBox1.SelectedIndex++; }
                catch { }
                Program.MyIndex = comboBox1.SelectedIndex;
                if (Program.EndOfListPasted) { label2.Text = "End/" + comboBox1.Items.Count; }
            }
            else if (action == Actions.MyActions.Paste2)
            {
                string pasteText = "";
                if ((string)optional == "F4")
                { pasteText = textBox4.Text; }
                else if ((string)optional == "F5")
                { pasteText = textBox5.Text; }
                else if ((string)optional == "F6")
                { pasteText = textBox6.Text; }
                else if ((string)optional == "F7")
                { pasteText = textBox7.Text; }
                else if ((string)optional == "F8")
                { pasteText = textBox8.Text; }
                else if ((string)optional == "F9")
                { pasteText = textBox9.Text; }
                else if ((string)optional == "F10")
                { pasteText = textBox10.Text; }
                else if ((string)optional == "F11")
                { pasteText = textBox11.Text; }

                Actions.PasteString(pasteText);
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
                if (key == "F1" || key == "F2") { comboBox1.Enabled = false; }
                // if (key == "F3") { label2.Enabled = false; }
                else if (key == "F4") { label10.Enabled = false; }
                else if (key == "F5") { label5.Enabled = false; }
                else if (key == "F6") { label6.Enabled = false; }
                else if (key == "F7") { label7.Enabled = false; }
                else if (key == "F8") { label8.Enabled = false; }
                else if (key == "F9") { label9.Enabled = false; }
                else if (key == "F10") { label10.Enabled = false; }
                else if (key == "F11") { label11.Enabled = false; }
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

            SetHotkeys(new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11" });
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

            if (HotkeyComm.IsRegistered) { HotkeyComm.StopHotkeys(); }
            HotkeyComm.HotkeyAddKeyList(hklist, true);
            if (Settings.UseEscape)
            {
                if (!label1.Text.Contains("Esc = Double Click")) { label1.Text += "\r\nEsc = Double Click"; }
                if (!HotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { HotkeyComm.HotkeyAddKey("Escape"); }
            }
            else if (!Settings.UseEscape)
            {
                if (label1.Text.Contains("Esc = Double Click")) { label1.Text = label1.Text.Replace("Esc = Double Click", ""); }
                if (HotkeyComm.HotkeyDictionary.Values.Contains("Escape")) { HotkeyComm.HotkeyAddKey("Escape"); }
            }
            HotkeyComm.StartHotkeys();
            if (Program.Failed && !Settings.HideHotkeyErrors) { MessageBox.Show("One or more Hotkeys failed to register."); }
        }

        private void UnRegistrations(string key, short id)
        {
            Program.ProgramHotkeys.Remove(id);
        }

        //Fires from Actions after an action has been completed.
    }
}