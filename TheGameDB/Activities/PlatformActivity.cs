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
		}
	}
}

