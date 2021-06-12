using Microsoft.VisualStudio.Utilities;
using MouseCommands;
using SendInputKeyCommands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    internal static class Program
    {
        internal static Thread FormThread;
        public static bool EndOfListPasted { get; set; }
        public static bool Failed { get; set; }
        public static MouseCommand Mouse { get; } = new MouseCommand();
        public static int MyIndex { get; set; }
        public static List<string> MyList { get; set; } = new List<string>();
        public static FileInfo MySaveFile { get; set; }
        public static string MyTitle { get; } = "Clipboard Cycler";
        public static Dictionary<short, string> ProgramHotkeys { get; set; } = new Dictionary<short, string>();
        public static SendInputKeyCommand SendKeyComm { get; } = new SendInputKeyCommand();

        //Practice and Proof of Concept using reflections instead of if statements.
        public static void RunForm1()
        {
            FormThread = new Thread(() => Application.Run(new Form1()));
        }

        public static void RunForm2()
        {
            FormThread = new Thread(() => Application.Run(new Form2()));
        }

        public static void RunForm3()
        {
            FormThread = new Thread(() => Application.Run(new Form3()));
        }

        public static void RunForm4()
        {
            FormThread = new Thread(() => Application.Run(new Form4()));
        }

        public static void RunForm5()
        {
            FormThread = new Thread(() => Application.Run(new Form5()));
        }

        public static void RunNewForm()
        {
            using (DpiAwareness.EnterDpiScope(DpiAwarenessContext.SystemAware))
            {
                Type.GetType("Clipboard_Cycler.Program").GetMethod($"RunForm{Settings.Mode}").Invoke(null, null);
            }

            if (FormThread != null)
            {
                FormThread.SetApartmentState(ApartmentState.STA);
                FormThread.Start();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Settings.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (DpiAwareness.EnterDpiScope(DpiAwarenessContext.SystemAware))
            {
                Application.Run(new MainHidden());
            }
        }
    }
}