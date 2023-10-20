using DecentralizationGovUa.Data;

namespace Test
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
           DataManager dataManager = new DataManager();
           await dataManager.DeleteAllData();
           await dataManager.InsertAllData();
        }
    }
}