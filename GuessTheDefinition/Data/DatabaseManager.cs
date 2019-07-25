using System;
using System.Collections.Generic;
using System.IO;
using Android.Util;
using GuessTheDefinition.Models;
using SQLite;

namespace GuessTheDefinition.Data
{
    public class DatabaseManager
    {


        //YOUR CLASS NAME MUST BE YOUR TABLE NAME
        private string tag = "aaaaa";
        SQLiteConnection conn;
        public static string databasePath;
        public static string databaseName;


        public DatabaseManager()
        {
            DBConnect();
        }



        private void DBConnect()
        {
            databaseName = "Scoring.sqlite";
         //   databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),databaseName);
         
            databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, databaseName);


            //https://github.com/praeclarum/sqlite-net
            try
            {
                if (databasePath != null) //this is dumb, I can see there is a path just above this line
                {

                    conn = new SQLiteConnection(databasePath);
                    conn.CreateTable<tblscoring>();

                    if (TestConnection())
                    {
                        Log.Info(tag, "SUCCESS " + databasePath);  
                    }


                  
                   
                    return;
                }
                Log.Info(tag, "NO CONNECTION DB  " + databasePath);
            }

            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??: " + e.Message);
                // Initializes a new instance of the Database.
                // if the database doesn't exist, it will create the database and all the tables.
                // Add more tables to CreateTable when needed
                // conn.CreateTable<tblscoring>();
            }
        }


        public bool TestConnection()
        {
            try
            {
               conn.Query<tblscoring>("SELECT * FROM tblscoring");

                return true;
                // return conn.Table<tblscoring>().ToList();

            }
            catch (Exception e)
            {
                Log.Info(tag, "Test Connection Error: " + e.Message);
                return false;
            }
        }




        public List<tblscoring> ViewAll()
        {
            try
            {
                //  return conn.Query<tblscoring>("SELECT * FROM SelectDescScores");
                return conn.Query<tblscoring>("SELECT * FROM tblscoring");
                // return conn.Table<tblscoring>().ToList();

            }
            catch (Exception e)
            {
                Log.Info(tag, "ViewAll Error: " + e.Message);
                return null;
            }
        }
        public void AddItem()
        {

            //http://javatechig.com/xamarin/using-sqlite-net-orm-in-xamarin-application 
            Log.Info(tag, "AddItem Word = " + Words.Name + " AddItem Score = " + Words.Score + " AddItem Word = " + Words.Word);

            try
            {
                var AddThis = new tblscoring
                {
                    name = Words.Name,
                    score = Words.Score,
                    word = Words.Word
                };

                conn.Insert(AddThis);

                //   db.Execute("INSERT INTO tblscoring(name, score, word) VALUES(?1,? 2,? 3))
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


                var EditThis = new tblscoring
                {
                    id = id,
                    name = name,
                    score = score,
                    word = word
                };

                conn.Update(EditThis);

                //or this
                //  db.Execute("UPDATE tblscoring Set name = ?, score =, WHERE ID = ?", name, score, word, id);

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
                conn.Delete<tblscoring>(listid);

            }
            catch (Exception ex)
            {
                Log.Info(tag, "Delete Error:" + ex.Message);
            }
        }

    }
}

