using DecentralizationGovUa.Data;
using DecentralizationGovUa.Implements;
using Dapper;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ParseDecentralizationGovUa parseDecentralizationGovUa = new ParseDecentralizationGovUa();
            using (var database = Context.Connection)
            {
                foreach (var region in parseDecentralizationGovUa)
                {
                    await database.ExecuteAsync(@"
                    INSERT INTO Regions 
                    VALUES 
                    (@Id, @Title, @Square, @Population, @LocalCommunityCount, @PercentCommunitiesFromArea, @SumCommunitiesSquare)", region);
                }
            }
     
        }
    }
}