using System;
using System.Linq;
using InnergyTask.DataExtractors;
using InnergyTask.DataProcessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnergyTask.Tests
{
    [TestClass]
    public class StandardDataProcessorTests
    {
        private readonly string initData;
        private readonly MaterialDataProcessor materialDataProcessor;

        public StandardDataProcessorTests()
        {
            initData = Resources.data;
            var materialDataExtractor = new MaterialDataExtractor();
            materialDataProcessor = new MaterialDataProcessor(materialDataExtractor);
        }
        
        [TestMethod]
        public void Test_CheckNumberOfReadRowsForNonEmptyFile()
        {
            //Arrange
            var rows = initData.Split(new[] { "\n" }, StringSplitOptions.None);
            int numberOfRowsWithoutTheComments = rows.Count(s => s.First() != '#');
       
            ////Act
            var result = materialDataProcessor.Process(rows);
            
            ////Asset
            Assert.AreEqual(numberOfRowsWithoutTheComments, result.Count);
        }
    }
}