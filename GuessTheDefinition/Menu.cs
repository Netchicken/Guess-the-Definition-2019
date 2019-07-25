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

namespace GuessTheDefinition
{
    internal class Menu : Activity
    {


        //Adds Add to the Menu in the top right of your screen.
        //https://developer.xamarin.com/api/type/Android.Views.IMenu/
        //https://developer.xamarin.com/samples/mobile/StandardControls/
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("All Scores");
            menu.Add("Play a Game");
            menu.Add("Add New Score");
            menu.Add("I'm bored");
            menu.Add("Open A Browser");
            return base.OnPrepareOptionsMenu(menu);
        }
        //When you choose Add from the Menu run the Add Activity
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "All Scores":
                    StartActivity(typeof(Scores));
                    break;
                case "Play a Game":
                    StartActivity(typeof(MainActivity));
                    break;
                case "Add New Score":
                    // count = 0; //don't keep the old score.
                    StartActivity(typeof(AddItem));
                    Finish();
                    break;
                case "I'm bored":
                    StartActivity(typeof(Web));
                    break;
                case "Open A Browser":
                    //https://developer.xamarin.com/recipes/android/fundamentals/intent/open_a_webpage_in_the_browser_application/

                    var uri = Android.Net.Uri.Parse("https://news.google.com/");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }





    }
}