using System;

namespace TheGameDB
{
    public class SettingsViewModel : BaseViewModel
    {
        public string AccountIdentifier { get; set;}
        public bool HasEnteredAccountIdentifier { get; set;}

        public void AddAccountIdentifier (string accountIdentifier)
        {
            settings.AccountIdentifier = accountIdentifier;
            AccountIdentifier = accountIdentifier;

            HasEnteredAccountIdentifier = true;
           
            settings.Save();
        }

        public void LoadSettings()
        {
            if (!string.IsNullOrEmpty(settings.AccountIdentifier))
            {
                AccountIdentifier = settings.AccountIdentifier;
                HasEnteredAccountIdentifier = true;
            }
            else
            {
                HasEnteredAccountIdentifier = false;
            }
        }
    }
}

