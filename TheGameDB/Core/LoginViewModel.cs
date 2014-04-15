using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace TheGameDB
{
    public class LoginViewModel : BaseViewModel
    {
        public User User { get; set; }

        public async Task CheckExistingUser(Context context)
        {
            try
            {
                bool userExists = await service.CheckExistingUser(User);
                if(userExists)
                {

                }
                settings.Save();
            }
            catch(Exception exc)
            {
                var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task Login(Context context)
        {
            if (string.IsNullOrEmpty(User.AccountIdentifier))
                throw new Exception("Your Games DB Account Identifier is blank.");

            IsBusy = true;
            try
            {
                settings.User = await service.Login(User);
                settings.LoggedIn = true;
                settings.Save();
            }
            catch(Exception exc)
            {
                var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

