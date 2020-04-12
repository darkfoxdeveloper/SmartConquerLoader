using System;
using System.IO;

namespace SCLCore
{
    public static class GameCryptography
    {
        // With help of ConquerCryptKey created by DaRkFox read the current cryptkey of conquer.exe
        public static string GetCurrentConquerCryptographyKey(string ConquerExecutablePath)
        {
            ConquerCryptography cryptFile = new ConquerCryptography(ConquerExecutablePath);
            string cryptkey = cryptFile.Get();// Read & Access to current cryptkey
            return cryptkey;
        }

        // With help of ConquerCryptKey created by DaRkFox write any custom cryptkey in conquer.exe
        public static bool SetConquerCryptographyKey(string ConquerExecutablePath, string GameCryptKey)
        {
            bool success = true;
            try
            {
                ConquerCryptography cryptFile = new ConquerCryptography(ConquerExecutablePath);
                cryptFile.Set(GameCryptKey, ConquerExecutablePath);
            } catch(Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
