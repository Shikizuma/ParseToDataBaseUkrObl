using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.DistrictModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
{
    public class DistrictRepository : BaseRepository
    {
        public async Task InsertDataForDistricts(IEnumerable<DistrictInfoModel> data)
        {
            string tableName = "Districts";
            string[] paramNames = new string[]
             { "@Id", "@Title", "@Population", "@Square", "@AreaId" };

            try
            {
                await InsertData(tableName, data, paramNames);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
