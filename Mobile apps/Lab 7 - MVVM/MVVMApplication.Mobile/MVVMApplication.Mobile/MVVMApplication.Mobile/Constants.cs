using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MVVMApplication.Mobile
{
    public class Constants
    {
        public const string DatabaseFileName = "People.db3";
        public const SQLite.SQLiteOpenFlags SQLiteOpenFlags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
