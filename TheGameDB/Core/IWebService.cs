using System;
using System.Threading.Tasks;

namespace TheGameDB
{
	public class IWebService
	{
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

		public async Task<User> UpdateAccountIdentifier(User User)
		{
			await AzureService.MobileService.GetTable<User>().UpdateAsync(User);

			return User;
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

