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
	class SearchAdapter : BaseAdapter<GamesList>
	{
		GamesList[] games; 
		Activity context; 

		public SearchAdapter(Activity context, GamesList[] g) : base {
			this.context = context;
			this.games = g;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override GamesList this[int position] 
		{  
			get { return items[position]; }
		}

		public override int Count 
		{
			get { return items.Length; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent){
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, null);
			view.FindViewById<Button> (Android.Resource.Id.Text1).Text = games [position];
			return view;
		}

	
	}
}

