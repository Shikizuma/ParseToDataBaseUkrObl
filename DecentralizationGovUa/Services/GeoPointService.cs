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
        const string URL = "https://decentralization.gov.ua/api/v1/communities/";
        public async Task<BaseResponse<List<CoordinateModel>>> GetGeoPointsCommunites(int id)
        {
            var baseResponse = new BaseResponse<List<CoordinateModel>>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{URL}/{id}/geo_json";
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var geomerty = JsonConvert.DeserializeObject<GeoDataModel>(json);
                    if (geomerty == null)
                    {
                        throw new Exception("Error Deserialize");
                    }
                    var coordinates = new List<CoordinateModel>();
                    foreach (var point in geomerty.Geometry.Coordinates[0])
                    {
                        coordinates.Add(new CoordinateModel
                        {
                            Longitude = point[0],
                            Latitude = point[1]
                        });
                    }

                    baseResponse.Data = coordinates;
                }
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Status = Enums.Status.Error;
            }
            return baseResponse;
        }
    }
}
