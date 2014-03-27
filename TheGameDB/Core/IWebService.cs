using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public class IWebService
    {
        public async Task<User> Login(User User)
        {
            var me = User;
            var users = AzureService.MobileService.GetTable<User>();
            await users.InsertAsync(me);
            return me;
        }
    }
}

