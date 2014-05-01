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
	[Activity (Label = "PlatformActivity")]			
	public class PlatformActivity : BaseActivity<LoginViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.PlatformLayout);

            var platformId = Intent.GetStringExtra("PlatformId");
            var platform = new Platform().GetPlatform(platformId);

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
		}
	}
}

