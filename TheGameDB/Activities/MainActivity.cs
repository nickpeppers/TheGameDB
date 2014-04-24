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
using Android.Content.PM;

namespace TheGameDB
{
    [Activity (Label = "TheGamesDB", ConfigurationChanges = ConfigChanges.Orientation|ConfigChanges.ScreenSize)]
	public class MainActivity :  BaseActivity<LoginViewModel>
	{
        private Button _searchButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainLayout);

			var searchEditText = FindViewById<EditText> (Resource.Id.MainSearchEditText);

            _searchButton = FindViewById<Button>(Resource.Id.MainSearchButton);
            _searchButton.Click += (sender, e) =>
			{
                var gameList = new GamesList();
                var games = gameList.GetGameList(searchEditText.Text);

				var listView = FindViewById<ListView>(Resource.Id.MainSearchListView);
				listView.Adapter = new SearchAdapter(this, games);
			};
		}

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            _searchButton.PerformClick();
        }

		protected void OnListItemClick (ListView l, View v, int position, long id)
		{
			//var selection = games[position];
		}
	}
}


