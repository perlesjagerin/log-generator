using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HW5.Enums;

namespace HW5.LogManipulators
{
    public class Analyzer
    {
        public uint GetNumberOfClassStatusCodes(string filepath,
            HttpStatusClass statusClass)
        {
            string pattern = RegexPattern.GetStatusCode(statusClass);
            uint count = 0;

            using var reader = new StreamReader(filepath);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (Regex.IsMatch(line, pattern))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
