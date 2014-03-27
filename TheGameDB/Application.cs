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

namespace XamChat.Droid
{
    [Application(Theme = "@android:style/Theme.Holo")]
    public class Application : Android.App.Application
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //ViewModels
            ServiceContainer.Register<LoginViewModel>(() => new LoginViewModel());

            //Models
            ServiceContainer.Register<ISettings>(() => new ISettings());
            ServiceContainer.Register<IWebService>(() => new IWebService());
        }
    }
}

