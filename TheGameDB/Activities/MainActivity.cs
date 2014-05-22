using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Graphics;
using TheGameDB;
using Android;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Views.InputMethods;

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

                var gameTabFragment = new GameTabFragment();
                e.FragmentTransaction.Add(Resource.Id.frameLayout, gameTabFragment);
            };

            platformsTab.TabSelected += (sender, e) =>
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.frameLayout);
                if(fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }

                var gameTabFragment = new GameTabFragment();
                e.FragmentTransaction.Add(Resource.Id.frameLayout, new PlatformTabFragment());
            };

            ActionBar.AddTab(gameTab);
            ActionBar.AddTab(platformsTab);
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
                        StartActivity(typeof(SettingsActivity));
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

