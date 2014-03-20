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
using Facebook;

namespace TheGameDB
{
    [Activity(Label = "LoginActivity")]			
    public class LoginActivity : Activity
    {
        FacebookClient _fb;
        AzureService _azureService;
        string _accessToken;
        private const string _appId = "669004006475405";
        private const string _extendedPermissions = "user_about_me,read_stream,publish_stream";
        bool _isLoggedIn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginLayout);

            var loginButton = FindViewById<Button>(Resource.Id.LoginButton);

            loginButton.Click += (sender, e) => 
            {
                var webAuth = new Intent (this, typeof (FBWebViewAuthActivity));
                webAuth.PutExtra ("AppId", _appId);
                webAuth.PutExtra ("ExtendedPermissions", _extendedPermissions);
                StartActivityForResult (webAuth, 0);
            };
        }

        protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult (requestCode, resultCode, data);

            switch (resultCode) 
            {
                case Result.Ok:
                    {
                        _accessToken = data.GetStringExtra("AccessToken");
                        string userId = data.GetStringExtra("UserId");
                        string error = data.GetStringExtra("Exception");

                        _fb = new FacebookClient(_accessToken);

                        _fb.GetTaskAsync("me").ContinueWith(t =>
                        {
                            if (!t.IsFaulted)
                            {
                                var result = (IDictionary<string, object>)t.Result;
                                string profileName = (string)result["name"];
                                _isLoggedIn = true;
                                _azureService.User = new User { UserID = userId, AccountIdentifier = _accessToken, Name = profileName};
                            }
                            else
                            {
                                Alert("Failed to Log In", "Reason: " + error, false, (res) =>
                                {
                                });
                            }
                        });
                    }
                    break;
                case Result.Canceled:
                    Alert ("Failed to Log In", "User Cancelled", false, (res) => {} );
                    break;
                default:
                    break;
            }
        }

        public void Alert (string title, string message, bool CancelButton , Action<Result> callback)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle(title);
            builder.SetIcon(Resource.Drawable.Icon);
            builder.SetMessage(message);

            builder.SetPositiveButton("Ok", (sender, e) => 
            {
                callback(Result.Ok);
            });

            if (CancelButton) 
            {
                builder.SetNegativeButton("Cancel", (sender, e) => 
                {
                    callback(Result.Canceled);
                });
            }
            builder.Show();
        }
    }
}

