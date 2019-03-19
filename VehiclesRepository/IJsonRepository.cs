namespace VehiclesRepository
{
    public interface IJsonRepository
    {
        string ReadFile();
        void WriteFile(string jsonData);
    }
}
