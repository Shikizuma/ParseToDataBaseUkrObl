using DecentralizationGovUa.Models.GeoPointModels;
using DecentralizationGovUa.Models;
using DecentralizationGovUa.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Implements
{
    public class GetParseDecentralizationGovUa<T>
    {
        string URL = "https://decentralization.gov.ua/api/v1/communities/";

        public GetParseDecentralizationGovUa(string url)
        {
            URL += url;
        }

        public async Task<BaseResponse<T>> GetParse()
        {
            var baseResponse = new BaseResponse<T>();
            try
            {
                using (var client = new HttpClient())
                {                      
                    var response = await client.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    baseResponse.Data = JsonConvert.DeserializeObject<T>(json)!;

                    if (baseResponse.Data == null)
                    {
                        throw new Exception("Error Deserialize");
                    }                                                
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
