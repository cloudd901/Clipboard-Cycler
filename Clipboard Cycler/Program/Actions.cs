using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MouseCommands;

namespace Clipboard_Cycler
{
    public static class Actions
    {

        private static Type myType = Type.GetType("Clipboard_Cycler.Actions");
        public enum myActions
        {
            Copy,
            Paste,
            Enter,
            Run,
            Paste2,
            Esc
        };

        public delegate void ActionCompleteEventHandler(myActions action, dynamic optional = null);
        public static event ActionCompleteEventHandler ActionComplete;

        public static void onKeyAction(Form form, short id, string key)
        {
            try
            {
                if (key.Contains("}")) { key = key.Replace("{", "").Replace("}", ""); }
                myType.GetMethod("HandleHotkey" + key, BindingFlags.Static | BindingFlags.NonPublic).Invoke(form, null);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }//Fires from HotkeyCommander and triggers an event using Reflection

        public static void SetForm(short m, Form f)
        {
            if (Settings.Mode != m)
            {
                Settings.Mode = m;
                Settings.Save();
                CallRestart(f);
            }
        }
        public static void CallRestart(Form f)
        {
            f.Close();
            Application.Restart();
        }

        public static void HandleFileOpen(string text = null)
        {
            int newDataCount = 0;
            List<string> myList;
            if (string.IsNullOrWhiteSpace(text))
            {
                myList = Program.myList;
                newDataCount = myList.Count;
            }
            else
            {
                myList = new List<string>();
            }
            try
            {
                List<string> data;
                string temp = Clipboard.GetText();
                if (string.IsNullOrWhiteSpace(text))
                {
                    Clipboard.Clear();
                    SendKeys.Send("^c");
                    data = new List<string>(Clipboard.GetText().Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.None));
                }
                else
                {
                    data = new List<string>(text.Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.None));
                }
                data.RemoveAll(x => x == "");
                if (data.Count > 0)
                {
                    foreach (string s in data)
                    { myList.Add(Settings.TrimWS ? s.Trim() : s); }

                    if (Settings.SortList)
                    { myList.Sort(); }

                    if (Settings.UniqueList)
                    { myList = myList.Distinct().ToList(); }
                }
                Program.myList = myList;
                Clipboard.SetText(temp);
                Program.myIndex = 0;
            }
            catch
            { }
            newDataCount -= myList.Count;
            ActionComplete?.Invoke(myActions.Copy, newDataCount);
        }

        public static void PasteString(string s)
        {
            try
            {
                Clipboard.SetText(s);
                if (Settings.UseSendCTRLV) { SendKeys.Send("^v"); System.Threading.Tasks.Task.Delay(100).Wait(); }
                else { foreach (char c in s) { SendKeys.Send(c.ToString()); System.Threading.Tasks.Task.Delay(5).Wait(); } }
            }
            catch
            { }
        }
        private static string FixString(string s)
        {
            if (s == "+" || s == "^" || s == "%") { s = "{" + s + "}"; }
            return s;
        }
        public static void RunProcess(string s, string[] a = null)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = s;
            try { start.Arguments = $"\"{string.Join("\",\"", a)}\""; } catch { }
            try { Process.Start(start); }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }

        //==========================================================
        //====================Main Hotkeys F1-F3====================
        //==========================================================
        private static void CopyPressed()
        {
            int newDataCount = 0;
            List<string> myList;
            myList = Program.myList;
            newDataCount = myList.Count;
            try
            {
                List<string> data;
                string temp = Clipboard.GetText();
                Clipboard.Clear();
                System.Threading.Tasks.Task.Delay(50).Wait();
                SendKeys.Send("^c");
                System.Threading.Tasks.Task.Delay(100).Wait();
                data = new List<string>(Clipboard.GetText().Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.None));
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
                Program.myList = myList;
                Clipboard.SetText(temp);
                Program.myIndex = 0;
            }
            catch
            { }
            newDataCount = newDataCount==0 ? myList.Count: newDataCount-myList.Count;
            ActionComplete?.Invoke(myActions.Copy, newDataCount);
        }
        private static void PastePressed()
        {
            if (Program.myIndex == Program.myList.Count-1 && Program.endOfListPasted == true)
            { }
            else
            {
                if (Program.myIndex == Program.myList.Count-1) { Program.endOfListPasted = true; }
                else { Program.endOfListPasted = false; }
                List<string> myList = Program.myList;
                string selectedText = "";
                try
                {
                    PasteString(myList[Program.myIndex]);
                    Program.myIndex++; if (Program.myIndex > myList.Count) { Program.myIndex = myList.Count; }
                }
                catch
                { }
                ActionComplete?.Invoke(myActions.Paste, selectedText);
            }
        }
        private static void EnterPressed()
        {
            SendKeys.Send("{Enter}");
            ActionComplete?.Invoke(myActions.Enter);
        }
        private static void HandleHotkeyF1()
        {
            if (Settings.Mode == 1 || Settings.Mode == 2 || Settings.Mode == 3)
            {
                CopyPressed();
            }
            else if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F1"); }
        }
        private static void HandleHotkeyF2()
        {
            if (Settings.Mode == 1 || Settings.Mode == 2 || Settings.Mode == 3)
            {
                PastePressed();
            }
            else if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F2"); }
        }
        private static void HandleHotkeyF3()
        {
            if (Settings.Mode == 1 || Settings.Mode == 2 || Settings.Mode == 3)
            {
                EnterPressed();
            }
            else if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F3"); }
        }

        //==========================================================
        //====================Alt Hotkeys F4-F12====================
        //==========================================================
        private static void HandleHotkeyF4()
        {
            if (Settings.Mode == 2 || Settings.Mode == 3)
            { ActionComplete?.Invoke(myActions.Run, "F4"); }
            else if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F4"); }
        }
        private static void HandleHotkeyF5()
        {
            if (Settings.Mode == 2 || Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F5"); }
            else if (Settings.Mode == 3)
            { ActionComplete?.Invoke(myActions.Run, "F5"); }
        }
        private static void HandleHotkeyF6()
        {
            if (Settings.Mode == 2 || Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F6"); }
            else if (Settings.Mode == 3)
            { ActionComplete?.Invoke(myActions.Run, "F6"); }
        }
        private static void HandleHotkeyF7()
        {
            if (Settings.Mode == 2 || Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F7"); }
            else if (Settings.Mode == 3)
            { ActionComplete?.Invoke(myActions.Run, "F7"); }
        }
        private static void HandleHotkeyF8()
        {
            if (Settings.Mode == 2 || Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F8"); }
            else if (Settings.Mode == 3)
            { ActionComplete?.Invoke(myActions.Run, "F8"); }
        }
        private static void HandleHotkeyF9()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F9"); }
        }
        private static void HandleHotkeyF10()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F10"); }
        }
        private static void HandleHotkeyF11()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F11"); }
        }
        private static void HandleHotkeyF12()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "F12"); }
        }
        private static void HandleHotkeyCTRLF12()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "{CTRL}F12"); }
        }

        //==========================================================
        //=======================Other Hotkeys======================
        //==========================================================
        private static void HandleHotkeyEscape()
        {
            ActionComplete?.Invoke(myActions.Esc);
        }
    }
}
