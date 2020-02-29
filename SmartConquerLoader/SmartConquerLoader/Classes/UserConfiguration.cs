using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartConquerLoader.Classes
{
    public class UserConfiguration
    {
        public string ServerName { get; set; }
        public string Host { get; set; }
        public uint GamePort { get; set; }
        public uint LoginPort { get; set; }
        public string NameConquerExecutable { get; set; }
        public string ExecuteInSubFolder { get; set; }
    }
}
