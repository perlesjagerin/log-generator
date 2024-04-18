using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HW5.ApacheLogGenerator;
using System.Net;

namespace HW5.Deserializers
{
    public class XmlConfigurationDeserializer : IConfigurationDeserializer
    {
        public IEnumerable<LogConfiguration> Deserialize(string inputFilePath)
        {
            var configurations = new List<LogConfiguration>();
            XDocument doc = XDocument.Load(inputFilePath);
            IEnumerable<XElement> elements = doc.Descendants("Configuration");

            foreach (XElement element in elements)
            {
                List<string> ipAddresses = element.Element("IPAddresses")
                    .Elements("IPAddress")
                    .Select(ipAddress => ipAddress.Value)
                    .ToList();

                bool areIpsValid = IPAddressValidator
                    .AreIpAddressesValid(ipAddresses);

                if (!areIpsValid)
                {
                    continue;
                }

                List<string> userIds = element.Element("UserIds")
                    .Elements("UserId")
                    .Select(userId => userId.Value)
                    .ToList();

                string outputFilePath = element.Attribute("output_filepath").Value;
                string[] format = element.Element("Format").Value.Split(' ');

                var config = new LogConfiguration(
                    format, ipAddresses, userIds, outputFilePath);

                configurations.Add(config);
            }

            return configurations;
        }
    }
}
