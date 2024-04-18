using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW5.LogManipulators
{
    public class Mutator
    {
        public void HideDateByRandomDate(string filepath)
        {
            ProcessFile(filepath, RegexPattern.Date, GetRandomDate);
        }

        public void HideIpAddressByLocalhost(string filepath)
        {
            ProcessFile(filepath, RegexPattern.IpAddress, random => "127.0.0.1");
        }

        private void ProcessFile(string filepath, string pattern,
            Func<Random, string> replacementGenerator)
        {
            string tempFilePath = filepath + ".tmp";
            using var reader = new StreamReader(filepath);
            using var writer = new StreamWriter(tempFilePath);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var random = new Random();
                string replacedLine =
                    Regex.Replace(line, pattern, replacementGenerator(random));
                writer.WriteLine(replacedLine);
            }

            File.Delete(filepath);
            File.Move(tempFilePath, filepath);
        }

        private string GetRandomDate(Random random)
        {
            int year = random.Next(1970, 2019);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            int hour = random.Next(0, 24);
            int minute = random.Next(0, 60);
            int second = random.Next(0, 60);

            var randomDate = new DateTime(
                year, month, day, hour, minute, second);

            return randomDate.ToString("dd/MM/yyyy:HH:mm:ss +0100");
        }
    }
}
