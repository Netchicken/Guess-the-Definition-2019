
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GuessTheDefinition.Data;
using GuessTheDefinition.Models;
using Javax.Security.Auth;

namespace GuessTheDefinition
{
    [Activity(Label = "Add your Score")]
    public class AddItem : Activity
    {
        //  private Words mywords;
        Button btnAdd;
        EditText txtAddScore;
        EditText txtAddName;
        EditText txtAddWord;
        private scoring myScore;
        DatabaseManager db = new DatabaseManager();
        private string tag = "aaaaa";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddScore);

            Log.Info(tag, "Started to generate AddItem");
            //https://developer.xamarin.com/recipes/android/fundamentals/activity/pass_data_between_activity/  



            Log.Info(tag, "AddItem words.Word = " + Words.Word);
            Log.Info(tag, "AddItem words.Score = " + Words.Score);

            //Tie the Activity to the Layout
            txtAddName = FindViewById<EditText>(Resource.Id.txtAddName);
            txtAddName.Text = Words.Name;

            txtAddScore = FindViewById<EditText>(Resource.Id.txtAddScore);
            //Pass back the score that you lost on to the layout so you can see it
            txtAddScore.Text = Words.Score.ToString();

            txtAddWord = FindViewById<EditText>(Resource.Id.txtAddWord);
            //Pass back the word that you lost on to the layout so you can see it
            txtAddWord.Text = Words.Word;

            Log.Info(tag, "AddItem txtAddWord = " + txtAddWord.Text);
            Log.Info(tag, "AddItem txtAddScore = " + txtAddScore.Text);

            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.Click += OnBtnAddClick;
        }

        private void OnBtnAddClick(object sender, EventArgs e)
        {
            Log.Info(tag, "OnBtnAddClick");

            //if you forget to add a name remind the person
            if (txtAddName.Text == "")
            {
                Toast.MakeText(this, "Please add Your Name and ty again. ", ToastLength.Long).Show();
                //get abusive
                txtAddName.Text = "Anonymous Coward";
                return;
            }

            //if all the fields have something in them might be redundant with other checks
            if (txtAddName.Text != "" && Words.Score.ToString() != "" && Words.Word != "")
            {

                Words.Name = txtAddName.Text;
                db.AddItem();
                Toast.MakeText(this, "Score Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Scores));

            }
            Toast.MakeText(this, "Borked! Name = " + Words.Name + " Score = " + Words.Score + " Word = " + Words.Word, ToastLength.Long).Show();
        }

    }
}

