using System;
using System.Collections.Generic;
using System.IO;
using InnergyTask.DataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnergyTask.Tests
{
    [TestClass]
    public class ConsoleReaderTests 
    {
        private readonly string initData;
        private readonly int initDataRowsNumber;

        public ConsoleReaderTests()
        {
            initData = Resources.data;
            initDataRowsNumber = initData.Split(new[] {"\n"}, StringSplitOptions.None).Length;
        }

        [TestMethod]
        public void Test_CheckNumberOfReadRowsForNonEmptyFile()
        {
            //Arrange
            IReader consoleReader = new ConsoleReader();
            List<string> result;

            //Act
            using (var sr = new StringReader(initData))
            {
                Console.SetIn(sr);
                result = consoleReader.ReadAllLines(); 
            }

            //Asset
            Assert.AreEqual(initDataRowsNumber, result.Count);
        }

        [TestMethod]
        public void Test_CheckNumberOfReadRowsForEmptyFile()
        {
            //Arrange
            IReader consoleReader = new ConsoleReader();
            List<string> result;

            //Act
            using (var sr = new StringReader(String.Empty))
            {
                Console.SetIn(sr);
                result = consoleReader.ReadAllLines();
            }

            //Asset
            Assert.AreEqual(0, result.Count);
        }
    }
}