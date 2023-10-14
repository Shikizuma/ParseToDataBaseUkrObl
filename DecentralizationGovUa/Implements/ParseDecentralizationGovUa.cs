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
    public class ParseDecentralizationGovUa<T>
    {
        private readonly string _url = "https://decentralization.gov.ua/graphql";
        private string _query;

        public ParseDecentralizationGovUa(string query)
        {
            _query = query;
        }

        public async Task<BaseResponse<T>> Parse()
        {
            var baseResponse = new BaseResponse<T>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestData = new { query = _query };
                    var jsonRequest = JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    baseResponse.Data = JsonConvert.DeserializeObject<T>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
            }

            return baseResponse;
        }
    }
}
