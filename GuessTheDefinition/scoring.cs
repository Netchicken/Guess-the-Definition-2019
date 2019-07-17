using System;
using SQLite;

namespace GuessTheDefinition {
    public class scoring {
        [PrimaryKey, AutoIncrement]  //this is really important!
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public string word { get; set; }
        public DateTime date { get; set; }
        }
    }