using SendInputKeyCommands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public static class Actions
    {
        private static Type myType = Type.GetType("Clipboard_Cycler.Actions");
        public static bool SwitchingForms { get; set; } = false;

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
                SwitchingForms = true;
                f.Close();
                try { f.Dispose(); } catch { }
                Program.RunNewForm();
            }
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
                    SendInputKeyCommand sendKeyComm = new SendInputKeyCommand();
                    sendKeyComm.SendKeyDown(SendInputKeyCommand.VirtualKeyCode.CONTROL);
                    sendKeyComm.SendKeyPress(SendInputKeyCommand.VirtualKeyCode.KEY_C);
                    sendKeyComm.SendKeyUp(SendInputKeyCommand.VirtualKeyCode.CONTROL);
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

        public static void PasteString(string s)
        {
            SendInputKeyCommand sendKeyComm = new SendInputKeyCommand();
            try
            {
                Clipboard.SetText(s);
                string keyDataString = "";
                if (Settings.UseSendCTRLV)
                {
                    sendKeyComm.SendKeyDown("CTRL");
                    sendKeyComm.SendKeyPress("v");
                    sendKeyComm.SendKeyUp("CTRL");
                    Task.Delay(100).Wait();
                }
                else
                {
                    
                    int i = 1;
                    char prev = ' ';
                    foreach (char c in s)
                    {
                        if (c == '{' && s.Contains("}")) { keyDataString += c; continue; }
                        else if (keyDataString != "") { keyDataString += c; if (c != '}') { continue; } }
                        else { keyDataString = c.ToString(); }

                        if (keyDataString.StartsWith("{"))
                        {
                            string key = keyDataString.Replace("{", "").Replace("}", "");
                            if (key == "esc" || key == "escape") { key = "Escape"; keyDataString = "{Escape}"; }
                            else if (key == "tab") { key = "Tab"; keyDataString = "{Tab}"; }

                            //Optional delay in text
                            try { Task.Delay((int)(decimal.Parse(key)*1000m)).Wait(); keyDataString = ""; i = 0; continue; } catch { }
                            
                            //Fixes issue in which hotkeys don't fire correctly through Sendkeys
                            if (Program.ProgramHotkeys.ContainsValue(key))
                            { onKeyAction(null, 0, keyDataString); keyDataString = ""; i = 0; continue; }
                        }

                        if (Settings.UseSendKeysDelay)
                        {
                            if (prev == ' ' && char.IsUpper(c)) { Task.Delay(600).Wait(); i = 0; }
                            else if (prev == c) { Task.Delay(50).Wait(); }
                            else if (i < 4) { Task.Delay((new Random().Next(50, 200))).Wait(); }
                            else if (i >= 4 && i < 9) { Task.Delay((new Random().Next(100, 300))).Wait(); }
                            else if (i >= 9) { Task.Delay((new Random().Next(10, 100))).Wait(); }
                            prev = c;
                            i++;
                        }
                        else { Task.Delay(5).Wait(); }

                        sendKeyComm.SendKeyPress(keyDataString);

                        keyDataString = "";
                       
                    }
                }
            }
            catch
            { }
        }

        public static void RunProcess(string s, string[] a = null)
        {
            ProcessStartInfo start = new ProcessStartInfo();
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
                SendInputKeyCommand sendKeyComm = new SendInputKeyCommand();
                sendKeyComm.SendKeyDown(SendInputKeyCommand.VirtualKeyCode.CONTROL);
                sendKeyComm.SendKeyPress(SendInputKeyCommand.VirtualKeyCode.KEY_C);
                sendKeyComm.SendKeyUp(SendInputKeyCommand.VirtualKeyCode.CONTROL);
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
                    selectedText = myList[Program.MyIndex];
                    PasteString(selectedText);
                    Program.MyIndex++; if (Program.MyIndex > myList.Count) { Program.MyIndex = myList.Count; }
                }
                catch
                { }
                ActionComplete?.Invoke(myActions.Paste, selectedText);
            }
        }
        private static void EnterPressed()
        {
            SendInputKeyCommand sendKeyComm = new SendInputKeyCommand();
            sendKeyComm.SendKeyPress(SendInputKeyCommand.VirtualKeyCode.RETURN);
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
