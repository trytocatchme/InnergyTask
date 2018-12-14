using InnergyTask.DataExtractors;
using InnergyTask.Models;

namespace InnergyTask.DataProcessors
{
    public class MaterialDataProcessor : StandardDataProcessor<Material>
    {
        public MaterialDataProcessor(IDataExtractor<Material> dataExtractor)
            : base(dataExtractor)
        {
        }
    }
}