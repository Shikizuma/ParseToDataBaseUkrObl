using DecentralizationGovUa.Models.GeoPointModels;
using DecentralizationGovUa.Models.VillageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Repositories
{
    public class GeoPointRepository : BaseRepository
    {
        string tableName = "GeoPoints";
       

        public async Task DeleteGeoPoints()
        {
            await DeleteData(tableName);
        }

        public async Task InsertDataForGeoPoints(IEnumerable<CoordinateModel> data)
        {
            string[] paramNames = new string[]
             { "@Id", "@Latitude", "@Longitude", "@CommunId"};

            await InsertData(tableName, data, paramNames);
        }

    
        public async Task<List<CoordinateModel>> SelectDataFromGeoPoints(int communId)
        {
            string[] selectParams = { "CommunId", "Latitude", "Longitude" };
            string whereParam = "CommunId = @CommunId";

            var result = await SelectData<CoordinateModel>(selectParams, tableName, whereParam, new { CommunId = communId });
            return result;
        }

        public async Task<Dictionary<int, List<List<double>>>> SelectAllDataPointsFromGeoPointsCommunites(List<int> communityIds)
        {
            var geoPointsByCommunity = new Dictionary<int, List<List<double>>>();

            foreach (var communityId in communityIds)
            {
                var geoPoints = await SelectDataFromGeoPoints(communityId);
                var geoPointList = new List<List<double>>();

                foreach (var geoPoint in geoPoints)
                {
                    geoPointList.Add(new List<double> { geoPoint.Latitude, geoPoint.Longitude });
                }

                geoPointsByCommunity[communityId] = geoPointList;
            }

            return geoPointsByCommunity;
        }
    }
}
