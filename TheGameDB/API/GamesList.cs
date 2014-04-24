using System;
using System.Xml;
using System.Collections.Generic;

namespace TheGameDB
{
	public class GamesList
	{
		public string GameId{ get; set; }
		public string GameTitle{ get; set; }
		public string ReleaseDate { get; set; }
        public string Platform {get; set;}

		/*This is where the creater method should go*/
        public List<GamesList> GetGameList(string SearchText)
        {
			XmlDocument doc = new XmlDocument ();
            doc.Load("http://thegamesdb.net/api/GetGamesList.php?name=" + SearchText);//test location

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");

			List<GamesList> games = new List<GamesList>();

			foreach (XmlNode node in nodes)
			{
				GamesList game = new GamesList();

				game.GameId = node.SelectSingleNode("id").InnerText;
				game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
				if (node.SelectSingleNode ("ReleaseDate") != null) 
                {
					game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
				}
				game.Platform=node.SelectSingleNode("Platform").InnerText;

				games.Add(game);
			}
			return games;
		}

	}

}

