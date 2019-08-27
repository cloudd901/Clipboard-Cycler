using System;
using System.Windows.Forms;

namespace HotkeyCommanderF.HKCFormExtension
{
    public class HotkeysExtensionForm : Form
    {

        public delegate void KeyPressedCallEventHandler(object source, IntPtr k);
        public event KeyPressedCallEventHandler KeyPressedCall;
        protected override void WndProc(ref Message m)
        {
            KeyPreview = true;
            if (m.Msg == 0x0312)//Msg ID for Hotkeys
            {
                OnKeyPressedCall(m.WParam);//Custom Shortcut ID (1-12)
            }

            base.WndProc(ref m);
        }
        public virtual void OnKeyPressedCall(IntPtr k)
        {
            KeyPressedCall?.Invoke(this, k);
        }
    }
}
