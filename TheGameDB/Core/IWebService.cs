using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public class IWebService
    {
        public async Task<User> Login(User user)
        {
            await AzureService.MobileService.GetTable<User>().InsertAsync(user);
            return user;
        }
    }
}

