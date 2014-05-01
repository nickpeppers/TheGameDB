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
	[Activity (Label = "GameActivity")]			
	public class GameActivity : BaseActivity<LoginViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.GameLayout);

            var gameId = Intent.GetStringExtra("GameId");
            var game = new Game().GetGame(gameId);

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

            //TODO: Forgot to add place for ESRB rating
		}
	}
}

