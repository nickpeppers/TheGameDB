using System;

namespace TheGameDB
{
    public class ISettings
    {
        public User User { get; set; }

        public bool LoggedIn { get; set; }

        public void Save() { }
    }
}

