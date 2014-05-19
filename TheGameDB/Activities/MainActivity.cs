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
    public class MainActivity : BaseActivity<SettingsViewModel>
	{
		protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainLayout);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            var gameTab = ActionBar.NewTab();
            gameTab.SetText("Games");
            var platformsTab = ActionBar.NewTab();
            platformsTab.SetText("Platforms");

            gameTab.TabSelected += (sender, e) =>
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.frameLayout);
                if(fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.frameLayout, new GameTabFragment());
            };

            platformsTab.TabSelected += (sender, e) =>
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.frameLayout);
                if(fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.frameLayout, new PlatformTabFragment());
            };

            ActionBar.AddTab(gameTab);
            ActionBar.AddTab(platformsTab);
        }
	}
}

