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
        private string _url;
        private string _query;

        public ParseDecentralizationGovUa(string query, string url)
        {
            _query = query;
            _url = url;
        }

        public async Task<BaseResponse<T>> Parse(HttpMethod httpMethod)
        {
            var baseResponse = new BaseResponse<T>();
             
            try
            {              
                using (HttpClient client = new HttpClient())
                {
                    if (httpMethod == HttpMethod.Post)
                    {
                        var requestData = new { query = _query };
                        var jsonRequest = JsonConvert.SerializeObject(requestData);
                        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(_url, content);
                        await HandleResponse(response, baseResponse);
                    }
                    else if (httpMethod == HttpMethod.Get)
                    {
                        var response = await client.GetAsync(_url);
                        await HandleResponse(response, baseResponse);
                    }
                
                    /*if (!response.IsSuccessStatusCode)
                    //{
                    //    throw new Exception(response.ReasonPhrase);
                    //}
                    //string jsonResponse = await response.Content.ReadAsStringAsync();
                    //baseResponse.Data = JsonConvert.DeserializeObject<T>(jsonResponse);*/
                }
            }
            catch (Exception ex)
            {
            }

            return baseResponse;
        }
        private async Task HandleResponse(HttpResponseMessage response, BaseResponse<T> baseResponse)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            baseResponse.Data = JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
