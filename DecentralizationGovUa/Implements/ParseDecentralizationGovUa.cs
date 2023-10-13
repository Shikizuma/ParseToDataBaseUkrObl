using DecentralizationGovUa.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Implements
{
    public class ParseDecentralizationGovUa : IEnumerable<RegionInfoModel>, IEnumerator<RegionInfoModel>
    {
        private readonly string _url = "https://decentralization.gov.ua/graphql";

       

        public async Task<BaseResponse<RegionDataResponseModel>> Parse()
        {
            var baseResponse = new BaseResponse<RegionDataResponseModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var query = "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}";
                    var requestData = new { query };
                    Console.WriteLine(requestData);
                    var jsonRequest = JsonConvert.SerializeObject(requestData);
                    Console.WriteLine(jsonRequest);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    Console.WriteLine(content.Headers);

                    var response = await client.PostAsync(_url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(jsonResponse);

                    baseResponse.Data = JsonConvert.DeserializeObject<RegionDataResponseModel>(jsonResponse);
                }
            }
            catch (Exception ex)
            {

            }

            return baseResponse;
        }

        public RegionInfoModel Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<RegionInfoModel> GetEnumerator()
        {
            var result = Parse();
            result.Wait();
            var response = result.Result;
            if (response.Status == Enums.Status.Ok)
            {
                foreach (var region in response.Data.Data.Areas)
                {
                    yield return region;
                }
            }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
