using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clipboard_Cycler
{
    static class Program
    {
        private static Type myProgram = Type.GetType("Clipboard_Cycler.Program");

        public static List<string> myList = new List<string>();
        public static int myIndex = 0;

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
            { dynamic test = myProgram.GetMethod($"RunForm{Settings.Mode}").Invoke(null, null); }
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
