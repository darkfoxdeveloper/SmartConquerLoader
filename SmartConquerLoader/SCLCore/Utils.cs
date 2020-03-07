using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SCLCore
{
    public static class Utils
    {
        public static string GetCurrentConquerPath(UserConfiguration uc)
        {
            string cpath = uc.NameConquerExecutable;
            if (uc.ExecuteInSubFolder != "")
            {
                if (Directory.Exists(uc.ExecuteInSubFolder)) // If are in root client folder
                {
                    cpath = Path.Combine(uc.ExecuteInSubFolder, uc.NameConquerExecutable);
                } else
                {
                    cpath = uc.NameConquerExecutable;
                }
            }
            return cpath;
        }
    }
}
