﻿using Reloaded.Injector;
using SCLCore;
using SCLSync;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SmartConquerLoader
{
    public partial class Main : Form
    {
        SCLClient client = null;
        public string CurrentDirectory = "";
        public Main()
        {
            InitializeComponent();
            this.Icon = new Icon(@"Assets\co.ico");
            CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
            Database db = new Database();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Configuration.SelectedUserConfiguration != null)
            {
                if (File.Exists(Configuration.SelectedUserConfiguration.NameConquerExecutable))
                {
                    // Detect correct path for SCLHook
                    string PathSCLHook = "";
                    if (Configuration.SelectedUserConfiguration.ExecuteInSubFolder != "" && Directory.Exists(Configuration.SelectedUserConfiguration.ExecuteInSubFolder))
                    {
                        PathSCLHook = CurrentDirectory + @"\" + Configuration.SelectedUserConfiguration.ExecuteInSubFolder + @"\" + "SCLHook.dll";
                    } else
                    {
                        PathSCLHook = CurrentDirectory + @"\SCLHook.dll";
                    }

                    // Create first the config used by DLL
                    File.WriteAllText(PathSCLHook.Replace(".dll", ".ini"), "[SCLHook]"
                        + Environment.NewLine + "HOST=" + Configuration.SelectedUserConfiguration.Host
                        + Environment.NewLine + "GAMEHOST=" + Configuration.SelectedUserConfiguration.Host
                        + Environment.NewLine + "PORT=" + Configuration.SelectedUserConfiguration.LoginPort
                        + Environment.NewLine + "GAMEPORT=" + Configuration.SelectedUserConfiguration.GamePort
                        + Environment.NewLine + "SERVERNAME=" + Configuration.SelectedUserConfiguration.ServerName
                        + Environment.NewLine + "ENABLE_HOSTNAME=" + Configuration.SelectedUserConfiguration.EnableHostName
                        + Environment.NewLine + "HOSTNAME=" + Configuration.SelectedUserConfiguration.HostName
                        + Environment.NewLine + "SERVER_VERSION=" + Configuration.SelectedUserConfiguration.Version
                        );

                    // Do injection
                    Process pConquer = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = CurrentDirectory + @"\" + Configuration.SelectedUserConfiguration.NameConquerExecutable,
                            Arguments = "blacknull"
                        }
                    };
                    if (Configuration.SelectedUserConfiguration.ExecuteInSubFolder != "" && Directory.Exists(Configuration.SelectedUserConfiguration.ExecuteInSubFolder))
                    {
                        pConquer.StartInfo.FileName = CurrentDirectory + @"\" + Configuration.SelectedUserConfiguration.ExecuteInSubFolder + @"\" + Configuration.SelectedUserConfiguration.NameConquerExecutable;
                        pConquer.StartInfo.WorkingDirectory = CurrentDirectory + @"\" + Configuration.SelectedUserConfiguration.ExecuteInSubFolder + @"\";
                    }

                    if (File.Exists(pConquer.StartInfo.FileName) && File.Exists(PathSCLHook))
                    {
                        // Need check cryptkey
                        bool checkCryptKey = Configuration.SelectedUserConfiguration.GameCryptographyKey != "";
                        if (checkCryptKey)
                        {
                            // Check if have the correct conquercryptkey
                            string cConquerCryptKey = GameCryptography.GetCurrentConquerCryptographyKey(SCLCore.Utils.GetCurrentConquerPath(Configuration.SelectedUserConfiguration));
                            if (Configuration.SelectedUserConfiguration.GameCryptographyKey == cConquerCryptKey)
                            {
                                pConquer.Start();
                                pConquer.EnableRaisingEvents = true;
                                pConquer.Exited += PConquer_Exited;
                                Configuration.CurrentConquerPId = pConquer.Id;
                                Injector injector = new Injector(pConquer);
                                injector.Inject("SCLHook.dll");
                                injector.Dispose();
                                btnStart.Text = "Loading...";
                                LaunchServerSideProtection();
                                SystemTray();
                            }
                            else
                            {
                                MessageBox.Show("Error invalid ConquerCryptographyKey in Conquer.exe found!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else
                        {
                            pConquer.Start();
                            pConquer.EnableRaisingEvents = true;
                            pConquer.Exited += PConquer_Exited;
                            Configuration.CurrentConquerPId = pConquer.Id;
                            Injector injector = new Injector(pConquer);
                            injector.Inject("SCLHook.dll");
                            injector.Dispose();
                            btnStart.Text = "Loading...";
                            LaunchServerSideProtection();
                            SystemTray();
                        }
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

        private void LaunchServerSideProtection()
        {
            if (Configuration.SelectedUserConfiguration.ServerSideProtection && Process.GetProcessesByName("SmartConquerLoader").Count() <= 0)
            {
                client = new SCLClient(IPAddress.Parse(Configuration.SelectedUserConfiguration.Host), 8000);
                client.StartSCLClient();
            }
        }

        private void PConquer_Exited(object sender, EventArgs e)
        {
            if (Configuration.SelectedUserConfiguration.ServerSideProtection)
            {
                if (client != null)
                {
                    client.SafeDisconnect();
                }
            }
            ClearAndExit();
        }

        private void ClearAndExit(bool AlreadyKillConquer = false)
        {
            // Clear config file used by DLL
            if (File.Exists("SCLHook.ini"))
            {
                File.Delete("SCLHook.ini");
            }
            // Kill conquer if needed
            if (AlreadyKillConquer)
            {
                if (Configuration.CurrentConquerPId > 0)
                {
                    Process p = Process.GetProcessById(Configuration.CurrentConquerPId);
                    if (p != null)
                    {
                        p.Kill();
                        Configuration.CurrentConquerPId = 0;
                    }
                }
            }
            // Exit
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
            this.Height += 15;
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
            ClearAndExit(true);
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
