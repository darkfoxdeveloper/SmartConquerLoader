using Reloaded.Injector;
using SmartConquerLoader.Classes;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (Configuration.SelectedUserConfiguration != null)
            {
                if (File.Exists(Configuration.SelectedUserConfiguration.NameConquerExecutable))
                {
                    Process pConquer = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = Directory.GetCurrentDirectory() + @"\" + Configuration.SelectedUserConfiguration.NameConquerExecutable,
                            Arguments = "blacknull"
                        }
                    };
                    if (File.Exists(pConquer.StartInfo.FileName) && File.Exists("SCLHook.dll"))
                    {
                        pConquer.Start();
                        pConquer.EnableRaisingEvents = true;
                        pConquer.Exited += PConquer_Exited;
                        Configuration.CurrentConquerPId = pConquer.Id;
                        Injector injector = new Injector(pConquer);
                        injector.Inject("SCLHook.dll");
                        injector.Dispose();
                        btnStart.Text = "Loading...";
                        SystemTray();
                    }
                    else
                    {
                        DialogResult dRes = MessageBox.Show("Error cannot load the SCLHook.dll for inject in Conquer.exe", this.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (dRes == DialogResult.Retry)
                        {
                            this.BtnStart_Click(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, the conquer executable '" + Configuration.SelectedUserConfiguration.NameConquerExecutable + "' has not been found", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PConquer_Exited(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Configuration.Load();
            foreach (UserConfiguration uc in Configuration.Configs.ToList())
            {
                PictureBox pb = Utils.Clone(pbServerImageBase);
                pb.Location = new Point(pb.Location.X + pb.Width, pb.Location.Y + pb.Height + 30);
                pb.Name = "ImageServer"+ uc.ServerName;
                pb.Tag = uc;
                pb.BackColor = Color.Transparent;
                pb.BackgroundImage = Image.FromFile(uc.Image);
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Visible = true;
                pb.Width = btnStart.Width;
                pb.Height = 200;
                pb.Click += Pb_Click;
                flowLayoutPanel1.Controls.Add(pb);
                flowLayoutPanel1.Controls.SetChildIndex(pb, 0);
                this.Height += pb.Height;
            }
            pbServerImageBase.Visible = false;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is PictureBox pbx)
                {
                    pbx.BackColor = Color.Transparent;
                }
            }
            PictureBox pb = ((PictureBox)sender);
            pb.BackColor = Color.DarkCyan;
            Configuration.SelectedUserConfiguration = (UserConfiguration)pb.Tag;
            btnStart.Text = "Start - " + Configuration.SelectedUserConfiguration.ServerName;
            btnStart.Enabled = true;
            // TODO generate file .ini used for dll and develop the dll for hook 'SCLHook.dll'
        }

        private void SystemTray()
        {
            NotifyIcon icon = new NotifyIcon
            {
                Icon = new Icon("Assets/co.ico"),
                Text = this.ProductName,
                Visible = true,
                BalloonTipText = this.ProductName + " is now active!",
                BalloonTipTitle = this.ProductName,
                BalloonTipIcon = ToolTipIcon.Info,
        };
            icon.ShowBalloonTip(1000);
            icon.MouseDoubleClick += Icon_MouseDoubleClick;
            this.Hide();
        }

        private void Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.GetProcessById(Configuration.CurrentConquerPId);
            Environment.Exit(0);
        }

        private void BtnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.White;
            btnStart.ForeColor = Color.DarkRed;
        }

        private void BtnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.DarkRed;
            btnStart.ForeColor = Color.White;
        }
    }
}
