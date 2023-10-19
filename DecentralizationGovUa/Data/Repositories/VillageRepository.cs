using DecentralizationGovUa.Models.DistrictModels;
using DecentralizationGovUa.Models.VillageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
{
    public class VillageRepository : BaseRepository
    {
        public async Task InsertDataForRegions(IEnumerable<VillageInfoModel> data)
        {
            string tableName = "Villages";
            string[] paramNames = new string[]
              { "@Id", "@Title", "@Category", "@CommunId"};

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
