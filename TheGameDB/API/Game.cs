using System;
using System.Xml;

namespace TheGameDB
{
	public class Game
	{
        public string baseImgUrl { get; set; }
		public string GameId { get; set; }
        public string GameTitle { get; set; }
        public string PlatformId { get; set; }
		public string Platform { get; set; }
        public string ReleaseDate { get; set; }
		public string OverView { get; set; }
		public string ESRB { get; set; }
        //TODO: Multiple genres work
        //public string Genres { get; set; }
        public string Players { get; set; }
        public string CoOperative { get; set; }
		public string YoutubeLink { get; set; }
		public string Publisher { get; set; }
		public string Developer { get; set; }
		public string Rating { get; set; }
		//TODO: Fan Art Class 

        public Game GetGame(string GameId)
        {
            XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetGame.php?id=" + GameId);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

            Game game = new Game();

            foreach (XmlNode node in nodes)
            {
                game.GameId = node.SelectSingleNode("id").InnerText;
                game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
                game.PlatformId=node.SelectSingleNode("PlatformId").InnerText;
                game.Platform=node.SelectSingleNode("Platform").InnerText;
                game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
                game.OverView = node.SelectSingleNode("Overview").InnerText;
                game.ESRB = node.SelectSingleNode("ESRB").InnerText;
                game.Players = node.SelectSingleNode("Players").InnerText;
                game.CoOperative = node.SelectSingleNode("Co-op").InnerText;
                game.YoutubeLink = node.SelectSingleNode("Youtube").InnerText;
                game.Publisher = node.SelectSingleNode("Publisher").InnerText;
                game.Developer = node.SelectSingleNode("Developer").InnerText;
                game.Rating = node.SelectSingleNode("Rating").InnerText;
            }
            return game;
        }
	}
}

