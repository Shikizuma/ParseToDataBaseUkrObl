﻿using DecentralizationGovUa.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Implements
{
    public class PostParseDecentralizationGovUa<T>
    {
        private string _url = "https://decentralization.gov.ua/graphql";
        private string _query;

        public PostParseDecentralizationGovUa(string query)
        {
            _query = query;
        }

        public async Task<BaseResponse<T>> PostParse()
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
                    await HandleResponse(response, baseResponse);                               
                }
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Status = Enums.Status.Error;
            }

            return baseResponse;
        }
        private async Task HandleResponse(HttpResponseMessage response, BaseResponse<T> baseResponse)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            baseResponse.Data = JsonConvert.DeserializeObject<T>(jsonResponse);

            if (baseResponse.Data == null)
            {
                throw new Exception("Error Deserialize");
            }
        }
    }
}
