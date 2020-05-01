using SQLite;
using System;
using System.IO;

namespace SCLSync
{
    public class Database
    {
        private SQLiteConnection dbConnection = null;
        public Database()
        {
            // Get an absolute path to the database file
            string folderDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartConquerLoader");
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartConquerLoader", "Data.db");

            dbConnection = new SQLiteConnection(databasePath);

            if (!Directory.Exists(folderDbPath))
            {
                Directory.CreateDirectory(folderDbPath);
                dbConnection = new SQLiteConnection(databasePath, SQLiteOpenFlags.Create);
                dbConnection.CreateTable<SCLCore.Models.Authentification>();
            }
            else
            {
                dbConnection = new SQLiteConnection(databasePath);
            }
            dbConnection.Close();
        }

        public void Save(object obj)
        {
            dbConnection.Update(obj);
        }
    }
}
