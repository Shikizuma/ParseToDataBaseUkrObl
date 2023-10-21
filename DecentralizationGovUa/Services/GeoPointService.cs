using DecentralizationGovUa.Data.Repositories;
using DecentralizationGovUa.Implements;
using DecentralizationGovUa.Models;
using DecentralizationGovUa.Models.GeoPointModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DecentralizationGovUa.Services
{
    public class GeoPointService
    {
        private readonly List<int> communsDataId;

        public GeoPointService()
        {
            communsDataId = new CommunityService().GetCommunitiesId().Result;
        }

        public async Task<List<CoordinateModel>> GetAllGeoPointsCommunities()
        {
            var coordinates = new List<CoordinateModel>();
            foreach (var communityId in communsDataId)
            {
                string url = $"{communityId}/geo_json";
                GetParseDecentralizationGovUa<GeoDataModel> getParseDecentralizationGovUa = new(url);
                var geoData = await getParseDecentralizationGovUa.GetParse();

                if (geoData.Data.Geometry != null)
                {
                    foreach (var point in geoData.Data.Geometry.Coordinates[0])
                    {
                        coordinates.Add(new CoordinateModel
                        {
                            Id = Guid.NewGuid(),
                            Longitude = point[0],
                            Latitude = point[1],
                            CommunId = communityId
                        });
                    }
                }
            }
            return coordinates;
        }

        public async Task<List<CoordinateModel>> SelectGeoPointsFromCommunity()
        {
            return await new GeoPointRepository().SelectDataFromGeoPoints(4076);
        }

        public async Task<dynamic> SelectAllGeoPointsFromCommunities()
        {
            Dictionary<int, List<List<double>>> data = await new GeoPointRepository().SelectAllDataPointsFromGeoPointsCommunites(communsDataId);

            var transformedData = data.Select(pair =>
            new
            {
                Id = pair.Key,
                Coordinates = pair.Value.Select(coord => new { Lat = coord[0], Lng = coord[1] }).ToList()
            }).ToList();

            return transformedData;
        }


    }
}
