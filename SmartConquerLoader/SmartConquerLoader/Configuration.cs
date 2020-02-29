using Newtonsoft.Json;
using SmartConquerLoader.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace SmartConquerLoader
{
    public static class Configuration
    {
        private const string ConfigPath = "config.json";
        public static List<UserConfiguration> Configs;
        public static void Load()
        {
            if (File.Exists(ConfigPath))
            {
                List<UserConfiguration> uc = JsonConvert.DeserializeObject<List<UserConfiguration>>(File.ReadAllText(ConfigPath));
                Configs = uc;
            }
        }
    }
}
