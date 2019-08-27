using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public static class Actions
    {
        public static void SetForm(short m)
        {
            Settings.Mode = m;
            Settings.Save();
            Application.Restart();
        }
    }
}
