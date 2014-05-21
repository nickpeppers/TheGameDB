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
using Android.Graphics;
using Android.Content.PM;

namespace TheGameDB
{
    [Activity (Label = "Settings", LaunchMode = LaunchMode.SingleInstance)]			
    public class ProfileActivity : BaseActivity<SettingsViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ProfileLayout);

			var accountIdentifier = FindViewById<EditText> (Resource.Id.ProfileAccountIdentifierEditText);

			var changeIdentifierButton = FindViewById<Button> (Resource.Id.ProfileChangeIdentifierButton);
			changeIdentifierButton.Click += (sender, e) => 
			{
				if(string.IsNullOrEmpty(accountIdentifier.Text))
				{
					var emptyDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("The account identifier field has been left blank.").SetPositiveButton("Okay", (sender1, e1) =>
					{

					}).Create();
					emptyDialog.Show();
				}
				else
				{
					try
					{

					}
					finally
					{
						Finish();
					}
				}
			};
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
            settingsMenuItem.SetVisible(false);
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

