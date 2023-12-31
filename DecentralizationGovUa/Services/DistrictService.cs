﻿using DecentralizationGovUa.Implements;
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

            PostParseDecentralizationGovUa<DistrictDataResponseModel> parseDecentralizationGovUa = new(query);

            var districtData = await parseDecentralizationGovUa.PostParse();

            return districtData.Data.Data.Districts;
        }
    }
}
