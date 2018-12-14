namespace InnergyTask.DataExtractors
{
    public interface IDataExtractor<T> where T : class
    {
        T Extract(string data);
    }
}