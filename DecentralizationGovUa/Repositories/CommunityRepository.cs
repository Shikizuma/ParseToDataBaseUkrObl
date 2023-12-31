﻿using DecentralizationGovUa.Models.CommunModels;
using DecentralizationGovUa.Models.GeoPointModels;
using DecentralizationGovUa.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Repositories
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

        public async Task<List<int>> SelectAllIdFromCommunities()
        {
            string[] selectParams = { "Id" };

            var result = await SelectData<int>(selectParams, tableName);
            return result;
        }
    }
}
