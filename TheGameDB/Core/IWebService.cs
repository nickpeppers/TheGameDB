using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public class IWebService
    {
        public async Task<bool> CheckExistingUser(User User)
        {
            bool userExists = false;
            var users = await AzureService.MobileService.GetTable<User>().ToListAsync();
            return userExists;
        }

        public async Task<User> Login(User User)
        {
            var user = new User
            {
				UserId = User.UserId,
                Name = User.Name,
                AccountIdentifier = User.AccountIdentifier,
                FacebookToken = User.FacebookToken
            };

            await AzureService.MobileService.GetTable<User>().InsertAsync(user);
            return user;
        }
    }
}

