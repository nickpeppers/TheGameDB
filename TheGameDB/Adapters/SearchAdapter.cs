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

namespace TheGameDB
{
	public class SearchAdapter : BaseAdapter<GamesList>
	{
		List<GamesList> games; 
		Activity context; 

		public SearchAdapter(Activity context, List<GamesList> g) : base ()
		{
			this.context = context;
			this.games = g;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override GamesList this[int position] 
		{  
			get { return games[position]; }
		}

		public override int Count 
		{
			get { return games.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.MainSearchRowLayout, null);
            }
            view.FindViewById<TextView> (Resource.Id.MainSearchRowTitleTextView).Text = games [position].GameTitle;
            view.FindViewById<TextView> (Resource.Id.MainSearchRowReleaseTextView).Text = games [position].ReleaseDate;
            view.FindViewById<TextView> (Resource.Id.MainSearchRowPlatformTextView).Text = games [position].Platform;
			return view;
		}
	}
}

