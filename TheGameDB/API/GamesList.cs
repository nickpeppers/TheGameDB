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
		public List<GamesList> GetGameList(){
			XmlDocument doc = new XmlDocument ();
			doc.Load(" http://thegamesdb.net/api/GetGamesList.php?name=halo");//test location

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");


			List<GamesList> games = new List<GamesList>();

			foreach (XmlNode node in nodes)
			{
				GamesList game = new GamesList();

				game.GameId = node.SelectSingleNode("id").InnerText;
				game.GameTitle = node.SelectSingleNode("GameTitle").InnerText;
				if (node.SelectSingleNode ("ReleaseDate") != null) {
					game.ReleaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
				}
				game.Platform=node.SelectSingleNode("Platform").InnerText;


				games.Add(game);
			}

			int x=games.Count;
			/*for (int y = 0; y < x; y++)
				{
					Console.WriteLine("The ID is: " + games[y].id);
					Console.WriteLine("The Title of the Game is: " + games[y].title);
					Console.WriteLine("The Release Date of the Game is: " + games[y].releaseDate);
					Console.WriteLine("The Platform of the Game is: " + games[y].platform);


				}*/
			//Console.ReadLine();
			return games;
		}

	}

}

