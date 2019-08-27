using System.Drawing;
using System.IO;

namespace Clipboard_Cycler
{
    public static class Settings
    {
        private static readonly IniFile ini = new IniFile(Path.GetTempPath() + "\\ClipboardCycler.ini");
        private static bool useClipboard = false;
        private static bool uniqueList = false;
        private static bool sortList = false;
        private static short mode = 1;
        private static Point winPos = new Point(0, 0);

        public static void Initialize()
        {
            bool.TryParse(ini.Read("UseClipboard"), out useClipboard);
            bool.TryParse(ini.Read("UniqueList"), out uniqueList);
            bool.TryParse(ini.Read("SortList"), out sortList);
            SavedList = ini.Read("SavedList");
            short.TryParse(ini.Read("Mode"), out mode);
            if (mode < 1 || mode > 4) { mode = 1; }
            try
            {
                string[] temp = ini.Read("WinLoc").Replace("{X=", "").Replace("Y=", "").Replace("}", "").Split(',');
                winPos = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            catch { winPos = new Point(0, 0); }
        }

        public static bool UseClipboard { get => useClipboard; set => useClipboard = value; }
        public static bool UniqueList { get => uniqueList; set => uniqueList = value; }
        public static bool SortList { get => sortList; set => sortList = value; }
        public static string SavedList { get; set; } = "";
        public static short Mode { get => mode; set => mode = value; }

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

        public static void Save()
        {
            ini.Write("UseClipboard", UseClipboard.ToString());
            ini.Write("UniqueList", UniqueList.ToString());
            ini.Write("SortList", SortList.ToString());
            ini.Write("SavedList", SavedList);
            ini.Write("Mode", Mode.ToString());
            ini.Write("WinLoc", winPos.ToString());
        }
    }
}
