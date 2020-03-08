using Newtonsoft.Json;
using SCLCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SCLManager
{
    public partial class Main : Form
    {
        List<UserConfiguration> UserConfigurations;
        ChangeConfiguration cc;
        private readonly string ConfigPathFile = "config.json";
        public Main()
        {
            InitializeComponent();
            if (File.Exists(@"Assets\co.ico"))
            {
                this.Icon = new Icon(@"Assets\co.ico");
            }
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            this.LoadConfigFile(true);
            csvManager.SelectedIndexChanged += CsvManager_SelectedIndexChanged;
        }

        private void SaveConfigFile()
        {
            File.WriteAllText(ConfigPathFile, JsonConvert.SerializeObject(UserConfigurations));
        }

        private void LoadConfigFile(bool firstLoad = false)
        {
            string jsonData = "";
            if (File.Exists(ConfigPathFile))
            {
                jsonData = File.ReadAllText(ConfigPathFile);
            }
            else if(firstLoad)
            {
                File.WriteAllText(ConfigPathFile, "");
            }
            UserConfigurations = JsonConvert.DeserializeObject<List<UserConfiguration>>(jsonData);
            csvManager.Items.Clear();
            if (UserConfigurations != null)
            {
                foreach (UserConfiguration uc in UserConfigurations)
                {
                    ListViewItem lvi = new ListViewItem
                    {
                        Text = uc.ServerName,
                        Tag = uc
                    };
                    lvi.SubItems.Add(uc.Host);
                    lvi.SubItems.Add(uc.EnableHostName.ToString());
                    lvi.SubItems.Add(uc.HostName);
                    lvi.SubItems.Add(uc.GamePort.ToString());
                    lvi.SubItems.Add(uc.LoginPort.ToString());
                    lvi.SubItems.Add(uc.NameConquerExecutable);
                    lvi.SubItems.Add(uc.ExecuteInSubFolder);
                    lvi.SubItems.Add(uc.Image);
                    lvi.SubItems.Add(uc.Version.ToString());
                    csvManager.Items.Add(lvi);
                }
            }
        }

        private void CsvManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvi = (ListView)sender;
            if (lvi.SelectedItems.Count > 0)
            {
                UserConfiguration ucSelected = (UserConfiguration)lvi.SelectedItems[0].Tag;
                if (cc == null)
                {
                    cc = new ChangeConfiguration(ucSelected);
                    cc.ShowDialog();
                }
                else
                {
                    cc.uc = ucSelected;
                    cc.ShowDialog();
                }

                if (cc.DialogResult == DialogResult.OK)
                {
                    this.SaveConfigFile();
                    this.LoadConfigFile();
                } else if (cc.DialogResult == DialogResult.Abort)
                {
                    UserConfigurations.Remove(cc.uc);
                    this.SaveConfigFile();
                    this.LoadConfigFile();
                }
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (UserConfigurations == null)
            {
                UserConfigurations = new List<UserConfiguration>
                {
                    new UserConfiguration() { ServerName = "NewServer0" }
                };
            } else
            {
                UserConfigurations.Add(new UserConfiguration() { ServerName = "NewServer" + UserConfigurations.Count });
            }
            this.SaveConfigFile();
            this.LoadConfigFile();
        }
    }
}
