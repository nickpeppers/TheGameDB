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

namespace TheGameDB
{
    [Activity (Label = "TheGamesDB")]
    public class MainActivity :  BaseActivity<LoginViewModel>
	{

		protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainLayout);

            var searchButton = FindViewById<Button>(Resource.Id.MainSearchButton);
            searchButton.Click += (sender, e) =>
            {

            };
        }
	}
}


