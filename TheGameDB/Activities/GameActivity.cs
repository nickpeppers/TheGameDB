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

namespace TheGameDB
{
	[Activity (Label = "GameActivity")]			
	public class GameActivity : BaseActivity<LoginViewModel>
	{
		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.GameLayout);

            // Gets Game Id from previous activity
            var gameId = Intent.GetStringExtra("GameId");

            // Loads game Info
            var game = new Game().GetGame(gameId);

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

            // Sets text
            gameTitle.Text = game.GameTitle;
            platform.Text = game.Platform;
            releaseDate.Text = "Release Date: " + game.ReleaseDate;
            overview.Text = game.OverView;
            players.Text = "Players: " + game.Players;
            cooperative.Text = "Co-Op: " + game.CoOperative;
            publisher.Text = "Publisher: " + game.Publisher;
            developer.Text = "Developer: " + game.Developer;
            rating.Text = "Rating: " + game.Rating;

            // Loads image asynchronously from url
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
	}
}

