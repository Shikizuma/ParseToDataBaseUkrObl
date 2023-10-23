using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.DistrictModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Repositories
{
    public class DistrictRepository : BaseRepository
    {
        string tableName = "Districts";
        string[] paramNames = new string[]
         { "@Id", "@Title", "@Population", "@Square", "@AreaId" };

        public async Task DeleteDistricts()
        {
            await DeleteData(tableName);
        }

        public async Task InsertDataForDistricts(IEnumerable<DistrictInfoModel> data)
        {
            await InsertData(tableName, data, paramNames);
        }
    }
}
