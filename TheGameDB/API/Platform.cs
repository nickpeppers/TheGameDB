using System;
using System.Xml;

namespace TheGameDB
{
    public class Platform
    {
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
        //TODO: Need to do get images

		public Platform GetPlatform(string PlatformId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetPlatform.php?id=" + PlatformId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

			Platform platform = new Platform();

            foreach (XmlNode node in nodes)
            {
                platform.PlatformId = node.SelectSingleNode("id").InnerText;
                platform.PlatformTitle = node.SelectSingleNode("Platform").InnerText;
                platform.Overview=node.SelectSingleNode("overview").InnerText;
                platform.Developer=node.SelectSingleNode("developer").InnerText;
                platform.Manufacturer = node.SelectSingleNode ("manufacturer").InnerText;
                platform.CPU = node.SelectSingleNode("cpu").InnerText;
                platform.Memory = node.SelectSingleNode("memory").InnerText;
                platform.Graphics = node.SelectSingleNode("graphics").InnerText;
                platform.Sound = node.SelectSingleNode("sound").InnerText;
                platform.Media = node.SelectSingleNode("media").InnerText;
                platform.MaxControllers = node.SelectSingleNode("maxcontrollers").InnerText;
                platform.Rating = node.SelectSingleNode("Rating").InnerText;
            }
            return platform;
        }
    }
}

