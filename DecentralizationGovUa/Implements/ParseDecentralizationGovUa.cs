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
    public class ParseDecentralizationGovUa : IEnumerable<RegionDataModel>, IEnumerator<RegionDataModel>
    {
        private readonly string _url = "https://decentralization.gov.ua/graphql";

       

        public async Task<BaseResponse<DataResponseModel>> Parse()
        {
            var baseResponse = new BaseResponse<DataResponseModel>();

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

                    baseResponse.Data = JsonConvert.DeserializeObject<DataResponseModel>(jsonResponse);
                }
            }
            catch (Exception ex)
            {

            }

            return baseResponse;
        }

        public RegionDataModel Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<RegionDataModel> GetEnumerator()
        {
            throw new NotImplementedException();
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
