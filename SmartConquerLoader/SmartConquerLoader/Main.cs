using Reloaded.Injector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartConquerLoader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Icon = new Icon(@"Assets\co.ico");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Process pConquer = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Directory.GetCurrentDirectory() + @"\Conquer.exe",
                    Arguments = "blacknull"
                }
            };
            if (File.Exists(pConquer.StartInfo.FileName) && File.Exists("Inject.dll"))
            {
                pConquer.Start();
                Injector injector = new Injector(pConquer);
                injector.Inject("Inject.dll");
                injector.Dispose();
            }
            else
            {
                DialogResult dRes = MessageBox.Show("Error cannot load the Inject.dll for inject in Conquer.exe", "Error DFConquerLoader", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dRes == DialogResult.Retry)
                {
                    this.BtnStart_Click(sender, e);
                }
            }
        }
    }
}
