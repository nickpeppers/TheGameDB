using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace TheGameDB
{
    public class GameTabFragment : Fragment
    {
        private List<GamesList> _gamesList;
        private Button _searchButton;
        public ListView _listView;

        public override View OnCreateView (LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView (inflater, container, savedInstanceState);

            var view = inflater.Inflate (Resource.Layout.GameSearchTabLayout, container, false);

            var searchEditText = view.FindViewById<EditText> (Resource.Id.GameTabSearchEditText);
            _searchButton = view.FindViewById<Button>(Resource.Id.GameTabSearchButton);
            _listView = view.FindViewById <ListView>(Resource.Id.GameTabSearchListView);

            _searchButton.Click += (sender, e) => 
            {
                _gamesList = new GamesDBService().GetGameList(searchEditText.Text);

                _listView.Adapter = new SearchAdapter(Activity, _gamesList);
            };
                
            _listView.ItemClick += (sender, e) => 
            {
                if(!string.IsNullOrEmpty(_gamesList[e.Position].GameId))
                {
                    var gameIntent = new Intent(Activity, typeof(GameActivity));
                    gameIntent.PutExtra("GameId", _gamesList[e.Position].GameId);
                    StartActivity(gameIntent);
                }
            };

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

            return view;
        }
    }
}

