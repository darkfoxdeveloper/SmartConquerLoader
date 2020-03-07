using System;
using System.IO;

namespace SCLCore
{
    public static class GameCryptography
    {
        // With help of ConquerCryptKey created by DaRkFox read the current cryptkey of conquer.exe
        public static string GetCurrentConquerCryptographyKey(string ConquerExecutablePath)
        {
            ConquerCryptKey.CryptFile cryptFile = new ConquerCryptKey.CryptFile(ConquerExecutablePath);
            cryptFile.ReadCryptKey();// Read the cryptkey
            string cryptkey = cryptFile.OldCryptKey;// Access to current cryptkey
            return cryptkey;
        }

        // With help of ConquerCryptKey created by DaRkFox write any custom cryptkey in conquer.exe
        public static bool SetConquerCryptographyKey(string ConquerExecutablePath, string GameCryptKey)
        {
            bool success = true;
            try
            {
                ConquerCryptKey.CryptFile cryptFile = new ConquerCryptKey.CryptFile(ConquerExecutablePath);
                cryptFile.ChangeCryptKey(GameCryptKey, @"NewConquer.exe");
                File.Copy(ConquerExecutablePath, ConquerExecutablePath + ".backup");
                File.Move(@"NewConquer.exe", ConquerExecutablePath);
            } catch(Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
