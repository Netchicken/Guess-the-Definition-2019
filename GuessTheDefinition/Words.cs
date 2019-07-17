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

namespace GuessTheDefinition {
    static class Words {


        public static string Word { get; set; }
        public static string Answer { get; set; }
        public static string NextAnswer { get; set; }
        public static string NextWord { get; set; }

        public static string PrevAnswer { get; set; }
        public static string PrevWord { get; set; }

        public static int Score { get; set; }
        //  public List<string> AllWords { get; set; }
        public static string Name { get; set; }

        //private static string _Name;

        //public static string Name
        //    {
        //    get { return _Name; }
        //    set
        //    {
        //        _Name = value;

        //        if (_Name =="")
        //        {
        //            _Name = " ";
        //        }


        //        ; }
        //    }


        }


    }