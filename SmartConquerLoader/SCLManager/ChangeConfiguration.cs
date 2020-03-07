using SmartConquerLoader.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SCLManager
{
    public partial class ChangeConfiguration : Form
    {
        public UserConfiguration uc { get; set; }
        public ChangeConfiguration(UserConfiguration uc)
        {
            InitializeComponent();
            if (File.Exists(@"Assets\co.ico"))
            {
                this.Icon = new Icon(@"Assets\co.ico");
            }
            this.uc = uc;
        }

        private void ChangeUserConfiguration_Load(object sender, EventArgs e)
        {
            tbServerName.Text = uc.ServerName;
            tbHost.Text = uc.Host;
            cbUseHostName.Checked = uc.EnableHostName == 1 ? true : false;
            tbHostName.Enabled = cbUseHostName.Checked;
            tbHostName.Text = uc.HostName;
            tbGamePort.Text = uc.GamePort.ToString();
            tbLoginPort.Text = uc.LoginPort.ToString();
            tbNameConquerExecutable.Text = uc.NameConquerExecutable;
            tbExecuteInSubFolder.Text = uc.ExecuteInSubFolder;
            tbImage.Text = uc.Image;
            tbVersion.Text = uc.Version.ToString();
        }

        private void CbUseHostName_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = ((CheckBox)sender);
            tbHostName.Enabled = c.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            uc.ServerName = tbServerName.Text;
            uc.HostName = tbHostName.Text;
            uc.Host = tbHost.Text;
            uc.EnableHostName = (uint)(cbUseHostName.Checked ? 1 : 0);
            uc.GamePort = uint.Parse(tbGamePort.Text);
            uc.LoginPort = uint.Parse(tbLoginPort.Text);
            uc.NameConquerExecutable = tbNameConquerExecutable.Text;
            uc.ExecuteInSubFolder = tbExecuteInSubFolder.Text;
            uc.Image = tbImage.Text;
            uc.Version = uint.Parse(tbVersion.Text);
        }
    }
}
