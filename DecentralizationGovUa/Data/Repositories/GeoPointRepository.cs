using DecentralizationGovUa.Models.GeoPointModels;
using DecentralizationGovUa.Models.VillageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
{
    public class GeoPointRepository : BaseRepository
    {
        string tableName = "GeoPoints";
        string[] paramNames = new string[]
          { "@Id", "@Latitude", "@Longitude", "@CommunId"};

        public async Task DeleteGeoPoints()
        {
            await DeleteData(tableName);
        }

        public async Task InsertDataForGeoPoints(IEnumerable<CoordinateModel> data)
        {
            await InsertData(tableName, data, paramNames);
        }
    }
}
