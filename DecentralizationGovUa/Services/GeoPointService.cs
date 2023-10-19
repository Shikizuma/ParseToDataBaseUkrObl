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
        public async Task GetGeoPointsCommunites(int id)
        {
            using (var client = new HttpClient())
            {
                string url = $"{URL}/{id}/geo_json";
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var geomerty = JsonConvert.DeserializeObject<GeoDataModel>(json);
            }
        }
    }
}
