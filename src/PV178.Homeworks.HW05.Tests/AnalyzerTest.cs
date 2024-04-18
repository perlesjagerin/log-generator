using System;
using System.IO;
using HW5.Enums;
using HW5.LogManipulators;
using Xunit;

namespace HW5.Tests
{
    public class AnalyzerTest
    {
        [Fact]
        public void Test_GetNumberOfClassStatusCodes_OnEmptyFile()
        {
            //Arrange
            var sourceFolder = Path.Combine("..", "..", "..");
            string testedFilePath = TestFiles.CreateTempFile(Path.Combine(sourceFolder, "InputTestFiles", "emptyfile.txt"));
            HttpStatusClass testedStatusClass = HttpStatusClass.Successful;
            Analyzer analyzer = new Analyzer();
            uint expectedNumberOfClassStatusCodes = 0;

            //Act
            uint resultNumberOfClassStatusCodes =
                analyzer.GetNumberOfClassStatusCodes(testedFilePath, testedStatusClass);

            //Assert
            Assert.Equal(expectedNumberOfClassStatusCodes, resultNumberOfClassStatusCodes);
        }

        [Fact]
        public void Test_GetNumberOfClassStatusCodes_ForServerErrorClass()
        {
            //Arrange
            var sourceFolder = Path.Combine("..", "..", "..");
            string testedFilePath = TestFiles.CreateTempFile(Path.Combine(sourceFolder, "InputTestFiles", "HundredLogFile.txt"));
            HttpStatusClass testedStatusClass = HttpStatusClass.ClientError;
            Analyzer analyzer = new Analyzer();
            uint expectedNumberOfClassStatusCodes = 31;

            //Act
            uint resultNumberOfClassStatusCodes =
                analyzer.GetNumberOfClassStatusCodes(testedFilePath, testedStatusClass);

            //Assert
            Assert.Equal(expectedNumberOfClassStatusCodes, resultNumberOfClassStatusCodes);
        }
    }
}
