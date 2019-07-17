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
    [Activity(Label = "Satellite Menu", MainLauncher = false)]
    class CustomMenu : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {

            //turns off title at the top of the screen
            //  Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            // load the main layout, it is a gray background with frame layout and out menu control on it, please note in the axml how we change the default speed of the animation from 400ms to 250ms with the markup
            //    SetContentView(Resource.Layout.Menu);

            // array of items
            //    LoadRoundMenu();
        }

        //public void LoadRoundMenu()
        //{

        //var menu = FindViewById<SatelliteMenuButton>(Resource.Id.menu);
        //// SatelliteMenuButton menu;
        //var items = new List<SatelliteMenuButtonItem>();

        //// just add one by one
        //items.Add(new SatelliteMenuButtonItem((int)MenuItemType.AllScores, Resource.Drawable.icon1));
        //items.Add(new SatelliteMenuButtonItem((int)MenuItemType.PlayGame, Resource.Drawable.icon2));
        //items.Add(new SatelliteMenuButtonItem((int)MenuItemType.AddScore, Resource.Drawable.icon3));
        //items.Add(new SatelliteMenuButtonItem((int)MenuItemType.Bored, Resource.Drawable.icon4));
        //items.Add(new SatelliteMenuButtonItem((int)MenuItemType.Browser, Resource.Drawable.icon5));

        //    // now add all to the menus
        //    menu.AddItems(items.ToArray());


        //    menu.MenuItemClick += (sender, e) =>
        //    {
        //        // Console.WriteLine("{0} selected", e.MenuItem);

        //        switch (e.MenuItem.Tag) {
        //            case 0:
        //                StartActivity(typeof(Scores));
        //                break;
        //            case 1:
        //                StartActivity(typeof(MainActivity));
        //                break;
        //            case 2:
        //                //  count = 0; //don't keep the old score.
        //                StartActivity(typeof(AddItem));
        //                Finish();
        //                break;
        //            case 3:
        //                StartActivity(typeof(Web));
        //                break;
        //            case 4:
        //                //https://developer.xamarin.com/recipes/android/fundamentals/intent/open_a_webpage_in_the_browser_application/

        //                var uri = Android.Net.Uri.Parse("https://news.google.com/");
        //                var intent = new Intent(Intent.ActionView, uri);
        //                StartActivity(intent);
        //                break;
        //            }
        //    };
        //    }

        //public enum MenuItemType {
        //    AllScores = 0,
        //    PlayGame = 1,
        //    AddScore = 2,
        //    Bored = 3,
        //    Browser = 4,
        //    // Reload = 5
        //    }
        //public override bool OnCreateOptionsMenu(IMenu menu) {


        //    menu.Add("All Scores");
        //    menu.Add("Play a Game");
        //    menu.Add("Add New Score");
        //    menu.Add("I'm bored");
        //    menu.Add("Open A Browser");
        //    return base.OnPrepareOptionsMenu(menu);
        //    }
        ////When you choose Add from the Menu run the Add Activity
        //public override bool OnOptionsItemSelected(IMenuItem item) {
        //    var itemTitle = item.TitleFormatted.ToString();

        //    switch (itemTitle) {
        //        case "All Scores":
        //            StartActivity(typeof(Scores));
        //            break;
        //        case "Play a Game":
        //            StartActivity(typeof(MainActivity));
        //            break;
        //        case "Add New Score":
        //            //  count = 0; //don't keep the old score.
        //            StartActivity(typeof(AddItem));
        //            Finish();
        //            break;
        //        case "I'm bored":
        //            StartActivity(typeof(Web));
        //            break;
        //        case "Open A Browser":
        //            //https://developer.xamarin.com/recipes/android/fundamentals/intent/open_a_webpage_in_the_browser_application/

        //            var uri = Android.Net.Uri.Parse("https://news.google.com/");
        //            var intent = new Intent(Intent.ActionView, uri);
        //            StartActivity(intent);
        //            break;
        //        }
        //    return base.OnOptionsItemSelected(item);
        //    }








    }
}