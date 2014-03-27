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
    [Activity(Label = "CreateAccountActivity")]			
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
                    //TODO: Show text empty popup
                }
                else
                {
                    viewModel.User.AccountIdentifier = accountIdentifierEditText.Text;
                    await viewModel.Login();
                }
            };
        }
    }
}

