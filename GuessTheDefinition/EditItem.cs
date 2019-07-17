
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

namespace GuessTheDefinition {
    [Activity(Label = "Edit Your Score   ... Really?")]
    public class EditItem : Activity {

        int ListId;
        string Name;
        string Score;
        private string Word;
        TextView txtName;
        TextView txtScore;
        private TextView txtWord;
        Button btnEdit;
        Button btnDelete;
        DatabaseManager objDb;
        private string tag = "aaaaa";
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.EditScore);

            txtName = FindViewById<TextView>(Resource.Id.txtEditName);
            txtScore = FindViewById<TextView>(Resource.Id.txtEditScore);
            txtWord = FindViewById<TextView>(Resource.Id.txtEditWord);

            btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            btnEdit.Click += OnBtnEditClick;
            btnDelete.Click += OnBtnDeleteClick;

            //when you click on am entry in the Scores.cs it sends across all this data from the entry you clicked on

            ListId = Intent.GetIntExtra("id", 0);
            Score = Intent.GetStringExtra("score");
            Name = Intent.GetStringExtra("name");
            Word = Intent.GetStringExtra("word");
            Log.Info(tag, "ListID " + ListId + " Score " + Score + " Name " + Name + " Word " + Word);
            txtName.Text = Name;
            txtScore.Text = Score.ToString();
            txtWord.Text = Word;

            objDb = new DatabaseManager();
            }

        public void OnBtnEditClick(object sender, EventArgs e) {
            try {
                //we need the txt fields so that you can edit them in the text box
                int score = Convert.ToInt16(txtScore.Text);
                objDb.EditItem(txtName.Text, score, txtWord.Text, ListId);
                //Toast.MakeText(this, "Score Edited", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Scores));
                } catch (Exception ex) {
                Log.Info(tag, "Edit Error:" + ex.Message.ToString());
                Toast.MakeText(this, "A field is missing, Please add it", ToastLength.Long).Show();
                }
            }

        public void OnBtnDeleteClick(object sender, EventArgs e) {
            try {
                objDb.DeleteItem(ListId);
                Toast.MakeText(this, "Score Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Scores));
                } catch (Exception ex) {
                Log.Info(tag, "Delete Error listid = " + ListId + " " + ex.Message.ToString());
                }
            }

        }
    }

