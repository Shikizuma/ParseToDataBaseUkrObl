using DecentralizationGovUa.Data;
using DecentralizationGovUa.Implements;
using Dapper;
using DecentralizationGovUa.Models;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var queries = new List<string>()
            {
                "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}",
                "{communities{title,id,population,square,council_size,district_size,center,koatuu,site,region_id,area_id}}",
                "{regions{title,area_id,id,population,square}}"
            };

            string tableName = "Regions";
            var regionData = await new ParseDecentralizationGovUa<RegionDataResponseModel>(queries[0]).Parse();
            await DeleteOldData(tableName);
            await InsertData(tableName, regionData.Data.Data.Areas, new string[]
                { "@Id", "@Title", "@Square", "@Population", "@LocalCommunityCount", "@PercentCommunitiesFromArea", "@SumCommunitiesSquare" });

            tableName = "Districts";
            var districtData = await new ParseDecentralizationGovUa<DistrictDataResponseModel>(queries[2]).Parse();
            await DeleteOldData(tableName);
            await InsertData(tableName, districtData.Data.Data.Districts, new string[]
                { "@Id", "@Title", "@Population", "@Square", "@AreaId" });

            tableName = "OTGs";
            var communData = await new ParseDecentralizationGovUa<CommunDataResponseModel>(queries[1]).Parse();
            await DeleteOldData(tableName);
            await InsertData(tableName, communData.Data.Data.CommunInfoModels, new string[]
                { "@Id", "@Title", "@Population", "@Square", "@CouncilSize", "@Center", "@Koatuu", "@Site", "@AreaId", "@DistrictId" });
        }

        static async Task DeleteOldData(string tableName)
        {
            using (var database = Context.Connection)
            {
                var query = $"Delete {tableName}";
                await database.ExecuteAsync(query);
            }
        }

        static async Task InsertData<T>(string tableName, IEnumerable<T> data, string[] paramsNames)
        {
            using (var database = Context.Connection)
            {
                var valuesPlaceholder = string.Join(", ", paramsNames);
                var query = $"INSERT INTO {tableName} VALUES ({valuesPlaceholder})";

                foreach (var item in data)
                {
                    await database.ExecuteAsync(query, item);
                }
            }
        }
    }
}
