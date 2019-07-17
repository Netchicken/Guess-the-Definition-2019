using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace GuessTheDefinition {
    [Activity(Label = "High Scores", MainLauncher = false, Icon = "@drawable/DictionaryIcon", Theme = "@android:style/Theme.Holo.Light")]
    public class Scores : Activity {
        //we need this so we can copy the DB across to the phone or emulator......

        // scoring myScoring = new scoring();
        ListView ListScores;
        List<scoring> myList;
        private string tag = "aaaaa";
        private Button BackToGame;
        DatabaseManager myDbManager = new DatabaseManager();

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            //  get the score passed across from the other project
            //string[] score = { Intent.GetStringExtra("Score") ?? "Data not available" };
            //add the details
            //  myDoList.Details = "Lost on " + score[0] + "with score of " + score[1]; //
            Log.Info(tag, "Scores started");
            //  Set our view from the "GameScore" layout resource
            SetContentView(Resource.Layout.GameScore);
            ListScores = FindViewById<ListView>(Resource.Id.listView1);
            BackToGame = FindViewById<Button>(Resource.Id.BtnBackToGame);
            Log.Info(tag, "resource loaded");
            myList = myDbManager.ViewAll();
            ListScores.Adapter = new DataAdapter(this, myList);
            ListScores.ItemClick += OnListScores_Click;
            BackToGame.Click += BackToGame_Click;

            }

        private void BackToGame_Click(object sender, EventArgs e) {
            StartActivity(typeof(MainActivity));
            this.Finish();
            }


        //Adds Add to the Menu in the top right of your screen.
        public override bool OnCreateOptionsMenu(IMenu menu) {
            menu.Add("Add");
            return base.OnPrepareOptionsMenu(menu);
            }

        private void OnListScores_Click(object sender, AdapterView.ItemClickEventArgs e) {
            //get the list entry at the position clicked on to EDIT THE ENTRY
            var ScoreItem = myList[e.Position];


            //load up the EditItem and pass across the data at that place 
            var edititem = new Intent(this, typeof(EditItem));

            //PutExtra sends across extra data to the Edititem activity that we created above
            edititem.PutExtra("score", ScoreItem.score.ToString());
            edititem.PutExtra("id", ScoreItem.id);
            edititem.PutExtra("name", ScoreItem.name);
            edititem.PutExtra("word", ScoreItem.word);


            StartActivity(edititem);
            this.Finish();
            }


        //When you choose Add from the Menu run the Add Activity
        public override bool OnOptionsItemSelected(IMenuItem item) {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle) {
                case "Add":
                    StartActivity(typeof(AddItem));
                    this.Finish();
                    break;
                }
            return base.OnOptionsItemSelected(item);
            }

        //Basically reload stuff when the app resumes operation after being pauused
        protected override void OnResume() {
            base.OnResume();
            myDbManager = new DatabaseManager();
            myList = myDbManager.ViewAll();
            ListScores.Adapter = new DataAdapter(this, myList);
            }

        }
    }
