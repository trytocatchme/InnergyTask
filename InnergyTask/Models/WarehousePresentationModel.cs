using System.Collections.Generic;

namespace InnergyTask.Models
{
    public class WarehousePresentationModel
    {
        public string Id { get; set; }
        public int TotalAmount { get; set; }
        public List<MaterialPresentationModel> MaterialPresentationModel { get; set; }
    }
}