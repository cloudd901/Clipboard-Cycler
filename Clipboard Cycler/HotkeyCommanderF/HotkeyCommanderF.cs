using HKCHandler;
using HotkeyCommanderF.HKCFormExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HotkeyCommanderF
{
    /* 
     * new HotKeys class requires a <Form>, a <ComboBox> and a List<short>.
     * 
     * The <Form> will be used as the button press receiver.
     * 
     * A <ComboBox> is used to store and retrieve the clipboard during events.
     * 
     * It's also optional to use a Counter <Label> and Last Pasted <Label>.
     * --- HKCountingLabel Example display: "10/100"
     * --- HKTextLabel Example display: "Last Paste: This is the last texted pasted"
     * 
     * HKeys List<short> will need to be set before use.
     * This takes number values between 1 and 12 then convert them to F* keys.
     * Most calls to the HotKeyFunctions are dynamically called using Reflection.
     * 
     * InitiateHotKeys will take the HKeys list and call the hooks.
     */

    class HotkeyCommand
    {
        private readonly Dictionary<IntPtr, string> _keyvaluepairs = new Dictionary<IntPtr, string>();
        private readonly Form form;
        private bool registered = false;

        public HotkeyCommand(Form f, ComboBox newComboBoxList)
            : this(f, newComboBoxList, null, null, null)
        { }
        public HotkeyCommand(Form f, ComboBox newComboBoxList, short[] newKeyList)
            : this(f, newComboBoxList, newKeyList, null, null)
        { }
        public HotkeyCommand(Form f, ComboBox newComboBoxList, short[] newKeyList, Label newCountingLabel = null, Label newTextLabel = null)
        {
            form = f;
            HKComboBoxList = (newComboBoxList == null) ? new ComboBox() : newComboBoxList;
            HKeys = newKeyList.ToList();
            HKCountingLabel = (newCountingLabel == null) ? new Label() : newCountingLabel;
            HKTextLabel = (newTextLabel == null) ? new Label() : newTextLabel;
        }

        public List<short> HKeys { get; set; } = new List<short>();
        public ComboBox HKComboBoxList { get; set; }
        public Label HKCountingLabel { get; set; } = null;
        public Label HKTextLabel { get; set; } = null;
        public bool SortList { get; set; } = false;
        public bool UniqueList { get; set; } = false;

        public void KeyCalled(object source, IntPtr k)
        {
            try
            {
                dynamic test = Type.GetType(GetType().Namespace + "." + GetType().Name)
                        .GetMethod("HandleHotkey" + _keyvaluepairs[k], BindingFlags.Instance | BindingFlags.NonPublic)
                        .Invoke(this, null);
            }
            catch
            {
                MessageBox.Show("Unable to process 'HandleHotkey" + _keyvaluepairs[k] + "'.", "KeyCalled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitiateHotKeys()
        {
            if (registered)
            {
                throw new InvalidOperationException("HotkeyCommanderF is already Initiated.");
            }
            else
            {
                registered = true;
            }

            try
            {
                (form as HotkeysExtensionForm).KeyPressedCall += KeyCalled;
            }
            catch
            {
                throw new InvalidCastException("Unable to subscribe to KeyCalled event. Please ensure your Form is using the HotkeysExtension with KeyPressedCall event.");
            }


            if (HKeys.Count <= 0)
            { throw new InvalidFilterCriteriaException("Please set HKeys - Numbers 1 through 12 to corrispond to F* keys."); }
            if (HKComboBoxList == null)
            { throw new InvalidFilterCriteriaException("Please set HKComboBoxList - The ComboBox control used to store your list."); }
            try
            {
                foreach (short i in HKeys)
                {
                    _keyvaluepairs.Add(new IntPtr(i), "F" + i);
                    new KeyHandler((Keys)Enum.Parse(typeof(Keys), "F" + i), form.Handle, i).Register();
                }
            }
            catch
            {
                throw new Exception("An unknown error occurred while registering shortcutkeys.");
            }
        }

        internal void HandleHotkeyF1()
        {
            try
            {
                ComboBox cb = HKComboBoxList;
                string temp = Clipboard.GetText();
                Clipboard.Clear();
                SendKeys.Send("^c");
                List<string> data = new List<string>(Clipboard.GetText().Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.None));
                data.RemoveAll(x => x == "");
                if (data.Count > 0)
                {
                    foreach (string s in data)
                    { cb.Items.Add(s); }
                    if (SortList)
                    { cb.Sorted = true; }
                    else
                    { cb.Sorted = false; }
                    if (UniqueList)
                    {
                        List<string> tempList = new List<string>();
                        foreach (string s in cb.Items)
                        { tempList.Add(s); }
                        tempList = tempList.Distinct().ToList();
                        cb.Items.Clear();
                        foreach (string s in tempList)
                        { cb.Items.Add(s); }
                    }
                    cb.SelectedIndex = 0;
                    HKCountingLabel.Text = "1/" + cb.Items.Count;
                    Clipboard.SetText(temp);
                }
            }
            catch { }
        }
        internal void HandleHotkeyF2()
        {
            int count = HKComboBoxList.Items.Count;
            int selectedIndex = HKComboBoxList.SelectedIndex;
            string selectedText = HKComboBoxList.Items[selectedIndex].ToString();

            Clipboard.SetText(selectedText);
            SendKeys.Send("^v");
            if (selectedIndex < count - 1)
            {
                selectedIndex++;
            }
            HKComboBoxList.SelectedIndex = selectedIndex;
            HKCountingLabel.Text = selectedIndex + 1 + "/" + count;
            HKTextLabel.Text = "Last Paste: " + selectedText;

        }
        internal void HandleHotkeyF3()
        {
            SendKeys.Send("{Enter}");
        }
        internal void HandleHotkeyF4() => MessageBox.Show("F4");
        internal void HandleHotkeyF5() => MessageBox.Show("F5");
        internal void HandleHotkeyF6() => MessageBox.Show("F6");
        internal void HandleHotkeyF7() => MessageBox.Show("F7");
        internal void HandleHotkeyF8() => MessageBox.Show("F8");
        internal void HandleHotkeyF9() => MessageBox.Show("F9");
        internal void HandleHotkeyF10() => MessageBox.Show("F10");
        internal void HandleHotkeyF11() => MessageBox.Show("F11");
        internal void HandleHotkeyF12() => MessageBox.Show("F12");
    }
}
