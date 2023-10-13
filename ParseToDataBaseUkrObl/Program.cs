using DecentralizationGovUa.Data;
using DecentralizationGovUa.Implements;
using Dapper;
using DecentralizationGovUa.Models;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        //    static async Task Main(string[] args)
        //    {
        //        var query = new List<string>()
        //        {
        //            "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}",
        //            "{communities{title,id,population,square,council_size,district_size,center,koatuu, site, region_id, area_id}}",
        //            "{regions{title, area_id,id,population,square}}"
        //        };
        //        //ParseDecentralizationGovUa<RegionDataResponseModel> parseRegionsDecentralizationGovUa = new(query[0]);
        //        //var regionResponseData = await parseRegionsDecentralizationGovUa.Parse();

        //        //using (var database = Context.Connection)
        //        //{
        //        //    foreach (var region in regionResponseData.Data.Data.Areas)
        //        //    {
        //        //        await database.ExecuteAsync(@"
        //        //        INSERT INTO Regions 
        //        //        VALUES 
        //        //        (@Id, @Title, @Square, @Population, @LocalCommunityCount, @PercentCommunitiesFromArea, @SumCommunitiesSquare)", region);
        //        //    }
        //        //}

        //        //ParseDecentralizationGovUa<DistrictDataResponseModel> parseDistrictsDecentralizationGovUa = new(query[2]);
        //        //var districtResponseData = await parseDistrictsDecentralizationGovUa.Parse();
        //        //using (var database = Context.Connection)
        //        //{
        //        //    foreach (var district in districtResponseData.Data.Data.Districts)
        //        //    {
        //        //        await database.ExecuteAsync(@"
        //        //        INSERT INTO Districts 
        //        //        VALUES 
        //        //        (@Id, @Title, @Population, @Square, @AreaId)", district);
        //        //    }
        //        //}

        //        ParseDecentralizationGovUa<CommunDataResponseModel> parseCommunsDecentralizationGovUa = new(query[1]);
        //        var coomunResponseData = await parseCommunsDecentralizationGovUa.Parse();
        //        using (var database = Context.Connection)
        //        {
        //            foreach (var commun in coomunResponseData.Data.Data.CommunInfoModels)
        //            {
        //                await database.ExecuteAsync(@"
        //                INSERT INTO OTGs 
        //                VALUES 
        //                (@Id, @Title, @Population, @Square,  @CouncilSize, @DistrictSize, @Center, @Koatuu, @Site, @AreaId, @DistrictId)", commun);
        //            }
        //        }
        //    }
        //}

        static async Task Main(string[] args)
        {
            var queries = new List<string>()
            {
                "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}",
                "{communities{title,id,population,square,council_size,district_size,center,koatuu,site,region_id,area_id}}",
                "{regions{title,area_id,id,population,square}}"
            };

            //var regionData = await new ParseDecentralizationGovUa<RegionDataResponseModel>(queries[0]).Parse();
            //await InsertData("Regions", regionData.Data.Data.Areas, new string[]
            //    { "@Id", "@Title", "@Square", "@Population", "@LocalCommunityCount", "@PercentCommunitiesFromArea", "@SumCommunitiesSquare" });

            var districtData = await new ParseDecentralizationGovUa<DistrictDataResponseModel>(queries[2]).Parse();
            Console.WriteLine();
            //await InsertData("Districts", districtData.Data.Data.Districts, new string[]
            //    { "@Id", "@Title", "@Population", "@Square", "@AreaId" });

            //var communData = await new ParseDecentralizationGovUa<CommunDataResponseModel>(queries[1]).Parse();
            //await InsertData("OTGs", communData.Data.Data.CommunInfoModels, new string[]
            //    { "@Id", "@Title", "@Population", "@Square", "@CouncilSize", "@DistrictSize", "@Center", "@Koatuu", "@Site", "@AreaId", "@DistrictId" });
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
