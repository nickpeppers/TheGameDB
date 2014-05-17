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
using TheGameDB;
using Facebook;
using Android.Content.PM;

namespace TheGameDB
{
    [Activity(Label = "TheGamesDB", MainLauncher = true)]			
    public class LoginActivity : BaseActivity<ISettings>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginLayout);
        }
    }
}

