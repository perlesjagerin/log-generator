using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW5.LogManipulators
{
    public class Validator
    {
        public void ValidateRandomLogs(string filepath, string configuration)
        {
            string[] configurationArray = configuration.Split(' ');
            using var reader = new StreamReader(filepath);
            using var writer = new StreamWriter(filepath + ".txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line,
                    $@"{RegexPattern.Date}|{RegexPattern.Request}|-|\b\S+\b");
                bool isLineValid = true;

                for (int i = 0; i < configurationArray.Length; i++)
                {
                    string pattern = GetPattern(configurationArray[i]);

                    if (!Regex.IsMatch(matches[i].Value, pattern))
                    {
                        isLineValid = false;
                    }
                }

                if (isLineValid)
                {
                    writer.WriteLine(line);
                }
            }
        }

        private string GetPattern(string element)
        {
            return element switch
            {
                "%h" => RegexPattern.IpAddress,
                "%l" => RegexPattern.ClientIdentity,
                "%u" => RegexPattern.UserId,
                "%t" => RegexPattern.Date,
                "%r" => RegexPattern.Request,
                "%s" => RegexPattern.StatusCode,
                "%b" => RegexPattern.Size,
                _ => throw new ArgumentException(),
            };
        }
    }
}
