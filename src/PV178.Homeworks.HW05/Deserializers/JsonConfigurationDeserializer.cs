using System;
using System.Collections.Generic;
using HW5.ApacheLogGenerator;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace HW5.Deserializers
{
    public class JsonConfigurationDeserializer : IConfigurationDeserializer
    {
        public IEnumerable<LogConfiguration> Deserialize(string inputFilePath)
        {
            var logConfigurations = new List<LogConfiguration>();
            string jsonContent = File.ReadAllText(inputFilePath);
            IEnumerable<JsonLogConfiguration> deserializedConfigs = JsonConvert
                .DeserializeObject<IEnumerable<JsonLogConfiguration>>(jsonContent);

            if (deserializedConfigs == null)
            {
                return logConfigurations;
            }

            foreach (JsonLogConfiguration config in deserializedConfigs)
            {
                bool areIpsValid = IPAddressValidator
                    .AreIpAddressesValid(config.IpAddresses);

                if (!areIpsValid)
                {
                    continue;
                }

                var logConfig = new LogConfiguration(
                    logLineFormat: config.Format.Split(' '),
                    ipAddressPool: config.IpAddresses,
                    userIdPool: config.UserIds,
                    outputFilePath: config.OutputFilePath
                    );

                logConfigurations.Add(logConfig);
            }

            return logConfigurations;
        }
    }
}
