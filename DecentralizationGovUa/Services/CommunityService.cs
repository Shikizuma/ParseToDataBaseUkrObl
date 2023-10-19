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

            ParseDecentralizationGovUa<CommunDataResponseModel> parseDecentralizationGovUa = new(query);

            var regionData = await parseDecentralizationGovUa.Parse();

            return regionData.Data.Data.Communs;
        }
    }
}
