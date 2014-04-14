using System;
using System.Xml;

namespace TheGameDB
{
	public class Game
	{
		public string baseImgUrl{ get; set; }
		public int gameID{ get; set; }
		public string GameTitle{ get; set; }
		public string Platform { get; set; }
		public string ReleaseDate{ get; set; }
		public string OverView { get; set; }
		public string ESRB { get; set; }
		public string Genres { get; set; }
		public string YoutubeLink { get; set; }
		public string Publisher { get; set; }
		public string Developer { get; set; }
		public string Rating { get; set; }
		//TODO: Fan Art Class 



		public Game createGameFromXml(int id){
			Game x = new Game ();
			String URLString = "http://thegamesdb.net/api/GetGame.php?id=" + id;
			XmlTextReader reader = new XmlTextReader (URLString);

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

