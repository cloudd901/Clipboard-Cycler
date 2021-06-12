using System;
using System.Drawing;
using System.IO;

namespace Clipboard_Cycler
{
    public static class Settings
    {
        private static bool hideHotkeyErrors = false;
        private static IniFile ini;
        private static short mode = 1;
        private static bool sortList = false;
        private static bool trimWS = true;
        private static bool uniqueList = false;
        private static bool useEscape = true;
        private static bool useSendCTRLV = false;
        private static bool useSendKeys = true;
        private static bool useSendKeysDelay = false;
        private static Point winPos = new Point(0, 0);
        private static Size winSize = new Size(265, 167);

        public static string[] Form2Fields { get; } = new string[5] { "", "", "", "", "" };
        public static string[] Form3Fields { get; } = new string[5] { "", "", "", "", "" };
        public static string[] Form4Fields { get; } = new string[8] { "", "", "", "", "", "", "", "" };
        public static string[] Form5Fields { get; } = new string[12] { "", "", "", "", "", "", "", "", "", "", "", "" };
        public static bool HideHotkeyErrors { get => hideHotkeyErrors; set => hideHotkeyErrors = value; }
        public static short Mode { get => mode; set => mode = value; }
        public static string SavedList { get; set; } = "";
        public static bool SortList { get => sortList; set => sortList = value; }
        public static bool TrimWS { get => trimWS; set => trimWS = value; }
        public static bool UniqueList { get => uniqueList; set => uniqueList = value; }
        public static bool UseEscape { get => useEscape; set => useEscape = value; }
        public static bool UseSendCTRLV { get => useSendCTRLV; set => useSendCTRLV = value; }
        public static bool UseSendKeys { get => useSendKeys; set => useSendKeys = value; }
        public static bool UseSendKeysDelay { get => useSendKeysDelay; set => useSendKeysDelay = value; }

        public static Point WinLoc
        {
            get
            {
                try
                {
                    string[] temp = ini.Read("WinLoc").Replace("{X=", "").Replace("Y=", "").Replace("}", "").Split(',');
                    winPos = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
                }
                catch
                {
                    winPos = new Point(0, 0);
                }
                return winPos;
            }
            set
            {
                winPos = value;
            }
        }

        public static Size WinSize
        {
            get
            {
                try
                {
                    string[] temp = ini.Read("WinSize").Replace("{Width=", "").Replace("Height=", "").Replace("}", "").Replace(" ", "").Split(',');
                    winSize = new Size(int.Parse(temp[0]), int.Parse(temp[1]));
                }
                catch
                {
                    winSize = new Size(0, 0);
                }
                return winSize;
            }
            set
            {
                winSize = value;
            }
        }

        public static void Initialize()
        {
            string iniLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Program.MyTitle;
            if (!Directory.Exists(iniLocation)) { Directory.CreateDirectory(iniLocation); }
            ini = new IniFile($"{iniLocation}\\{Program.MyTitle}.ini");

            bool.TryParse(ini.Read("UseEscape"), out useEscape);
            bool.TryParse(ini.Read("UseSendCTRLV"), out useSendCTRLV);
            bool.TryParse(ini.Read("UseSendKeysDelay"), out useSendKeysDelay);
            if (!bool.TryParse(ini.Read("UseSendKeys"), out useSendKeys)) { if (!useSendCTRLV && !useSendKeysDelay) { useSendKeys = true; } }
            bool.TryParse(ini.Read("HideHotkeyErrors"), out hideHotkeyErrors);
            bool.TryParse(ini.Read("UniqueList"), out uniqueList);
            bool.TryParse(ini.Read("SortList"), out sortList);
            bool.TryParse(ini.Read("TrimWS"), out trimWS);
            string SavedString = ini.Read("SavedList");
            SavedList = SavedString.Replace("~`", Environment.NewLine);

            string[] f2temp = ini.Read("Form2Fields").Split('`');
            if (f2temp.Length == 5) { for (int i = 0; i < 5; i++) { Form2Fields[i] = f2temp[i]; } }
            string[] f3temp = ini.Read("Form3Fields").Split('`');
            if (f3temp.Length == 5) { for (int i = 0; i < 5; i++) { Form3Fields[i] = f3temp[i]; } }
            string[] f4temp = ini.Read("Form4Fields").Split('`');
            if (f4temp.Length == 8) { for (int i = 0; i < 8; i++) { Form4Fields[i] = f4temp[i]; } }
            string[] f5temp = ini.Read("Form5Fields").Split('`');
            if (f5temp.Length == 12) { for (int i = 0; i < 12; i++) { Form5Fields[i] = f5temp[i]; } }

            short.TryParse(ini.Read("Mode"), out mode);
            if (mode < 1 || mode > 5)
            {
                mode = 1;
            }

            try
            {
                string[] temp = ini.Read("WinLoc")
                    .Replace("{Width=", "")
                    .Replace("Height=", "")
                    .Replace("}", "")
                    .Replace(" ", "")
                    .Split(',');
                winSize = new Size(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            catch
            {
                winSize = new Size(265, 167);
            }

            try
            {
                string[] temp = ini.Read("WinLoc")
                    .Replace("{X=", "")
                    .Replace("Y=", "")
                    .Replace("}", "")
                    .Split(',');
                winPos = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            catch
            {
                winPos = new Point(0, 0);
            }
        }

        public static void Save()
        {
            ini.Write("UseEscape", UseEscape.ToString());
            ini.Write("UseSendCTRLV", UseSendCTRLV.ToString());
            ini.Write("UseSendKeys", UseSendKeys.ToString());
            ini.Write("UseSendKeysDelay", UseSendKeysDelay.ToString());
            ini.Write("UniqueList", UniqueList.ToString());
            ini.Write("HideHotkeyErrors", HideHotkeyErrors.ToString());
            ini.Write("SortList", SortList.ToString());
            ini.Write("TrimWS", TrimWS.ToString());
            ini.Write("SavedList", SavedList.Replace(Environment.NewLine, "~`"));
            ini.Write("Mode", Mode.ToString());
            ini.Write("WinLoc", winPos.ToString());
            ini.Write("WinSize", winSize.ToString());
            ini.Write("Form2Fields", string.Join("`", Form2Fields));
            ini.Write("Form3Fields", string.Join("`", Form3Fields));
            ini.Write("Form4Fields", string.Join("`", Form4Fields));
            ini.Write("Form5Fields", string.Join("`", Form5Fields));
        }
    }
}