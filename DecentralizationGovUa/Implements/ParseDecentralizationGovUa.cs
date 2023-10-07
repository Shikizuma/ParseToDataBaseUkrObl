using DecentralizationGovUa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Implements
{
    public class ParseDecentralizationGovUa
    {
        private readonly string _url = "decentralization.gov.ua/graphql?query={areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}"
        public async Task<BaseResponse<RegionResponseModel>> Parse()
        {
            var baseResponse = new BaseResponse<RegionResponseModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var responce = await client.GetAsync(_url);

                    if (!responce.IsSuccessStatusCode)
                    {
                        throw new Exception(responce.IsSuccessStatusCode.ToString());
                    }

                    string json = await responce.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

            }

            return baseResponse;
        }
    }
}
