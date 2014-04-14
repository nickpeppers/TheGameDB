using System;
using System.Collections.Generic;
using System.Xml;


namespace GamesDBGroup
{
	class XmlParsingDemo
	{
		static void Main(string[] args)
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load(@"C:\Users\kylej_000\Documents\GitHub\TheGameDB\XMLReader\getGameList.xml");//test location

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");


			List<Game> games = new List<Game>();

			foreach (XmlNode node in nodes)
			{
				Game game = new Game();

				game.id = node.SelectSingleNode("id").InnerText;
				game.title = node.SelectSingleNode("GameTitle").InnerText;
				if (node.SelectSingleNode ("ReleaseDate") != null) {
					game.releaseDate = node.SelectSingleNode ("ReleaseDate").InnerText;
				}
				game.platform=node.SelectSingleNode("Platform").InnerText;


				games.Add(game);
			}

            int x=games.Count;
            for (int y = 0; y < x; y++)
            {
                Console.WriteLine("The ID is: " + games[y].id);
                Console.WriteLine("The Title of the Game is: " + games[y].title);
                Console.WriteLine("The Release Date of the Game is: " + games[y].releaseDate);
                Console.WriteLine("The Platform of the Game is: " + games[y].platform);

                
            }
            Console.ReadLine();
		}
	}

	class Game
	{

		public string id;
		public string title;
        public string releaseDate;
		public string platform;
		

		//place for fanart to list/*IMPORTANT*/
	}
}