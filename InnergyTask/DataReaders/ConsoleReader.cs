using System;
using System.Collections.Generic;

namespace InnergyTask.DataReaders
{
    public class ConsoleReader : IReader
    {
        public List<string> ReadAllLines()
        {
            var rows = new List<string>();
            string line;

            while ((line = Console.ReadLine()) != null && line != string.Empty)
            {
                rows.Add(line);
            }

            return rows;
        }
    }
}