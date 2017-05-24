using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using KlasaMaturalna.SQLite.Droid.SQLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace KlasaMaturalna.SQLite.Droid.SQLite
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MySQLiteDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}