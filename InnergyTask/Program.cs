using InnergyTask.DataExtractors;
using InnergyTask.DataProcessors;
using InnergyTask.DataReaders;
using InnergyTask.Models;
using InnergyTask.OutputPresentation;

namespace InnergyTask
{
    public class Program
    {
        public static void Main()
        {
            IReader consoleDataReader = new ConsoleReader();
            var rows = consoleDataReader.ReadAllLines();

            IDataExtractor<Material> materialDataExtractor = new MaterialDataExtractor();
            var materialDataProcessor = new MaterialDataProcessor(materialDataExtractor);
            var processedRows = materialDataProcessor.Process(rows);

            IPresentable standardConsoleOutput = new StandardConsoleOutput();
            standardConsoleOutput.Display(processedRows);
        }
    }
}