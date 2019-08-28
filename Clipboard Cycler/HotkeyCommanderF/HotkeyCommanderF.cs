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
     * new HotKeys class requires a <Form> and a List<short>.
     * 
     * The <Form> will be used as the button press receiver.
     * 
     * HKeys List<short> will need to be set before use.
     * This takes number values between 1 and 12 then convert them to F* keys.
     * Most calls to the HotKeyFunctions are dynamically called using Reflection.
     * 
     * InitiateHotKeys() will take the HKeys list and call the hooks.
     * HotkeyCommand.KeyActionCall action will fire when hotkey is pressed.
     */

    class HotkeyCommand
    {
        public delegate void KeyActionCallEventHandler(Form f, short k);
        public event KeyActionCallEventHandler KeyActionCall;

        internal void OnKeyActionCall(Form f, short k)
        {
            KeyActionCall?.Invoke(f, k);
        }//Received from 'HotkeysExtension'. Alert new event to HotkeyCommand instance.

        private readonly Dictionary<short, string> _keyvaluepairs = new Dictionary<short, string>();
        private readonly Form form;
        private bool registered = false;


        public HotkeyCommand(Form f, short[] newKeyList)
        { form = f; HKeys = newKeyList.ToList(); }

        public List<short> HKeys { get; set; } = new List<short>();
        public ComboBox HKComboBoxList { get; set; }
        public Label HKCountingLabel { get; set; } = null;
        public Label HKTextLabel { get; set; } = null;
        public bool SortList { get; set; } = false;
        public bool UniqueList { get; set; } = false;

        public void InitiateHotKeys()
        {
            if (registered)
            { throw new InvalidOperationException("HotkeyCommanderF is already Initiated."); }
            else
            { registered = true; }

            try
            { (form as HotkeysExtensionForm).KeyPressedCall += OnKeyActionCall; }
            catch
            { throw new InvalidCastException("Unable to subscribe to KeyCalled event. Please ensure your Form is using the HotkeysExtension with KeyPressedCall event."); }


            if (HKeys.Count <= 0)
            { throw new InvalidFilterCriteriaException("Please set HKeys - Numbers 1 through 12 to corrispond to F* keys."); }
            try
            {
                foreach (short i in HKeys)
                {
                    _keyvaluepairs.Add(i, "F" + i);
                    new KeyHandler((Keys)Enum.Parse(typeof(Keys), "F" + i), form.Handle, i).Register();
                }
            }
            catch
            {
                throw new Exception("An unknown error occurred while registering shortcutkeys.");
            }
        }


    }
}
