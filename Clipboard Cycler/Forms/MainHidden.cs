using System.Windows.Forms;

namespace Clipboard_Cycler
{
    public partial class MainHidden : Form
    {
        private bool allowshowdisplay = false;

        public MainHidden()
        {
            InitializeComponent();

            Program.RunNewForm();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }
    }
}