using Microsoft.VisualStudio.Utilities;
using System;
using System.IO;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    static class Program
    {
        public static Settings allSettings;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            allSettings = new Settings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (DpiAwareness.EnterDpiScope(DpiAwarenessContext.SystemAware))
            { Type.GetType("Clipboard_Cycler.Forms").GetMethod($"RunForm{allSettings.Mode}").Invoke(null, null); }
        }
    }

    public class Actions
    {
        public static void SetForm(short m)
        {
            Program.allSettings.Mode = m;
            Application.Restart();
        }
    }
    public class Forms
    {
        public static void RunForm1()
        { Application.Run(new Form1()); }
        public static void RunForm2()
        { Application.Run(new Form2()); }
        public static void RunForm3()
        { Application.Run(new Form3()); }
        public static void RunForm4()
        { Application.Run(new Form4()); }
    } //Practice and Proof of Concept to not use if statments for Forms.

    public class Settings
    {
        private IniFile ini;
        private bool useClipboard = false;
        private static string savedList = "";
        private static short mode = 1;

        public Settings()
        {
            ini = new IniFile(Path.GetTempPath() + "\\ClipboardCycler.ini");
        }

        public bool UseClipboard
        {
            get
            {
                useClipboard = false;
                bool.TryParse(ini.Read("UseClipboard"), out useClipboard);
                return useClipboard;
            }
            set
            {
                useClipboard = value;
                ini.Write("UseClipboard", useClipboard.ToString());
            }
        }

        public string SavedList
        {
            get
            {
                savedList = ini.Read("SavedList");
                return savedList;
            }
            set
            {
                savedList = value;
                ini.Write("SavedList", savedList);
            }
        }

        public short Mode
        {
            get
            {
                mode = 1;
                short.TryParse(ini.Read("Mode"), out mode);
                return mode;
            }
            set
            {
                mode = value;
                ini.Write("Mode", mode.ToString());
            }
        }
    }
}
