using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public static class Actions
    {
        private static Type myType = Type.GetType("Clipboard_Cycler.Actions");
        //private static List<string> myActions = new List<string>()
        //{
        //    "copy",
        //    "paste",
        //    "enter",
        //    "run",
        //    "paste2"
        //};
        public delegate void ActionCompleteEventHandler(string myAction, dynamic optional = null);
        public static event ActionCompleteEventHandler ActionComplete;

        public static void onKeyAction(Form f, short k)
        {
            myType.GetMethod("HandleHotkeyF" + k.ToString(), BindingFlags.Static | BindingFlags.NonPublic).Invoke(f, null);
        }//Fires from HotkeyCommander and triggers an event using Reflection

        public static void SetForm(short m)
        {
            Settings.Mode = m;
            Settings.Save();
            Application.Restart();
        }

        private static void HandleHotkeyF1()
        {
            List<string> myList = Program.myList;
            int newDataCount = myList.Count;
            try
            {
                string temp = Clipboard.GetText();
                Clipboard.Clear();
                SendKeys.Send("^c");
                List<string> data = new List<string>(Clipboard.GetText().Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.None));
                data.RemoveAll(x => x == "");
                if (data.Count > 0)
                {
                    foreach (string s in data)
                    { myList.Add(s); }

                    if (Settings.SortList)
                    { myList.Sort(); }

                    if (Settings.UniqueList)
                    { myList = myList.Distinct().ToList(); }
                }
                Clipboard.SetText(temp);
                Program.myIndex = 0;
            }
            catch
            { }
            newDataCount -= myList.Count;
            ActionComplete?.Invoke("copy", newDataCount);
        }
        private static void HandleHotkeyF2()
        {
            List<string> myList = Program.myList;
            string selectedText = "";
            try
            {
                selectedText = myList[Program.myIndex];
                Clipboard.SetText(selectedText);
                SendKeys.Send("^v");
                Program.myIndex++; if (Program.myIndex > myList.Count) { Program.myIndex = myList.Count; }
            }
            catch
            { }
            ActionComplete?.Invoke("paste", selectedText);
        }
        private static void HandleHotkeyF3()
        {
            SendKeys.Send("{Enter}");
            ActionComplete?.Invoke("enter");
        }
        private static void HandleHotkeyF4() => MessageBox.Show("F4");
        private static void HandleHotkeyF5() => MessageBox.Show("F5");
        private static void HandleHotkeyF6() => MessageBox.Show("F6");
        private static void HandleHotkeyF7() => MessageBox.Show("F7");
        private static void HandleHotkeyF8() => MessageBox.Show("F8");
        private static void HandleHotkeyF9() => MessageBox.Show("F9");
        private static void HandleHotkeyF10() => MessageBox.Show("F10");
        private static void HandleHotkeyF11() => MessageBox.Show("F11");
        private static void HandleHotkeyF12() => MessageBox.Show("F12");
    }
}
