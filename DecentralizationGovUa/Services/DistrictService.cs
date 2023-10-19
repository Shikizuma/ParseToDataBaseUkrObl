using DecentralizationGovUa.Implements;
using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.DistrictModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Services
{
    public class DistrictService
    {
        public async Task<List<DistrictInfoModel>> GetDistricts()
        {
            string query = "{regions{title,area_id,id,population,square}}";

            ParseDecentralizationGovUa<DistrictDataResponseModel> parseDecentralizationGovUa = new(query);

            var regionData = await parseDecentralizationGovUa.Parse();

            return regionData.Data.Data.Districts;
        }
    }
}
