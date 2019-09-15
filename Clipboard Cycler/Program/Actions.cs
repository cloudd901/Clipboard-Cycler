using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Clipboard_Cycler
{
    public static class Actions
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);

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

        public static event ActionCompleteEventHandler ActionComplete;
        public delegate void ActionCompleteEventHandler(myActions action, dynamic optional = null);
        

        public static void onKeyAction(Form form, short id, string key)
        {
            try
            {
                if (key == "{esc}" || key == "{escape}") { key = "{Escape}"; }
                if (key.Contains("}")) { key = key.Replace("{", "").Replace("}", ""); }
                myType.GetMethod("HandleHotkey" + key, BindingFlags.Static | BindingFlags.NonPublic).Invoke(form, null);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }//Fires from Program.hotkeyCommander and triggers an event using Reflection

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
            while (f.Visible) { Task.Delay(500).Wait(); }
            Task.Delay(500).Wait();
            Application.Restart();
            Environment.Exit(0);
        }

        public static void HandleFileOpen(string text = null)
        {
            int newDataCount = 0;
            List<string> myList;
            if (string.IsNullOrWhiteSpace(text))
            {
                myList = Program.MyList;
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
                Program.MyList = myList;
                Clipboard.SetText(temp);
                Program.MyIndex = 0;
            }
            catch
            { }
            newDataCount -= myList.Count;
            ActionComplete?.Invoke(myActions.Copy, newDataCount);
        }
        private static string GetWindowTitle(IntPtr handle)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        public static void PasteString(string s)
        {
            bool useSendMessage = false;
            IntPtr handle = GetForegroundWindow();
            string windowTitle = GetWindowTitle(handle);
            InputSimulator inputSimulator = new InputSimulator();

            if (windowTitle.Contains("Remote Desktop")) { useSendMessage = true; }
            try
            {
                Clipboard.SetText(s);
                string fixedData = "";
                if (Settings.UseSendCTRLV) { SendKeys.Send("^v"); Task.Delay(100).Wait(); }
                else
                {
                    int i = 1;
                    foreach (char c in s)
                    {
                        if (c == '{') { fixedData += c; continue; }
                        else if (fixedData != "") { fixedData += c; if (c != '}') { continue; } }
                        else { fixedData = FixString(c.ToString()); }

                        if (fixedData.StartsWith("{"))
                        {
                            string key = fixedData.Replace("{", "").Replace("}", "");
                            if (key == "esc" || key == "escape") { key = "Escape"; fixedData = "{Escape}"; }
                            else if (key == "tab") { key = "Tab"; fixedData = "{Tab}"; }

                            //Fixes issue in which hotkeys don't fire through Sendkeys
                            if (Program.ProgramHotkeys.ContainsValue(key))
                            { onKeyAction(null, 0, fixedData); fixedData = ""; continue; }
                        }

                        if (useSendMessage)
                        {
                            //Fixes issue with Remote Desktop Connections not receiving Sendkeys
                            VirtualKeyCode vcd = VirtualKeyCode.CANCEL;
                            try { vcd = StringToVKC(fixedData); } catch { }
                            if (vcd != VirtualKeyCode.CANCEL)
                            {
                                if (Char.IsUpper(fixedData.ToCharArray()[0]))
                                {
                                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
                                    inputSimulator.Keyboard.KeyPress(vcd);
                                    inputSimulator.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
                                }
                                else
                                {
                                    inputSimulator.Keyboard.KeyPress(vcd);
                                }
                            }
                        }
                        else
                        {
                            SendKeys.SendWait(fixedData);
                        }

                        if (Settings.UseSendKeysDelay)
                        {
                            if (i == 1) { Task.Delay(300).Wait(); }
                            else if (i == 2) { Task.Delay(200).Wait(); }
                            else if (i == 3) { Task.Delay(100).Wait(); }
                            else { Task.Delay(5).Wait(); }
                        }
                        else { Task.Delay(1).Wait(); }

                        fixedData = "";
                        i++;
                    }
                }
            }
            catch
            { }
        }
        private static VirtualKeyCode StringToVKC(String s)
        {
            try
            {
                return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), "VK_" + s.ToUpper(), false);
            }
            catch
            {
                try
                {
                    if (s == " ") { return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), "SPACE", false); }
                    else if (s == ".") { return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), "DECIMAL", false); }
                    else if (s == "{Enter}") { return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), "RETURN", false); }
                    else { return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), s.Replace("{", "").Replace("}", "").ToUpper(), false); }
                }
                catch
                {
                    throw new InvalidCastException("Unable to set VirtualKeyCode from String");
                }
            }
        }

        private static string FixString(string s)
        {
            if (s == "+" || s == "^" || s == "%") { s = "{" + s + "}"; }
            return s;
        }
        public static void RunProcess(string s, string[] a = null)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            //start.UseShellExecute = false;
            start.FileName = s;
            try { start.Arguments = $"\"{string.Join("\" \"", a)}\""; } catch { }
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
            myList = Program.MyList;
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
                Program.MyList = myList;
                Clipboard.SetText(temp);
                Program.MyIndex = 0;
            }
            catch
            { }
            newDataCount = newDataCount == 0 ? myList.Count : newDataCount - myList.Count;
            ActionComplete?.Invoke(myActions.Copy, newDataCount);
        }
        private static void PastePressed()
        {
            if (Program.MyIndex == Program.MyList.Count - 1 && Program.EndOfListPasted == true)
            { }
            else
            {
                if (Program.MyIndex == Program.MyList.Count - 1) { Program.EndOfListPasted = true; }
                else { Program.EndOfListPasted = false; }
                List<string> myList = Program.MyList;
                string selectedText = "";
                try
                {
                    PasteString(myList[Program.MyIndex]);
                    Program.MyIndex++; if (Program.MyIndex > myList.Count) { Program.MyIndex = myList.Count; }
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
        private static void HandleHotkeyShiftF12()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "{Shift}F12"); }
        }
        private static void HandleHotkeyCTRLF12()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "{CTRL}F12"); }
        }
        private static void HandleHotkeyALTF12()
        {
            if (Settings.Mode == 4)
            { ActionComplete?.Invoke(myActions.Paste2, "{ALT}F12"); }
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
