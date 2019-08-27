using Microsoft.VisualStudio.Utilities;
using System;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    static class Program
    {
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
            { Type.GetType("Clipboard_Cycler.Program").GetMethod($"RunForm{Settings.Mode}").Invoke(null, null); }
        }

        //Practice and Proof of Concept using reflections instead of if statements.
        public static void RunForm1()
        { Application.Run(new Form1()); }
        public static void RunForm2()
        { Application.Run(new Form2()); }
        public static void RunForm3()
        { Application.Run(new Form3()); }
        public static void RunForm4()
        { Application.Run(new Form4()); }
    }
}
