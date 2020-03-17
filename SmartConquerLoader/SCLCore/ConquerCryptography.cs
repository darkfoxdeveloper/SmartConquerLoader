using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SCLCore
{
    public class ConquerCryptography
    {
        private readonly byte[] clientBuffer;
        private uint clientOffset;

        public ConquerCryptography(string FileName)
        {
            clientBuffer = File.ReadAllBytes(FileName ?? "");
        }

        public string Get()
        {
            for (uint i = 0; (ulong)i < (ulong)clientBuffer.Length; i++)
            {
                if ((ulong)(i + 8) <= (ulong)clientBuffer.Length && clientBuffer[i] == 84 && Encoding.UTF8.GetString(clientBuffer, (int)i, 8) == "TQServer")
                {
                    this.clientOffset = i + 8 + 4;
                }
            }
            return Encoding.UTF8.GetString(clientBuffer, (int)clientOffset, 16);
        }

        public bool Set(string NewCryptKey, string DestinationFile)
        {
            bool success = false;
            Get();
            string Msg = "";
            if (NewCryptKey.Length != 16)
            {
                Msg = "ERROR: INVALID CRYPTKEY LENGTH";
            }
            for (int i = 0; i < 16; i++)
            {
                byte text = (byte)NewCryptKey[i];
                if (text > 255 || text < 1 || text == 32)
                {
                    Msg = "ERROR: INVALID LENGTH CARACTERS IN CRYPTKEY";
                }
            }
            for (int j = 0; j < 16; j++)
            {
                clientBuffer[(int)((IntPtr)((ulong)clientOffset + (ulong)j))] = (byte)NewCryptKey[j];
            }
            FileStream fs = File.Create(DestinationFile, clientBuffer.Length);
            fs.Write(clientBuffer, 0, clientBuffer.Length);
            fs.Close();
            if (File.Exists(DestinationFile))
            {
                success = true;
            } else
            {
                Msg = "UNKNOWN ERROR. CRYPTKEY PROCESS FAILED";
            }
            if (Msg != "")
            {
                throw new Exception(Msg);
            }
            return success;
        }

        public string GenerateValidCryptKey()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string key = new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
            return key;
        }

        public bool GenerateAndApplyCryptKey(string fileNameExe)
        {
            string randomCryptKey = this.GenerateValidCryptKey();
            return Set(randomCryptKey, @"" + fileNameExe);
        }
    }
}
