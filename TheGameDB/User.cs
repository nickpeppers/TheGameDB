using System;
using System.Security.Policy;

namespace TheGameDB
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Url ProfileUrl { get; set; }
        public string AccountIdentifier { get; set; }
    }
}

