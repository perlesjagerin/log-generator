using System;
using System.IO;
using HW5.LogManipulators;
using Xunit;

namespace HW5.Tests
{
    public class ValidatorTest
    {
        [Fact]
        public void Test_ValidateRandomLogs_FourWrongLogLines()
        {
            //Arrange
            var sourceFolder = Path.Combine("..", "..", "..");
            string testedFilePath = TestFiles.CreateTempFile(Path.Combine(sourceFolder, "InputTestFiles", "HundredLogFileWrongFormat"));
            string expectedFilePath = Path.Combine(sourceFolder, "ExpectedTestFiles", "HundredLogFileWrongFormat");
            Validator validator = new Validator();
            string configuration = "%h %l %u %t %r %s %b";

            //Act
            validator.ValidateRandomLogs(testedFilePath, configuration);

            //Assert
            bool areFilesEqual = TestFiles.AreFilesEqual(expectedFilePath, testedFilePath, out string message);
            Assert.True(areFilesEqual, $"Expected file and current result file are not the same. {message}");
        }

        [Fact]
        public void Test_ValidateRandomLogs_CorrectFile()
        {
            //Arrange
            var sourceFolder = Path.Combine("..", "..", "..");
            string testedFilePath = TestFiles.CreateTempFile(Path.Combine(sourceFolder, "InputTestFiles", "TenLogFile"));
            string expectedFilePath = Path.Combine(sourceFolder, "ExpectedTestFiles", "TenLogFile");
            Validator validator = new Validator();
            string configuration = "%t %b %h %l %u %r %s";

            //Act
            validator.ValidateRandomLogs(testedFilePath, configuration);

            //Assert
            bool areFilesEqual = TestFiles.AreFilesEqual(expectedFilePath, testedFilePath, out string message);
            Assert.True(areFilesEqual, $"Expected file and current result file are not the same. {message}");
        }
    }
}
