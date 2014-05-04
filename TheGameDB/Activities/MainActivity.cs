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
		private ListView _listView;
		private List<GamesList> _gamesList;
		private List<PlatformsList> _platformList = new PlatformsList().GetPlatformsList();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainLayout);

			var searchEditText = FindViewById<EditText> (Resource.Id.MainSearchEditText);

			var profileButton = FindViewById<Button>(Resource.Id.MainProfileSearchBarButton);
            _searchButton = FindViewById<Button>(Resource.Id.MainSearchButton);
            _gamesButton = FindViewById<Button>(Resource.Id.MainGamesSearchbarButton);
            _platformsButton = FindViewById<Button>(Resource.Id.MainPlatformsSearchBarButton);

			_listView = FindViewById<ListView>(Resource.Id.MainSearchListView);

			profileButton.Click += (sender, e) => 
			{
				StartActivity(typeof(ProfileActivity));
			};

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

				_listView.Adapter = new ArrayAdapter<PlatformsList>(this, Android.Resource.Layout.SimpleListItem1, _platformList);
            };
           
            _searchButton.Click += (sender, e) =>
            {
                _gamesButton.Enabled = false;
                _platformsButton.Enabled = true;

				_gamesList = new GamesList().GetGameList(searchEditText.Text);

				_listView.Adapter = new SearchAdapter(this, _gamesList);
            };

			_listView.ItemClick += (sender, e) => 
			{
				if(!_gamesButton.Enabled)
				{
					var gameIntent = new Intent(this, typeof(GameActivity));
					gameIntent.PutExtra("GameId", _gamesList[e.Position].GameId);
					StartActivity(gameIntent);
				}
				else
				{
					var platformIntent = new Intent(this, typeof(PlatformActivity));
					platformIntent.PutExtra("PlatformId", _platformList[e.Position].PlatformId);
					StartActivity(platformIntent);
				}
			};

            _gamesButton.Enabled = false;
		}

		// For loading list on rotation
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

			if (!_searchButton.Enabled) 
			{
				_searchButton.PerformClick ();
			}
			else if(!_platformsButton.Enabled)
			{
				_platformsButton.PerformClick ();
			}
        }
	}
}


