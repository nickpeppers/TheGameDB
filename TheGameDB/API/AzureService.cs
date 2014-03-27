using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;

namespace TheGameDB
{
    public static class AzureService
    {
        // voting service class to get information from Azure server need url and app key to properly find
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://thegamesdb.azure-mobile.net/", "tHXqYkEehIGzYpNanTnJsxUFjliWul57");
    }
}