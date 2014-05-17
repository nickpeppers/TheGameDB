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

        public override string ToString()
        {
            return PlatformName;
        }
	}
}
