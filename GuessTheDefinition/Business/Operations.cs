using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace GuessTheDefinition.Business
{
    class Operations
    {

        //public  Dictionary<string, string> LoadDic()
        //{
        //    Dictionary<string, string> DictOxford = new Dictionary<string, string>();

        //    //need to tie the asset manager to these assets in this project This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work. 
        //    try
        //    {

        //        var assets = Assets;
        //        using (var sr = new StreamReader(assets.Open("OxfordDicWithDesc.txt")))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                var text = sr.ReadLine();

        //                if (text != string.Empty && text.Length > 4) //ignore empty lines or words less than 4 letters
        //                {
        //                    text = text.Trim();


        //                    var definition = text.Remove(0, text.IndexOf(' ')); //get the def
        //                    var word = text.Remove(text.IndexOf(' '));

        //                    //cut out the stuff you don't want

        //                    if (word.Contains("-"))
        //                    {
        //                        word = word.Replace("-", "");
        //                    }
        //                    if (word.Contains("1"))
        //                    {
        //                        word = word.Replace("1", "");
        //                    }
        //                    if (word.Contains("2"))
        //                    {
        //                        word = word.Replace("2", "");
        //                    }

        //                    if (definition.Contains("�"))
        //                    {
        //                        //� not working
        //                        definition = definition.Replace("�", "");
        //                    }
        //                    word = word.Trim();
        //                    definition = definition.Trim(); //trim off spaces after got length of defn

        //                    if (!DictOxford.ContainsKey(word) && word.Length > 4)
        //                    {
        //                        //if the word is not already there (apparently there is more than 1 and the word is longer than 4 letters)
        //                        DictOxford.Add(word, definition); //load into dictonary
        //                        DictList.Add(word); //add it to list                     
        //                                            // count++; //count how many entries
        //                    }
        //                }
        //            }
        //        }
        //        return DictOxford
        //        Log.Info(tag, "Dictionary Loaded");
        //    }
        //    catch (Exception)
        //    {

        //        Toast.MakeText(this, "Database didn't load", ToastLength.Short).Show();
        //    }
        //}







    }
}