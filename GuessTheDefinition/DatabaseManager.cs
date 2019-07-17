using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Util;
using Android.Widget;
using SQLite;
using Environment = Android.OS.Environment;

namespace GuessTheDefinition {
    public class DatabaseManager {

        //https://components.xamarin.com/gettingstarted/sqlite-net 
        //https://github.com/praeclarum/sqlite-net
        //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/

        //https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs


        //YOUR CLASS NAME MUST BE YOUR TABLE NAME
        private string tag = "aaaaa";
        SQLiteConnection db;



        public DatabaseManager() {
            DBConnect();
            }

        public List<scoring> ViewAll() {
            try {
                //SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scoring.sqlite"));

                return db.Query<scoring>("SELECT * FROM SelectDescScores");
                } catch (Exception e) {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
                }
            }

        private void DBConnect() {
            db =
                new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(),
                    "Scoring.sqlite"));
            }

        public void AddItem() {

            //http://javatechig.com/xamarin/using-sqlite-net-orm-in-xamarin-application 
            Log.Info(tag, "AddItem Word = " + Words.Name + " AddItem Score = " + Words.Score + " AddItem Word = " + Words.Word);

            try {
                var AddThis = new scoring
                    {
                    name = Words.Name,
                    score = Words.Score,
                    word = Words.Word
                    };

                db.Insert(AddThis);

                //   db.Execute("INSERT INTO scoring(name, score, word) VALUES(?1,? 2,? 3))
                Log.Info(tag, "Data Added " + AddThis);

                } catch (Exception e) {
                Log.Info(tag, "Add Error:  " + e.Message);
                }
            }

        public void EditItem(string name, int score, string word, int id) {
            try {
                //http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated


                var EditThis = new scoring
                    {
                    id = id,
                    name = name,
                    score = score,
                    word = word
                    };

                db.Update(EditThis);

                //or this
                //  db.Execute("UPDATE scoring Set name = ?, score =, WHERE ID = ?", name, score, word, id);

                } catch (Exception e) {

                Log.Info(tag, "Update Error:" + e.Message.ToString());

                }
            }

        public void DeleteItem(int listid) {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            try {
                db.Delete<scoring>(listid);

                } catch (Exception ex) {
                Log.Info(tag, "Delete Error:" + ex.Message);
                }
            }

        }
    }

