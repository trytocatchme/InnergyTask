using System.Collections.Generic;

namespace InnergyTask.DataReaders
{
    public interface IReader
    {
        List<string> ReadAllLines();
    }
}