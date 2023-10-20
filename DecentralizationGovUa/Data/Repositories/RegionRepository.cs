using DecentralizationGovUa.Models.DistrictModels;
using DecentralizationGovUa.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
{
    public class RegionRepository : BaseRepository
    {
        string tableName = "Regions";
        string[] paramNames = new string[]
          { "@Id", "@Title", "@Square", "@Population", "@LocalCommunityCount", "@PercentCommunitiesFromArea", "@SumCommunitiesSquare" };

        public async Task DeleteRegions()
        {
            await DeleteData(tableName);
        }

        public async Task InsertDataForRegions(IEnumerable<RegionInfoModel> data)
        {
            await InsertData(tableName, data, paramNames);
        }
    }
}
