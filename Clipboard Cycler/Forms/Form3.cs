using HotkeyCommands;
using HotkeyCommands.HKCFormExtension;
using MouseCommands;
using System;
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
        public HotkeyCommand hotkeyComm;
        public MouseCommand mouse = new MouseCommand();
        public Form3()
        {
            //Program.myList is the master list of copied data.
            //comboBox1 is a secondary visual list of the same data.
            //Program.myIndex is the current index of myList and comboBox1.

            InitializeComponent();

            Text = Program.myTitle;
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
        public void SetGUIandHotkeys()
        {
            cycleOnlyToolStripMenuItem.Checked = Settings.Mode == 1 ? true : false;
            cycleWFunctionsToolStripMenuItem.Checked = Settings.Mode == 2 ? true : false;
            functionsOnlyToolStripMenuItem.Checked = Settings.Mode == 3 ? true : false;
            pasteOnlyToolStripMenuItem.Checked = Settings.Mode == 4 ? true : false;

            if (Settings.Mode == 3)
            {
                SetHotkeys(new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" });
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
                hotkeyComm.KeyRegisteredCall += Registrations;
                hotkeyComm.KeyUnregisteredCall += UnRegistrations;
                Actions.ActionComplete += OnActionComplete; //Followup on completed task from the Action class
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
        private void Registrations(bool result, string key, short id)
        {
            if (result == false)
            {
                if (key == "F1" || key == "F2") { comboBox1.Enabled = false; }
                // if (key == "F3") { label2.Enabled = false; }
                else if (key == "F4") { label4.Enabled = false; }
                else if (key == "F5") { label5.Enabled = false; }
                else if (key == "F6") { label6.Enabled = false; }
                else if (key == "F7") { label7.Enabled = false; }
                else if (key == "F8") { label8.Enabled = false; }
                Program.failed = true;
            }
            Program.programHotkeys.Add(id, key);
        }
        private void UnRegistrations(string key, short id)
        {
            Program.programHotkeys.Remove(id);
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
            else if (action == Actions.myActions.Run)
            {
                string s = "";
                if ((string)optional == "F4")
                { s = textBox1.Text; }
                if ((string)optional == "F5")
                { s = textBox2.Text; }
                if ((string)optional == "F6")
                { s = textBox3.Text; }
                if ((string)optional == "F7")
                { s = textBox4.Text; }
                if ((string)optional == "F8")
                { s = textBox5.Text; }

                string[] a = null;
                if (s.Contains('"'))
                {
                    string args = s.Split('"')[1];
                    s = s.Replace($"\"{args}\"", "").Trim();
                    a = args.Split(',').Select(x => x.Trim()).ToArray();
                }
                Actions.RunProcess(s, a);
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

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            if (hotkeyComm != null) { hotkeyComm.Dispose(); }
        }

        public void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.endOfListPasted = false;
            Program.myIndex = comboBox1.SelectedIndex;
            label2.Text = comboBox1.SelectedIndex + 1 + "/" + comboBox1.Items.Count;
        }

        public void Label1_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.EndsWith("\r\n")) { ((Label)sender).Text = ((Label)sender).Text.Trim(); }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox1.Text = open.FileName; }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox2.Text = open.FileName; }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox3.Text = open.FileName; }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox4.Text = open.FileName; }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Directory.GetCurrentDirectory();
            open.Filter = "Executable Files (*.exe, *.bat)|*.exe; *.bat|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            { textBox5.Text = open.FileName; }
        }
    }
}
