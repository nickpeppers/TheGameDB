using System;
using System.Xml;
using System.Collections.Generic;

namespace TheGameDB
{


	public class PlatformsList
		{
		public string PlatformId{ get; set; }
		public string PlatformName{ get; set; }
		public string PlatformAlias { get; set; }

			/*This is where the creater method should go*/
			public List<GamesList> GetGameList()
			{
				XmlDocument doc = new XmlDocument ();
			doc.Load("http://thegamesdb.net/api/GetPlatformsList.php");//test location

			XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Data/Platforms");

			List<PlatformsList> platforms = new List<PlatformsList>();

				foreach (XmlNode node in nodes)
				{
				PlatformsList platform = new List<Platforms>();

				platform.PlatformId = node.SelectSingleNode("id").InnerText;
				platform.PlatformName = node.SelectSingleNode("name").InnerText;
				if (node.SelectSingleNode ("alias") != null) 
					{
					platform.PlatformAlias = node.SelectSingleNode ("alias").InnerText;
					}


				platforms.Add(platform);
				}
			return platforms;
			}

		}

	}
  
}

