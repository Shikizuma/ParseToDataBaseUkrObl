using DecentralizationGovUa.Implements;
using DecentralizationGovUa.Models.DistrictModels;
using DecentralizationGovUa.Models.VillageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Services
{
    public class VillageService
    {
        public async Task<List<VillageInfoModel>> GetVillages()
        {
            List<int> communsDataId = new CommunityService().GetCommunitiesId().Result;

            var villageData = new List<VillageInfoModel>();
            foreach (var communId in communsDataId)
            {
                string query = "{community(id:\"" + communId + "\"){villages{title, category}}}";

                PostParseDecentralizationGovUa<VillageCommunDataResponseModel> parseDecentralizationGovUa = new(query);

                var villageDataResponse = await parseDecentralizationGovUa.PostParse();

                foreach (var villageDataItem in villageDataResponse.Data.Data.Community.Villages)
                {
                    var village = new VillageInfoModel(villageDataItem.Title, villageDataItem.Category, communId);
                    villageData.Add(village);
                }
            }

            return villageData;
        }
    }
}
