using System;
using System.Threading.Tasks;

namespace TheGameDB
{
	public class IWebService
	{
        // Checks db for if the User is in it based on UserId
		public async Task<bool> CheckExistingUser(User User)
		{
			var userExists =  await AzureService.MobileService.GetTable<User>().Where (t => t.UserId == User.UserId).ToListAsync ();
			if (userExists.Count > 0) 
			{
				return true;
			} 
			else
			{
				return false;
			}
		}

        // Updates User Account Identifier in db
		public async Task<User> UpdateAccountIdentifier(User User)
		{
			await AzureService.MobileService.GetTable<User>().UpdateAsync(User);

			return User;
		}

        // Adds user to db
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

