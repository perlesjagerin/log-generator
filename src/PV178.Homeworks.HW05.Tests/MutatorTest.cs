using System;
using System.IO;
using HW5.Enums;
using HW5.LogManipulators;
using Xunit;

namespace HW5.Tests
{
    public class MutatorTest
    {

        [Fact]
        public void Test_HideIpAddressByLocalhost_ForHundredLines()
        {
            //Arrange
            var sourceFolder = Path.Combine("..", "..", "..");
            string testedFilePath = TestFiles.CreateTempFile(Path.Combine(sourceFolder, "InputTestFiles", "HundredLogFileIpAddress.txt"));
            string expectedFilePath = Path.Combine(sourceFolder, "ExpectedTestFiles", "HundredLogFileIpAddress.txt");
            Mutator mutator = new Mutator();

            //Act
            mutator.HideIpAddressByLocalhost(testedFilePath);

            //Assert
            bool areFilesEqual = TestFiles.AreFilesEqual(expectedFilePath, testedFilePath, out string message);
            Assert.True(areFilesEqual, $"Expected file and current result file are not the same. {message}");
        }
    }
}
