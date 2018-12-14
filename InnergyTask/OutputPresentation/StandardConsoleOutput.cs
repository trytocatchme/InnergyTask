using System;
using System.Collections.Generic;
using System.Linq;
using InnergyTask.Models;

namespace InnergyTask.OutputPresentation
{
    public class StandardConsoleOutput : IPresentable
    {
        private readonly List<WarehousePresentationModel> warehousePresentationModelList = new List<WarehousePresentationModel>();

        public void Display(IEnumerable<Material> materials)
        {
            if (materials == null)
                return;
            
            PreparePresentationForm(materials);
            Print();
        }
        
        private void Print()
        {
            foreach (var warehouse in GetGroupedByTotalItems().OrderByDescending(o => o.Key))
            {
                if (warehouse.Value.Count > 1)
                {
                    foreach (var material in warehouse.Value.OrderByDescending(o => o.Id))
                    {
                        PrintTotalRow(material.Id, material.TotalAmount);

                        foreach (var item in material.MaterialPresentationModel.OrderBy(o => o.Name))
                            PrintMaterialAmountRow(item.Name, item.Amount);
                        
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
                else
                {
                    PrintTotalRow(warehouse.Value[0].Id, warehouse.Value[0].TotalAmount);

                    foreach (var material in warehouse.Value[0].MaterialPresentationModel.OrderBy(o => o.Name))
                        PrintMaterialAmountRow(material.Name, material.Amount);
                    
                    Console.WriteLine();
                }
            }
        }

        private void PrintTotalRow(string id, int amount) => Console.WriteLine($"{id} (total {amount})");

        private void PrintMaterialAmountRow(string name, int amount) => Console.WriteLine($"{name}: {amount}");
        
        private Dictionary<int, List<WarehousePresentationModel>> GetGroupedByTotalItems()
        {
            var warehousePresentationList = new Dictionary<int, List<WarehousePresentationModel>>();

            foreach (var item in warehousePresentationModelList)
            {
                if (warehousePresentationList.ContainsKey(item.TotalAmount))
                    warehousePresentationList[item.TotalAmount].Add(item);
                else
                    warehousePresentationList[item.TotalAmount] = new List<WarehousePresentationModel>() { item };
            }

            return warehousePresentationList;
        }

        private void PreparePresentationForm(IEnumerable<Material> materials)
        {
            foreach (var material in materials)
            {
                foreach (var warehouse in material.Warehouse)
                {
                    var element = warehousePresentationModelList.SingleOrDefault(s => s.Id == warehouse.Name);

                    if (element != null)
                        HandleExistingElement(element, warehouse, material);
                    else
                        HandleNewElement(warehouse, material);
                }
            }
        }

        private void HandleNewElement(Warehouse warehouse, Material material)
        {
            var element = new WarehousePresentationModel
            {
                Id = warehouse.Name,
                TotalAmount = warehouse.Amount,
                MaterialPresentationModel = new List<MaterialPresentationModel>()
                {
                    new MaterialPresentationModel()
                    {
                        Name = material.Id,
                        Amount = warehouse.Amount
                    }
                }
            };

            warehousePresentationModelList.Add(element);
        }

        private void HandleExistingElement(WarehousePresentationModel warehousePresentationModel, Warehouse warehouse, Material material)
        {
            warehousePresentationModel.TotalAmount += warehouse.Amount;
            warehousePresentationModel.MaterialPresentationModel.Add(new MaterialPresentationModel()
            {
                Name = material.Id,
                Amount = warehouse.Amount
            });
        }
    }
}