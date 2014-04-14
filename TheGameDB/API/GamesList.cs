using System;
using System.Xml;

namespace TheGameDB
{
	public class GamesList
	{
		public int GameId{ get; set; }
		public string GameTitle{ get; set; }
		public string ReleaseDate { get; set; }
        public string Platform {get; set;}
	


	public GamesList createGameFromXml(string name){

			String URLString = "http://thegamesdb.net/api/GetGamesList.php?name=" + name;
			XmlTextReader reader = new XmlTextReader (URLString);
			GamesList x = new GamesList ();
			while (reader.Read ()) {
				switch (reader.NodeType) {
				case XmlNodeType.Element: // The node is an element.
					Console.Write ("<" + reader.Name);
					while (reader.MoveToNextAttribute ()) // Read the attributes.
					Console.Write (" " + reader.Name + "='" + reader.Value + "'");
					Console.Write (">");
					Console.WriteLine (">");
					break;
				case XmlNodeType.Text: //Display the text in each element.
					Console.WriteLine (reader.Value);
					break;
				case XmlNodeType. EndElement: //Display the end of the element.
					Console.Write ("</" + reader.Name);
					Console.WriteLine (">");
					break;



				}

			}
			return x;
		}
	}
}

