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
using Android.Graphics.Drawables;
using System.Net.Http;
using Android.Content.PM;
using Android.Graphics;

namespace TheGameDB
{
    [Activity (Label = "Platform")]			
    public class PlatformActivity : BaseActivity<SettingsViewModel>
	{
        protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.PlatformLayout);

            var platformId = Intent.GetStringExtra("PlatformId");

            var platform = new GamesDBService().GetPlatform(platformId);

            var image = FindViewById<ImageView>(Resource.Id.PlatformImage);
            var title = FindViewById<TextView>(Resource.Id.PlatformTitleText);
            var overview = FindViewById<TextView>(Resource.Id.PlatformOverviewText);
            var developer = FindViewById<TextView>(Resource.Id.PlatformDeveloperText);
            var manufacturer = FindViewById<TextView>(Resource.Id.PlatformManufacturerText);
            var cpu = FindViewById<TextView>(Resource.Id.PlatformCPUText);
            var memory = FindViewById<TextView>(Resource.Id.PlatformMemoryText);
            var graphics = FindViewById<TextView>(Resource.Id.PlatformGraphicsText);
            var sound = FindViewById<TextView>(Resource.Id.PlatformSoundText);
            var display = FindViewById<TextView>(Resource.Id.PlatformDisplayText);
            var media = FindViewById<TextView>(Resource.Id.PlatformMediaText);
            var maxControllers = FindViewById<TextView>(Resource.Id.PlatformMaxControllersText);
            var rating = FindViewById<TextView>(Resource.Id.PlatformRatingText);
            //TODO: Add butt to take you to list of platform games

            title.Text = platform.PlatformTitle;
            overview.Text = platform.Overview;
            developer.Text = "Developer: " + platform.Developer;
            manufacturer.Text = "Manufacturer: " + platform.Manufacturer;
            cpu.Text = "CPU: " + platform.CPU;
            memory.Text = "Memory: " + platform.Memory;
            graphics.Text = "Graphics: " + platform.Graphics;
            sound.Text = "Sound: " +  platform.Sound;
            display.Text = "Display: " + platform.Display;
            media.Text = "Media: " + platform.Media;
            maxControllers.Text = "Max Controllers: " + platform.MaxControllers;
            rating.Text = "Rating: " + platform.Rating;

            if (!string.IsNullOrEmpty (platform.Image)) 
            {
                try
                {
                    var client = new HttpClient();
                    var url = new Uri(platform.Image);
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

            favoriteMenuItem.SetVisible(false);
            unFavoriteMenuItem.SetVisible(false);

            return true;
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
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

