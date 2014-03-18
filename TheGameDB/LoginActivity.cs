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
using TheGameDB.Android;

namespace TheGameDB
{
    [Activity(Label = "LoginActivity")]			
    public class LoginActivity : Activity
    {
        private const string AppId = "669004006475405";
        private const string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginLayout);

            var loginButton = FindViewById<Button>(Resource.Id.LoginButton);

            loginButton.Click += (sender, e) => 
            {
                var webAuth = new Intent (this, typeof (FBWebViewAuthActivity));
                webAuth.PutExtra ("AppId", AppId);
                webAuth.PutExtra ("ExtendedPermissions", ExtendedPermissions);
                StartActivityForResult (webAuth, 0);
            };
        }
    }
}

