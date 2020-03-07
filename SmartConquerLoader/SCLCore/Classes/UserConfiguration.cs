namespace SCLCore
{
    public class UserConfiguration
    {
        public string ServerName { get; set; }
        public string Host { get; set; }
        public uint EnableHostName { get; set; }
        public string HostName { get; set; }
        public uint GamePort { get; set; }
        public uint LoginPort { get; set; }
        public string NameConquerExecutable { get; set; }
        public string ExecuteInSubFolder { get; set; }
        public string Image { get; set; }
        public uint Version { get; set; }
        public string GameCryptographyKey { get; set; }
    }
}
