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

        public async Task<Dictionary<int, List<List<double>>>> SelectAllGeoPointsFromCommunities()
        {
            return await new GeoPointRepository().SelectAllDataPointsFromGeoPointsCommunites(communsDataId);
        }

    }
}
