using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public class IWebService
    {
        public async Task<User> Login(User User)
        {
            var user = new User
            {
                UserID = User.UserID,
                Name = User.Name,
                AccountIdentifier = User.AccountIdentifier,
                FacebookToken = User.FacebookToken
            };

            await AzureService.MobileService.GetTable<User>().InsertAsync(user);
            return user;
        }
    }
}

