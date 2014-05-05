using System;
using System.Xml;

namespace TheGameDB
{
    public class Platform
    {
        private const string baseImgUrl = "http://thegamesdb.net/banners/";
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

        // Parses Platform Information from Xml document
		public Platform GetPlatform(string PlatformId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetPlatform.php?id=" + PlatformId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platform");

			Platform platform = new Platform();

            foreach (XmlNode node in nodes)
            {
                if (node.SelectSingleNode("id") != null)
                {
                    platform.PlatformId = node.SelectSingleNode("id").InnerText;
                }
                else
                {
                    platform.PlatformId = string.Empty;
                }

                if (node.SelectSingleNode("Platform") != null)
                {
                    platform.PlatformTitle = node.SelectSingleNode("Platform").InnerText;
                }
                else
                {
                    platform.PlatformTitle = string.Empty;
                }

                if (node.SelectSingleNode("overview") != null)
                {
                    platform.Overview=node.SelectSingleNode("overview").InnerText;
                }
                else
                {
                    platform.Overview = string.Empty;
                }

                if (node.SelectSingleNode("developer") != null)
                {
                    platform.Developer=node.SelectSingleNode("developer").InnerText;
                }
                else
                {
                    platform.Developer = string.Empty;
                }

                if (node.SelectSingleNode ("manufacturer") != null)
                {
                    platform.Manufacturer = node.SelectSingleNode ("manufacturer").InnerText;
                }
                else
                {
                    platform.Manufacturer = string.Empty;
                }

                if (node.SelectSingleNode("cpu") != null)
                {
                    platform.CPU = node.SelectSingleNode("cpu").InnerText;
                }
                else
                {
                    platform.CPU = string.Empty;
                }

                if (node.SelectSingleNode("memory") != null)
                {
                    platform.Memory = node.SelectSingleNode("memory").InnerText;
                }
                else
                {
                    platform.Memory = string.Empty;
                }

                if (node.SelectSingleNode("graphics") != null)
                {
                    platform.Graphics = node.SelectSingleNode("graphics").InnerText;
                }
                else
                {
                    platform.Graphics = string.Empty;
                }

                if (node.SelectSingleNode("sound") != null)
                {
                    platform.Sound = node.SelectSingleNode("sound").InnerText;
                }
                else
                {
                    platform.Sound = string.Empty;
                }

                if (node.SelectSingleNode("media") != null)
                {
                    platform.Media = node.SelectSingleNode("media").InnerText;
                }
                else
                {
                    platform.Media = string.Empty;
                }

                if (node.SelectSingleNode("maxcontrollers") != null)
                {
                    platform.MaxControllers = node.SelectSingleNode("maxcontrollers").InnerText;
                }
                else
                {
                    platform.MaxControllers = string.Empty;
                }
               
                if (node.SelectSingleNode("Rating") != null)
                {
                    platform.Rating = node.SelectSingleNode("Rating").InnerText;
                }
                else
                {
                    platform.Rating = string.Empty;
                }
            }

            // Gets Image Url for platform
            nodes = doc.DocumentElement.SelectNodes("/Data/Platform/Images/boxart");

            if(nodes != null)
            {
                if (nodes.Count > 0)
                {
                    if (nodes[0].FirstChild != null)
                    {
                        if (nodes[0].FirstChild.Value.Contains("platform/boxart"))
                        {
                            platform.Image = baseImgUrl + nodes[0].FirstChild.Value;
                        }
                    }
                }
                else
                {
                    platform.Image = string.Empty;
                }
            }
            return platform;
        }
    }
}

