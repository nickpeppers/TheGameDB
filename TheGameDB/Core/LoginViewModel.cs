using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace TheGameDB
{
    public class LoginViewModel : BaseViewModel
    {
        public User User { get; set; }

        public bool UserExists { get; set; }

        // Task to Check if user exists in the db and save to settings
        public async Task CheckExistingUser(Context context)
        {
            try
            {
                bool userExists = await service.CheckExistingUser(User);
                if(userExists)
                {
                    var user = await AzureService.MobileService.GetTable<User>().Where(u => u.UserId == User.UserId).ToListAsync();
                    if(user.Count > 1)
                    {
                        var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Duplicate user in DataBase.").SetPositiveButton("Okay", (sender1, e1) =>
                        {

                        }).Create();
                        errorDialog.Show();
                        UserExists = userExists;
                    }
                    User = user[0];
                    settings.User = User;
                    settings.IsLoggedIn = true;
                    settings.Save();
                }
                UserExists = userExists;
            }
            catch(Exception exc)
            {
                var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
                UserExists = false;
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Task to Change Account Identifier for a User in the db and save to settings
		public async Task UpdateAccountIdentifier(Context context)
		{
			IsBusy = true;
			try
			{
				User = await service.UpdateAccountIdentifier(User);
				settings.User = User;
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

        // Task to login a User and save to settings
        public async Task Login(Context context)
        {
            if (string.IsNullOrEmpty(User.AccountIdentifier))
                throw new Exception("Your Games DB Account Identifier is blank.");

            IsBusy = true;
            try
            {
                settings.User = await service.Login(User);
				settings.IsLoggedIn = true;
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

