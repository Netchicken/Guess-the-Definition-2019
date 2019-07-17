using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace GuessTheDefinition {
    public class DataAdapter : BaseAdapter<scoring> {
        private readonly Activity context;

        private readonly List<scoring> items; //make a list of items using the scoring

        public DataAdapter(Activity context, List<scoring> items) {//pass that list and the context to the DA
            this.context = context;
            this.items = items;
            }

        public override scoring this[int position]
            {//return an item at this position
            get { return items[position]; }
            }

        public override int Count
            {//count how many items there are
            get { return items.Count; }
            }

        public override long GetItemId(int position) {
            return position;
            }

        //this creates the new view to be used, ie: the new custom view for each entry, if there is already a view available, it resues that. 
        public override View GetView(int position, View convertView, ViewGroup parent) {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRowScore, null);

            view.FindViewById<TextView>(Resource.Id.lblName).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.lblWord).Text = item.word;
            view.FindViewById<TextView>(Resource.Id.lblScore).Text = item.score.ToString();
            return view;
            }
        }
    }