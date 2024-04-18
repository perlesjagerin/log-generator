using System;
using System.Collections.Generic;

namespace HW5.Deserializers
{
	public class JsonLogConfiguration
	{
		public string OutputFilePath { get; set; }
        public string Format { get; set; }
        public IList<string> IpAddresses { get; set; }
        public IList<string> UserIds { get; set; }
	}
}

