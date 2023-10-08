using DecentralizationGovUa.Implements;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ParseDecentralizationGovUa parseDecentralizationGovUa = new ParseDecentralizationGovUa();
            var response = await parseDecentralizationGovUa.Parse();
        }
    }
}