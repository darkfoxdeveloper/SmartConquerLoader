using Reloaded.Injector;
using SmartConquerLoader.Classes;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            Configuration.Load();
            UserConfiguration uc = Configuration.Configs.Where(x => x.ServerName == "OpenConquer").FirstOrDefault();
            if (uc != null)
            {
                if (File.Exists(uc.NameConquerExecutable))
                {
                    Process pConquer = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = Directory.GetCurrentDirectory() + @"\" + uc.NameConquerExecutable,
                            Arguments = "blacknull"
                        }
                    };
                    if (File.Exists(pConquer.StartInfo.FileName) && File.Exists("SCLHook.dll"))
                    {
                        pConquer.Start();
                        Injector injector = new Injector(pConquer);
                        injector.Inject("SCLHook.dll");
                        injector.Dispose();
                    }
                    else
                    {
                        DialogResult dRes = MessageBox.Show("Error cannot load the SCLHook.dll for inject in Conquer.exe", this.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (dRes == DialogResult.Retry)
                        {
                            this.BtnStart_Click(sender, e);
                        }
                    }
                } else
                {
                    MessageBox.Show("Sorry, the conquer executable '" + uc.NameConquerExecutable + "' has not been found", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
