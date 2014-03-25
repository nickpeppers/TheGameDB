using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public class LoginViewModel : BaseViewModel
    {
        public User User { get; set; }

        public string AccountIdentifier { get; set; }

        public async Task Login()
        {
            if (string.IsNullOrEmpty(AccountIdentifier))
                throw new Exception("Your Games DB Account Identifier is blank.");

            IsBusy = true;
            try
            {
                settings.User = await service.Login(User, AccountIdentifier);
                settings.LoggedIn = true;
                settings.Save();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

