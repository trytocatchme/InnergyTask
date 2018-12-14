using InnergyTask.DataExtractors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InnergyTask.DataProcessors
{
    public abstract class StandardDataProcessor<T> where T : class
    {
        private readonly IDataExtractor<T> dataExtractor;

        protected StandardDataProcessor(IDataExtractor<T> dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }

        public virtual List<T> Process(IEnumerable<string> rows)
        {
            var processedItems = new List<T>();
            object sync = new object();

            Parallel.ForEach
            (
                rows,
                () => new List<T>(),
                (row, state, localProcessedItems) =>
                {
                    if (!string.IsNullOrEmpty(row) && row[0] != '#')
                        localProcessedItems.Add(dataExtractor.Extract(row));

                    return localProcessedItems;
                },
                (finalResult) =>
                {
                    lock (sync) processedItems.AddRange(finalResult);
                }
            );

            return processedItems;
        }
    }
}