using System;
using System.Xml;

namespace TheGameDB
{
    public class Platform
    {
        public string BaseImgUrl = "http://thegamesdb.net/banners/";
        public string Image { get; set;}
		public string PlatformId { get; set; }
        public string PlatformTitle { get; set; }
        public string Overview { get; set; }
        public string Developer { get; set; }
        public string Manufacturer { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string Graphics { get; set; }
        public string Sound { get; set; }
        public string Display { get; set; }
        public string Media { get; set; }
        public string MaxControllers { get; set; }
        public string Rating { get; set; }
    }
}

