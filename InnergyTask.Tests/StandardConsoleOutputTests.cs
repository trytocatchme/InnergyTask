using System;
using System.Collections.Generic;
using System.IO;
using InnergyTask.Models;
using InnergyTask.OutputPresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnergyTask.Tests
{
    [TestClass]
    public class StandardConsoleOutputTests
    {
        private readonly IPresentable standardConsoleOutput;

        public StandardConsoleOutputTests()
        {
            standardConsoleOutput = new StandardConsoleOutput();
        }


        [TestMethod]
        public void Test_CheckIfWarhousesWereDisplayedCorrectlyForTwoMaterials()
        {
            //Arrange
            string expectedResult = Resources.expectedResultForStandardConsoleOutput_2material_2warehouses;
            string result;

            List<Material> materials = new List<Material>()
            {
                new Material()
                {
                    Id = "m1", Name = "material1", Warehouse = new List<Warehouse>()
                    {
                        new Warehouse(){ Name = "warhouse1", Amount = 10},
                        new Warehouse(){ Name = "warhouse2", Amount = 20},
                    }
                },
                new Material()
                {
                    Id = "m2", Name = "material2", Warehouse = new List<Warehouse>()
                    {
                        new Warehouse(){ Name = "warhouse1", Amount = 2},
                        new Warehouse(){ Name = "warhouse2", Amount = 3},
                    }
                }
            };

            //Act     
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                standardConsoleOutput.Display(materials);
                result = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_CheckIfWarehousesWereDisplayedCorrectlyForMaterialsWithTheSameAmount()
        {
            //Arrange
            string expectedResult = Resources.expectedResultForStandardConsoleOuput_2WarhouseWithTheSameAmount_CheckOrder;
            string result;

            List<Material> materials = new List<Material>()
            {
                new Material()
                {
                    Id = "m1", Name = "material1", Warehouse = new List<Warehouse>()
                    {
                        new Warehouse(){ Name = "warhouse1", Amount = 2},
                        new Warehouse(){ Name = "warhouse2", Amount = 20},
                    }
                },
                new Material()
                {
                    Id = "m2", Name = "material2", Warehouse = new List<Warehouse>()
                    {
                        new Warehouse(){ Name = "warhouse3", Amount = 2},
                        new Warehouse(){ Name = "warhouse3", Amount = 3},
                    }
                },
                new Material()
                {
                    Id = "m3", Name = "material3", Warehouse = new List<Warehouse>()
                    {
                        new Warehouse(){ Name = "warhouse1", Amount = 3},
                        new Warehouse(){ Name = "warhouse2", Amount = 1},
                    }
                }
            };

            //Act     
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                standardConsoleOutput.Display(materials);
                result = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}