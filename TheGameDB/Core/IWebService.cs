using System;
using System.Threading.Tasks;

namespace TheGameDB
{
    public interface IWebService
    {
        Task<User> Login(User user, string AcountIdentifier);
    }
}

