using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Facebook;
using System.Collections.Generic;
using Android.Graphics;
using TheGameDB;
using Android;

namespace TheGameDB
{
	[Activity (Label = "TheGamesDB")]
	public class MainActivity :  BaseActivity<LoginViewModel>
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainLayout);

			var searchEditText = FindViewById<EditText> (Resource.Id.MainSearchEditText);

			var searchButton = FindViewById<Button>(Resource.Id.MainSearchButton);
			searchButton.Click += (sender, e) =>
			{
                var gameList = new GamesList();
                var games = gameList.GetGameList(searchEditText.Text);

				var listView = FindViewById<ListView>(Resource.Id.MainSearchListView);
				listView.Adapter = new SearchAdapter(this, games);
			};
		}

		protected void OnListItemClick (ListView l, View v, int position, long id)
		{
			//var selection = games[position];
		}
	}
}


