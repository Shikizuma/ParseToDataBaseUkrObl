using DecentralizationGovUa.Data;
using DecentralizationGovUa.Implements;
using Dapper;
using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.RegionModels;
using DecentralizationGovUa.Models.DistrictModels;
using DecentralizationGovUa.Models.VillageModels;
using DecentralizationGovUa.Models.GeoPointModels;
using System.Collections.Generic;

namespace ParseToDataBaseUkrObl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var urlPost = "https://decentralization.gov.ua/graphql";

            var queries = new List<string>
            {
                "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}",
                "{communities{title,id,population,square,council_size,district_size,center,koatuu,site,region_id,area_id}}",
                "{regions{title,area_id,id,population,square}}",
            };

            var tables = new List<string> 
            { 
                "Districts", "OTGs", "Regions", "Villages", "GeoPoints"
            };

            await DeleteOldData(tables[3]);
            await DeleteOldData(tables[1]);
            await DeleteOldData(tables[0]);
            await DeleteOldData(tables[2]);

            var regionData = await new ParseDecentralizationGovUa<RegionDataResponseModel>(queries[0], urlPost).Parse(HttpMethod.Post);
            await InsertData(tables[2], regionData.Data.Data.Areas, new string[]
                { "@Id", "@Title", "@Square", "@Population", "@LocalCommunityCount", "@PercentCommunitiesFromArea", "@SumCommunitiesSquare" });

            var districtData = await new ParseDecentralizationGovUa<DistrictDataResponseModel>(queries[2], urlPost).Parse(HttpMethod.Post);
            await InsertData(tables[0], districtData.Data.Data.Districts, new string[]
                { "@Id", "@Title", "@Population", "@Square", "@AreaId" });

            var communData = await new ParseDecentralizationGovUa<CommunDataResponseModel>(queries[1], urlPost).Parse(HttpMethod.Post);
            await InsertData(tables[1], communData.Data.Data.CommunInfoModels, new string[]
                { "@Id", "@Title", "@Population", "@Square", "@CouncilSize", "@Center", "@Koatuu", "@Site", "@AreaId", "@DistrictId" });

            List<int> communsDataId = communData.Data.Data.CommunInfoModels.Select(commun => commun.Id).ToList();
            foreach (var communId in communsDataId)
            {
                var villageQuery = "{community(id:\"" + communId + "\"){villages{title, category}}}";
                var villageData = await new ParseDecentralizationGovUa<VillageCommunDataResponseModel>(villageQuery, urlPost).Parse(HttpMethod.Post);
                await InsertData(tables[3], villageData.Data.Data.Community.Villages, new string[]
                { "@Id", "@Title", "@Category", "@CommunId"}, communId);
            }
            //foreach (var communId in communsDataId)
            //{
            //    var urlGet = "https://decentralization.gov.ua/api/v1/communities/" + communId + "/geo_json";
            //    var pointData = await new ParseDecentralizationGovUa<GeoDataModel>("", urlGet).Parse(HttpMethod.Get);
            //    await InsertData(tables[4], pointData.Data.Geometry.Coordinates, new string[]
            //    { "@Id", "@GeoCoordinates", "@CommunId"}, communId);
            //}
        }

        static async Task DeleteOldData(string tableName)
        {
            using (var database = Context.Connection)
            {
                var query = $"Delete {tableName}";
                await database.ExecuteAsync(query);
            }
        }

        static async Task InsertData<T>(string tableName, IEnumerable<T> data, string[] paramsNames, int numOfCommun = 0)
        {
            using (var database = Context.Connection)
            {
                var valuesPlaceholder = string.Join(", ", paramsNames);
                var query = $"INSERT INTO {tableName} VALUES ({valuesPlaceholder})";

                foreach (var item in data)
                {
                    if(item is VillageInfoModel village)
                    {
                        var villageCopy = new VillageInfoModel
                        {
                            Id = Guid.NewGuid(),
                            Title = village.Title,
                            Category = village.Category,
                            CommunId = numOfCommun
                        };
                        Console.WriteLine(villageCopy.CommunId);
                        await database.ExecuteAsync(query, villageCopy);
                    }
                    //else if(item is  List<List<List<double>>>coordinate)
                    //{
                    //    PointEntityModel pointEntity = new PointEntityModel();
                    //    pointEntity.CreateInstance(coordinate, numOfCommun);
                    //    await database.ExecuteAsync(query, pointEntity);                
                    //}
                    else
                    {
                       await database.ExecuteAsync(query, item);          
                    }
                   
                }
            }
        }
    }
}
