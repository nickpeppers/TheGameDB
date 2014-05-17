using System;
using System.Xml;

namespace TheGameDB
{
	public class Game
	{
        public string baseImgUrl = "http://thegamesdb.net/banners/";
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
	}
}

