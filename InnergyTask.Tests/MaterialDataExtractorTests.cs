using System;
using InnergyTask.DataExtractors;
using InnergyTask.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnergyTask.Tests
{
    [TestClass]
    public class MaterialDataExtractorTests
    {
        private const string Row = "Maple Dovetail Drawerbox;COM-124047;WH-A,15";
        private const string RowWithMultipleWarehouses = "Hdw Accuride CB0115-CASSRC - Locking Handle Kit - Black;CB0115-CASSRC;WH-C,10|WH-B,5|WH-C,3";

        private readonly IDataExtractor<Material> materialDataExtractor;

        public MaterialDataExtractorTests()
        {
            materialDataExtractor = new MaterialDataExtractor();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A string data of empty was inappropriately allowed.")]
        public void Test_CheckIfArgumentNullExceptionOccurWhenStringDataIsEmpty()
        {
            //Act
            materialDataExtractor.Extract("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A string data of null was inappropriately allowed.")]
        public void Test_CheckIfArgumentNullExceptionOccurWhenStringDataIsNull()
        {
            //Act
            materialDataExtractor.Extract(null);
        }

        [TestMethod]
        public void Test_CheckIfWarehouseAmountWasExtractedCorrectlyForRowWithMultipleWarehouses()
        {
            //Arrange
            var expected = 3;

            //Act
            var material = materialDataExtractor.Extract(RowWithMultipleWarehouses);

            //Assert
            Assert.AreEqual(expected, material.Warehouse.Count);
        }

        [TestMethod]
        public void Test_CheckIfMaterialIdWasExtractedCorrectly()
        {
            //Arrange
            var expected = "COM-124047";

            //Act
            var material = materialDataExtractor.Extract(Row);

            //Assert
            Assert.AreEqual(expected, material.Id);
        }

        [TestMethod]
        public void Test_CheckIfMaterialNameWasExtractedCorrectly()
        {
            //Arrange
            var expected = "Maple Dovetail Drawerbox";

            //Act
            var material = materialDataExtractor.Extract(Row);

            //Assert
            Assert.AreEqual(expected, material.Name);
        }

        [TestMethod]
        public void Test_CheckIfWarehouseNameWasExtractedCorrectly()
        {
            //Arrange
            var expected = "WH-A";

            //Act
            var material = materialDataExtractor.Extract(Row);

            //Assert
            Assert.AreEqual(expected, material.Warehouse[0].Name);
        }


        [TestMethod]
        public void Test_CheckIfWarehouseAmountWasExtractedCorrectly()
        {
            //Arrange
            var expected = 15;

            //Act
            var material = materialDataExtractor.Extract(Row);

            //Assert
            Assert.AreEqual(expected, material.Warehouse[0].Amount);
        }
    }
}