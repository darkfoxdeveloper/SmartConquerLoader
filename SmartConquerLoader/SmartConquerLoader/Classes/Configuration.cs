using Newtonsoft.Json;
using SCLCore;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SmartConquerLoader
{
    public static class Configuration
    {
        private const string ConfigPath = "config.json";
        public static List<UserConfiguration> Configs;
        public static int CurrentConquerPId { get; set; }
        public static UserConfiguration SelectedUserConfiguration { get; set; }
        public static void Load()
        {
            if (File.Exists(ConfigPath))
            {
                List<UserConfiguration> uc = JsonConvert.DeserializeObject<List<UserConfiguration>>(File.ReadAllText(ConfigPath));
                Configs = uc;
            } else
            {
                MessageBox.Show("No configuration detected", "SmartConquerLoader", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
