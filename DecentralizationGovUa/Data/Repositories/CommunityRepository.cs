using DecentralizationGovUa.Models.CommunModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
{
    public class CommunityRepository : BaseRepository
    {
        string tableName = "OTGs";
        string[] paramNames = new string[]
        { "@Id", "@Title", "@Population", "@Square", "@CouncilSize", "@Center", "@Koatuu", "@Site", "@AreaId", "@DistrictId" };

        public async Task DeleteCommunities()
        {        
            await DeleteData(tableName);
        }

        public async Task InsertDataForCommunities(IEnumerable<CommunInfoModel> data)
        {
            await InsertData(tableName, data, paramNames);        
        }
    }
}
