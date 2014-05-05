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
    [Activity(Label = "TheGamesDB")]			
    public class CreateAccountActivity : BaseActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateAccountLayout);

            var accountIdentifierEditText = FindViewById<EditText>(Resource.Id.CreateAccountIdentifierEditText);
            //TODO: Remove Hard coded for testing purposes
            accountIdentifierEditText.Text = "5089340CC0124FE4";

            var addAccountIdentifier = FindViewById<Button>(Resource.Id.CreateAccountAddButton);
            addAccountIdentifier.Click += async (sender, e) =>
            {
                if(string.IsNullOrEmpty(accountIdentifierEditText.Text))
                {
                    var emptyDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("You must enter your identifier.").SetPositiveButton("Okay", (sender1, e1) => {}).Create();
                    emptyDialog.Show();
                }
                else
                {
                    // Adds entered account identifier to User and tries to log in user
                    viewModel.User.AccountIdentifier = accountIdentifierEditText.Text;
                    await viewModel.Login(this);
                    StartActivity(typeof(MainActivity));
                    Finish();
                }
            };
        }
    }
}

