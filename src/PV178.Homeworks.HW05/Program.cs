using System.IO;
using HW5.ApacheLogGenerator;
using HW5.Deserializers;
using HW5.Enums;
using HW5.LogManipulators;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConfigurationDeserializer jsonConfigurationDeserializer = new JsonConfigurationDeserializer();
            XmlConfigurationDeserializer xmlConfigurationDeserializer = new XmlConfigurationDeserializer();

            RandomItemAccess randomItemAccess = new RandomItemAccess();
            LogLineDirector logLineDirector = new LogLineDirector();

            string sourceFolder = Path.Combine("..", "..", "..");

            LogGenerator jsonConfigurationLogGenerator = new LogGenerator(jsonConfigurationDeserializer.Deserialize(Path.Combine(sourceFolder, "InputData", "LogConfiguration.json")), randomItemAccess, logLineDirector);
            jsonConfigurationLogGenerator.GenerateLog();

            LogGenerator xmlConfigurationLogGenerator = new LogGenerator(xmlConfigurationDeserializer.Deserialize(Path.Combine(sourceFolder, "InputData", "LogConfiguration.xml")), randomItemAccess, logLineDirector);
            xmlConfigurationLogGenerator.GenerateLog();

            string fileName = @Path.Combine(sourceFolder, "OutputData", "json_correctlog1.txt");
            Mutator mutator = new Mutator();
            mutator.HideDateByRandomDate(fileName);
            mutator.HideIpAddressByLocalhost(fileName);

            Analyzer analyzer = new Analyzer();
            analyzer.GetNumberOfClassStatusCodes(fileName, HttpStatusClass.ClientError);

            string sourceFolder2 = Path.Combine("..", "..", "..", "..", "PV178.Homeworks.HW05.Tests", "InputTestFiles");
            string wrongFileName = Path.Combine(sourceFolder2, "HundredLogFileWrongFormat.txt");
            string correctFileName = Path.Combine(sourceFolder2, "TenLogFile.txt");

            Validator validator = new Validator();
            validator.ValidateRandomLogs(fileName, "%h %l %u %t %r %s %b");
            validator.ValidateRandomLogs(wrongFileName, "%h %l %u %t %r %s %b");
            validator.ValidateRandomLogs(correctFileName, "%t %b %h %l %u %r %s");

        }
    }
}
