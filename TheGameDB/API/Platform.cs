using System;
using System.Xml;

namespace TheGameDB
{
    public class Platform
    {
        public int ID { get; set; }
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
        //TODO: Need to do get images
    

	public Platform createGameFromXml(int id){

		String URLString = " http://thegamesdb.net/api/GetPlatform.php?id="+id;
		XmlTextReader reader = new XmlTextReader (URLString);
			Platform x = new Platform ();
		while (reader.Read()) 
		{
			switch (reader.NodeType) 
			{
			case XmlNodeType.Element: // The node is an element.
				Console.Write("<" + reader.Name);
				while (reader.MoveToNextAttribute()) // Read the attributes.
					Console.Write(" " + reader.Name + "='" + reader.Value + "'");
				Console.Write(">");
				Console.WriteLine(">");
				break;
			case XmlNodeType.Text: //Display the text in each element.
				Console.WriteLine (reader.Value);
				break;
			case XmlNodeType. EndElement: //Display the end of the element.
				Console.Write("</" + reader.Name);
				Console.WriteLine(">");
				break;



			}

}
			return x;
}
	}
}


