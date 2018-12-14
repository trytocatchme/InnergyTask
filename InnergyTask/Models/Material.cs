using System.Collections.Generic;

namespace InnergyTask.Models
{
    public class Material
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<Warehouse> Warehouse { get; set; }
    }
}