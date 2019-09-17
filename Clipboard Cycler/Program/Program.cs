﻿using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    static class Program
    {
        public static string MyTitle { get; } = "Clipboard Cycler";
        public static FileInfo MySaveFile { get; set; } = null;
        public static List<string> MyList { get; set; } = new List<string>();
        public static int MyIndex { get; set; } = 0;
        public static bool EndOfListPasted { get; set; } = false;
        public static bool Failed { get; set; } = false;
        public static Dictionary<short, string> ProgramHotkeys { get; set; } = new Dictionary<short, string>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (DpiAwareness.EnterDpiScope(DpiAwarenessContext.SystemAware))
            { Application.Run(new MainHidden()); }
        }

        public static void RunNewForm()
        {
            using (DpiAwareness.EnterDpiScope(DpiAwarenessContext.SystemAware))
            { Type.GetType("Clipboard_Cycler.Program").GetMethod($"RunForm{Settings.Mode}").Invoke(null, null); }
        }

        //Practice and Proof of Concept using reflections instead of if statements.
        public static void RunForm1()
        { new Thread(() => Application.Run(new Form1())).Start(); }
        public static void RunForm2()
        { new Thread(() => Application.Run(new Form2())).Start(); }
        public static void RunForm3()
        { new Thread(() => Application.Run(new Form3())).Start(); }
        public static void RunForm4()
        { new Thread(() => Application.Run(new Form4())).Start(); }
    }
}
