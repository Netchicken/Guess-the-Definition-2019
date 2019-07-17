using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace GuessTheDefinition {
    [Activity(Label = "Show me something Interesting")]
    public class Web : Activity {

        WebView webview;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Web);

            webview = FindViewById<WebView>(Resource.Id.webView1);
            webview.Settings.JavaScriptEnabled = true;
            webview.LoadUrl("https://m.reddit.com/");
            }
        }
    }