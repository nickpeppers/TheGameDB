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

                // Creates List of PlatformList
				_listView.Adapter = new ArrayAdapter<PlatformsList>(this, Android.Resource.Layout.SimpleListItem1, _platformList);
            };
           
            _searchButton.Click += (sender, e) =>
            {
                _gamesButton.Enabled = false;
                _platformsButton.Enabled = true;

				_gamesList = new GamesList().GetGameList(searchEditText.Text);

                // Creates List of Games
				_listView.Adapter = new SearchAdapter(this, _gamesList);
            };

			_listView.ItemClick += (sender, e) => 
			{
                // if Select Game row in list
				if(!_gamesButton.Enabled)
				{
					var gameIntent = new Intent(this, typeof(GameActivity));
					gameIntent.PutExtra("GameId", _gamesList[e.Position].GameId);
					StartActivity(gameIntent);
				}
                // if Select Platform row in list
				else
				{
					var platformIntent = new Intent(this, typeof(PlatformActivity));
					platformIntent.PutExtra("PlatformId", _platformList[e.Position].PlatformId);
					StartActivity(platformIntent);
				}
			};
				
            // Searches if enter is pressed on keyboard
			searchEditText.KeyPress += (object sender, View.KeyEventArgs e) => 
			{
				if(e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				{
					_searchButton.PerformClick();
				}
				else 
				{
					e.Handled = false;
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


