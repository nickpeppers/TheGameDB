﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TheGameDB;
using Facebook;
using Android.Content.PM;

namespace TheGameDB
{
    [Activity(Label = "TheGamesDB", MainLauncher = true)]			
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        FacebookClient _fb;
        string _accessToken;
        private const string _appId = "669004006475405";
        private const string _extendedPermissions = "user_about_me,read_stream,publish_stream";
		private Button _loginButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginLayout);

			_loginButton = FindViewById<Button>(Resource.Id.LoginButton);
			_loginButton.Enabled = false;

			_loginButton.Click += (sender, e) => 
            {
                var webAuth = new Intent (this, typeof (FBWebViewAuthActivity));
                webAuth.PutExtra ("AppId", _appId);
                webAuth.PutExtra ("ExtendedPermissions", _extendedPermissions);
                StartActivityForResult (webAuth, 0);
            };

            if (viewModel.settings.User != null)
            {
                viewModel.User = viewModel.settings.User;
                StartActivity(typeof(MainActivity));
                Finish();
            }
            else
            {
				_loginButton.Enabled = true;
            }
        }

        protected override async void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult (requestCode, resultCode, data);

			_loginButton.Enabled = false;

            switch (resultCode) 
            {
                case Result.Ok:
                    {
                        _accessToken = data.GetStringExtra("AccessToken");
                        string userId = data.GetStringExtra("UserId");
                        string error = data.GetStringExtra("Exception");

                        _fb = new FacebookClient(_accessToken);

                        await _fb.GetTaskAsync("me").ContinueWith(t =>
                        {
                            if (!t.IsFaulted)
                            {
                                var result = (IDictionary<string, object>)t.Result;
                                string profileName = (string)result["name"];
                                viewModel.User = new User { UserId = userId, FacebookToken = _accessToken, Name = profileName};
                            }
                            else
                            {
                                Alert("Failed to Log In", "Reason: " + error, false, (res) =>
                                {
                                });
                            }
                        });
                       
                        try
                        {
                            await viewModel.CheckExistingUser(this);
                            if(viewModel.UserExists)
                            {
                                StartActivity(typeof(MainActivity));
                            }
                            else
                            {
                                StartActivity(typeof(CreateAccountActivity));
                            }
                        }
                        catch(Exception exc)
                        {
                            Alert("Failed to check if user exists", "Reason: " + exc, false, (res) =>
                            {
                            });
							_loginButton.Enabled = true;
                        }
                        finally
                        {
                            Finish();
                        }
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

