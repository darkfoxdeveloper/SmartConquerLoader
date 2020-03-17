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
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
