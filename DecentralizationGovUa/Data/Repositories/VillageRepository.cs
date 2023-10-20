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
        string tableName = "Villages";
        string[] paramNames = new string[]
          { "@Id", "@Title", "@Category", "@CommunId"};

        public async Task DeleteVillages()
        {
            await DeleteData(tableName);
        }

        public async Task InsertDataForVillages(IEnumerable<VillageInfoModel> data)
        {           
            await InsertData(tableName, data, paramNames);
        }
    }
}
