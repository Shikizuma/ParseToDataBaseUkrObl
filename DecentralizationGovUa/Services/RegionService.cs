using DecentralizationGovUa.Implements;
using DecentralizationGovUa.Models;
using DecentralizationGovUa.Models.RegionModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Services
{
    public class RegionService
    {
        public async Task<List<RegionInfoModel>> GetRegions()
        {
            string query = "{areas{title,id,square,population,local_community_count,percent_communities_from_area,sum_communities_square}}";

            PostParseDecentralizationGovUa<RegionDataResponseModel> parseDecentralizationGovUa = new(query);

            var regionData = await parseDecentralizationGovUa.PostParse();

            return regionData.Data.Data.Areas;
        }  
    }
}
