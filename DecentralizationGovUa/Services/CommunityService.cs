using DecentralizationGovUa.Implements;
using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Services
{
    public class CommunityService
    {
        public async Task<List<CommunInfoModel>> GetCommunities()
        {
            string query = "{communities{title,id,population,square,council_size,district_size,center,koatuu,site,region_id,area_id}}";

            PostParseDecentralizationGovUa<CommunDataResponseModel> parseDecentralizationGovUa = new(query);

            var communData = await parseDecentralizationGovUa.PostParse();

            return communData.Data.Data.Communs;
        }

        public List<int> GetCommunitiesId() 
        {
            List<CommunInfoModel> communs = GetCommunities().Result;
            return communs.Select(commun => commun.Id).ToList();
        }
    }
}
