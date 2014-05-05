using System;
using System.Xml;

namespace TheGameDB
{
	public class Game
	{
		private const string baseImgUrl = "http://thegamesdb.net/banners/";
		public string Image { get; set;}
		public string GameId { get; set; }
        public string GameTitle { get; set; }
        public string PlatformId { get; set; }
		public string Platform { get; set; }
        public string ReleaseDate { get; set; }
		public string OverView { get; set; }
		public string ESRB { get; set; }
        public string Players { get; set; }
        public string CoOperative { get; set; }
		public string Publisher { get; set; }
		public string Developer { get; set; }
		public string Rating { get; set; }

        // Parses Game information from Xml
        public Game GetGame(string GameId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetGame.php?id=" + GameId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

            Game game = new Game();

            foreach (XmlNode node in nodes)
            {
                if(node.SelectSingleNode("id") != null)
                {
                    game.GameId = node.SelectSingleNode("id").InnerText;
                }
                else
                {
                    game.GameId = string.Empty;
                }

                if(node.SelectSingleNode("GameTitle") != null)
                {
                    game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
                }
                else
                {
                    game.GameId = string.Empty;
                }

                if(node.SelectSingleNode("PlatformId") != null)
                {
                    game.PlatformId = node.SelectSingleNode("PlatformId").InnerText;
                }
                else
                {
                    game.PlatformId = string.Empty;
                }

                if(node.SelectSingleNode("Platform") != null)
                {
                    game.Platform=node.SelectSingleNode("Platform").InnerText;
                }
                else
                {
                    game.Platform = string.Empty;
                }

                if(node.SelectSingleNode ("ReleaseDate") != null)
                {
                    game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
                }
                else
                {
                    game.ReleaseDate = string.Empty;
                }

                if(node.SelectSingleNode("Overview") != null)
                {
                    game.OverView = node.SelectSingleNode("Overview").InnerText;
                }
                else
                {
                    game.OverView = string.Empty;
                }

                if(node.SelectSingleNode("ESRB") != null)
                {
                    game.ESRB = node.SelectSingleNode("ESRB").InnerText;
                }
                else
                {
                    game.ESRB = string.Empty;
                }

                if(node.SelectSingleNode("Players") != null)
                {
                    game.Players = node.SelectSingleNode("Players").InnerText;
                }
                else
                {
                    game.Players = string.Empty;
                }
               
                if(node.SelectSingleNode("Co-op") != null)
                {
                    game.CoOperative = node.SelectSingleNode("Co-op").InnerText;
                }
                else
                {
                    game.CoOperative = string.Empty;
                }

                if(node.SelectSingleNode("Publisher") != null)
                {
                    game.Publisher = node.SelectSingleNode("Publisher").InnerText;
                }
                else
                {
                    game.Publisher = string.Empty;
                }

                if(node.SelectSingleNode("Developer") != null)
                {
                    game.Developer = node.SelectSingleNode("Developer").InnerText;
                }
                else
                {
                    game.Developer = string.Empty;
                }

                if(node.SelectSingleNode("Rating") != null)
                {
                    game.Rating = node.SelectSingleNode("Rating").InnerText;
                }
                else
                {
                    game.Rating = string.Empty;
                }
            }

            // Gets url for Game Image
			nodes = doc.DocumentElement.SelectNodes("/Data/Game/Images/boxart");

			if(nodes != null)
			{
				if (nodes.Count == 2)
				{
					if (nodes[1].FirstChild != null)
					{
						if (nodes[1].FirstChild.Value.Contains("front"))
						{
							game.Image = baseImgUrl + nodes[1].FirstChild.Value;
						}
					}
				}
				else if (nodes.Count == 1)
				{
					if (nodes[0].FirstChild != null)
					{
						if (nodes[0].FirstChild.Value.Contains("front"))
						{
							game.Image = baseImgUrl + nodes[0].FirstChild.Value;
						}
					}
				}
				else
				{
					game.Image = string.Empty;
				}
			}

            return game;
        }
	}
}

