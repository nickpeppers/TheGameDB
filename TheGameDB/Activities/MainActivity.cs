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
        private Button _gamesButton;
        private Button _platformsButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainLayout);

			var searchEditText = FindViewById<EditText> (Resource.Id.MainSearchEditText);

            _searchButton = FindViewById<Button>(Resource.Id.MainSearchButton);
            _gamesButton = FindViewById<Button>(Resource.Id.MainGamesSearchbarButton);
            _platformsButton = FindViewById<Button>(Resource.Id.MainPlatformsSearchBarButton);

            _gamesButton.Click += (sender, e) => 
            {
                _gamesButton.Enabled = false;
                _platformsButton.Enabled = true;
                _searchButton.PerformClick();
            };

            _platformsButton.Click += (sender, e) => 
            {
                _platformsButton.Enabled = false;
                _gamesButton.Enabled = true;

                var platformList = new PlatformsList().GetPlatformsList();

                var listView = FindViewById<ListView>(Resource.Id.MainSearchListView);
                listView.Adapter = new ArrayAdapter<PlatformsList>(this, Android.Resource.Layout.SimpleListItem1, platformList);
            };
           
            _searchButton.Click += (sender, e) =>
            {
                _gamesButton.Enabled = false;
                _platformsButton.Enabled = true;

                var gameList = new GamesList();
                var games = gameList.GetGameList(searchEditText.Text);

                var listView = FindViewById<ListView>(Resource.Id.MainSearchListView);
                listView.Adapter = new SearchAdapter(this, games);
            };

            _gamesButton.Enabled = false;
		}

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            if (!_searchButton.Enabled)
                _searchButton.PerformClick();
            else
                _platformsButton.PerformClick();
        }

		protected void OnListItemClick (ListView l, View v, int position, long id)
		{
            if (!_gamesButton.Enabled)
            {
                //TODO: go to game information screen
            }
            else if(!_platformsButton.Enabled)
            {
                //TODO: go to platform information screen
            }
			//var selection = games[position];
		}
	}
}


