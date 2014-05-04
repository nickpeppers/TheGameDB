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
	[Activity (Label = "ProfileActivity")]			
	public class ProfileActivity : BaseActivity<LoginViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ProfileLayout);

			var accountIdentifier = FindViewById<EditText> (Resource.Id.ProfileAccountIdentifierEditText);

			var changeIdentifierButton = FindViewById<Button> (Resource.Id.ProfileChangeIdentifierButton);
			changeIdentifierButton.Click += async (sender, e) => 
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
						viewModel.User.AccountIdentifier = accountIdentifier.Text;
						await viewModel.UpdateAccountIdentifier(this);
					}
					finally
					{
						Finish();
					}
				}
			};
		}
	}
}

