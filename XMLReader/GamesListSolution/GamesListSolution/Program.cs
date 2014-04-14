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
			doc.Load(@"C:\Users\kylej_000\Documents\GitHub\TheGameDB\XMLReader\getGame.xml");//test location

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Game");


			List<Game> games = new List<Game>();

			foreach (XmlNode node in nodes)
			{
				Game game = new Game();

				game.id = node.SelectSingleNode("id").InnerText;
				game.title = node.SelectSingleNode("GameTitle").InnerText;
                game.platform = node.SelectSingleNode("Platform").InnerText;
                game.releaseDate = node.SelectSingleNode("ReleaseDate").InnerText;
                game.overView= node.SelectSingleNode("Overview").InnerText;
                game.esrb = node.SelectSingleNode("ESRB").InnerText;



				games.Add(game);
			}


			Console.WriteLine("The ID is: " + games[0].id);
			Console.WriteLine("The Title of the Game is: " + games[0].title);
            Console.WriteLine("The Platform of the game is: " + games[0].platform);
            Console.WriteLine("The Release Date of the game is: " + games[0].releaseDate);
            Console.WriteLine("The OverView of the game is: " + games[0].overView);
            Console.WriteLine("The ESRB Rating is: " + games[0].esrb);


			Console.ReadLine();
		}
	}

	class Game
	{
		public string baseUrl = "http://thegamesdb.net/banners/";
		public string id;
		public string title;
		public string platform;
		public string releaseDate;
		public string overView;
		public string esrb;
		public string genres;//needs to be a list later on ?/*IMPORTANT*/
		public string youtube;
		public string publisher;
		public string developer;
		public string rating;
		//place for fanart to list/*IMPORTANT*/
	}
}