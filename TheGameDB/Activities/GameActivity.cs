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
using System.Net.Http;
using Android.Graphics.Drawables;
using Android.Content.PM;
using Android.Graphics;

namespace TheGameDB
{
    [Activity (Label = "Game", LaunchMode = LaunchMode.SingleInstance)]			
    public class GameActivity : BaseActivity<SettingsViewModel>
	{
		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.GameLayout);

            var gameId = Intent.GetStringExtra("GameId");

            var game = new GamesDBService().GetGame(gameId);

			var image = FindViewById<ImageView> (Resource.Id.GameImage);
            var gameTitle = FindViewById<TextView>(Resource.Id.GameTitleText);
            var platform = FindViewById<TextView>(Resource.Id.GamePlatformText);
            var releaseDate = FindViewById<TextView>(Resource.Id.GameReleaseDateText);
            var overview = FindViewById<TextView>(Resource.Id.GameOverviewText);
            var players = FindViewById<TextView>(Resource.Id.GamePlayersText);
            var cooperative = FindViewById<TextView>(Resource.Id.GameCoopText);
            var publisher = FindViewById<TextView>(Resource.Id.GamePublisherText);
            var developer = FindViewById<TextView>(Resource.Id.GameDeveloperText);
            var rating = FindViewById<TextView>(Resource.Id.GameRatingText);

            gameTitle.Text = game.GameTitle;
            platform.Text = game.Platform;
            releaseDate.Text = "Release Date: " + game.ReleaseDate;
            overview.Text = game.OverView;
            players.Text = "Players: " + game.Players;
            cooperative.Text = "Co-Op: " + game.CoOperative;
            publisher.Text = "Publisher: " + game.Publisher;
            developer.Text = "Developer: " + game.Developer;
            rating.Text = "Rating: " + game.Rating;

            if (!string.IsNullOrEmpty (game.Image)) 
            {
                try
                {
                    var client = new HttpClient();
                    var url = new Uri(game.Image);
                    var stream = await client.GetStreamAsync(url);
                    image.SetMinimumWidth(300);
                    image.SetMinimumHeight(400);
                    image.SetImageDrawable(await Drawable.CreateFromStreamAsync(stream, "src"));
                }
                catch
                {

                }
            }
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate (Resource.Menu.ActionBarMenu, menu);       

            var favoriteMenuItem = menu.FindItem (Resource.Id.FavoriteMenuItem);  
            var unFavoriteMenuItem = menu.FindItem (Resource.Id.UnFavoriteMenuItem); 
            var rateMenuItem = menu.FindItem (Resource.Id.RateAppMenuItem);    
            var settingsMenuItem = menu.FindItem (Resource.Id.SettingsMenuItem); 
            var helpMenuItem = menu.FindItem(Resource.Id.HelpMenuItem);

            //TODO: Need to get list of favorites and check if favorite is true
            bool isFavorite = false;
            if (isFavorite)
            {
                unFavoriteMenuItem.SetVisible(true);
                favoriteMenuItem.SetVisible(false);
                isFavorite = false;
            }
            else
            {
                unFavoriteMenuItem.SetVisible(false);
                favoriteMenuItem.SetVisible(true);
                isFavorite = true;
            }

            return true;
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
                case "Favorite":
                    {
                        return true;
                    }
                case "Unfavorite":
                    {

                        return true;
                    }
                case "Rate App":
                    {
                        return true;
                    }
                case "Settings":
                    {
                        StartActivity(typeof(ProfileActivity));
                        return true;
                    }
                case "Help":
                    {
                        return true;
                    }
                default:
                    return base.OnMenuItemSelected(featureId, item);
            }
        }
	}
}

