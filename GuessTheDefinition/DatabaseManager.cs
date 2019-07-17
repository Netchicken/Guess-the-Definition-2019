using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Util;
using Android.Widget;
using SQLite;
using Environment = Android.OS.Environment;
using Xamarin.Essentials;

namespace GuessTheDefinition
{
    public class DatabaseManager
    {

        //https://components.xamarin.com/gettingstarted/sqlite-net 
        //https://github.com/praeclarum/sqlite-net
        //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/

        //https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs


        //YOUR CLASS NAME MUST BE YOUR TABLE NAME
        private string tag = "aaaaa";
        SQLiteConnection conn;
        public static string databasePath;
        public static string databaseName;


        public DatabaseManager()
        {
            DBConnect();
        }

        public List<scoring> ViewAll()
        {
            try
            {
                //SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scoring.sqlite"));

                return conn.Query<scoring>("SELECT * FROM SelectDescScores");
            }
            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
            }
        }

        private void DBConnect()
        {

            databaseName = "Scoring.sqlite";
            databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, databaseName); // Assets folder
            
          
            if (databasePath != null)
            {
                conn = new SQLiteConnection(databasePath);
            }
            else
            {
                // Initializes a new instance of the Database.
                // if the database doesn't exist, it will create the database and all the tables.
                // Add more tables to CreateTable when needed
                //  conn.CreateTable<tblToDo>();
            }
        }

        public void AddItem()
        {

            //http://javatechig.com/xamarin/using-sqlite-net-orm-in-xamarin-application 
            Log.Info(tag, "AddItem Word = " + Words.Name + " AddItem Score = " + Words.Score + " AddItem Word = " + Words.Word);

            try
            {
                var AddThis = new scoring
                {
                    name = Words.Name,
                    score = Words.Score,
                    word = Words.Word
                };

                conn.Insert(AddThis);

                //   db.Execute("INSERT INTO scoring(name, score, word) VALUES(?1,? 2,? 3))
                Log.Info(tag, "Data Added " + AddThis);

            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }

        public void EditItem(string name, int score, string word, int id)
        {
            try
            {
                //http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated


                var EditThis = new scoring
                {
                    id = id,
                    name = name,
                    score = score,
                    word = word
                };

                conn.Update(EditThis);

                //or this
                //  db.Execute("UPDATE scoring Set name = ?, score =, WHERE ID = ?", name, score, word, id);

            }
            catch (Exception e)
            {

                Log.Info(tag, "Update Error:" + e.Message.ToString());

            }
        }

        public void DeleteItem(int listid)
        {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            try
            {
                conn.Delete<scoring>(listid);

            }
            catch (Exception ex)
            {
                Log.Info(tag, "Delete Error:" + ex.Message);
            }
        }

    }
}

