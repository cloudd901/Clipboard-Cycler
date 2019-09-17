using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
