using DecentralizationGovUa.Implements;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ParseDecentralizationGovUa parseDecentralizationGovUa = new ParseDecentralizationGovUa();
            foreach (var region in parseDecentralizationGovUa)
            {
                Console.WriteLine(region);
            }
        }
    }
}