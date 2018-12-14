using System;
using System.Collections.Generic;
using InnergyTask.Models;

namespace InnergyTask.DataExtractors
{
    public class MaterialDataExtractor : IDataExtractor<Material>
    {
        private const int MaterialIdIndex = 0;
        private const int MaterialNameIndex = 1;
        private const int MaterialWarhousesIndex = 2;

        private const int WarhouseNameIndex = 0;
        private const int WarhouseAmountIndex = 1;
        
        public Material Extract(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            var material = data.Split(';');
            
            return new Material()
            {
                Name = material[MaterialIdIndex],
                Id = material[MaterialNameIndex],
                Warehouse = ExtractWarehouses(material)
            };
        }

        private List<Warehouse> ExtractWarehouses(string[] material)
        {
            var warehouseList = new List<Warehouse>();

            foreach (var item in material[MaterialWarhousesIndex].Split('|'))
            {
                var warhouse = item.Split(',');

                warehouseList.Add(new Warehouse()
                {
                    Name = warhouse[WarhouseNameIndex],
                    Amount = int.Parse(warhouse[WarhouseAmountIndex]),
                });
            }

            return warehouseList;
        }
    }
}