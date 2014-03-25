using System;

namespace TheGameDB
{
    public interface ISettings
    {
        User User { get; set; }

        bool LoggedIn { get; set; }

        void Save();
    }
}

