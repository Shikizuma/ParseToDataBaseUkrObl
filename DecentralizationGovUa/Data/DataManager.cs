using DecentralizationGovUa.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data
{
    public class DataManager
    {
        private readonly RegionRepository regionRepository;
        private readonly DistrictRepository districtRepository;
        private readonly CommunityRepository communityRepository;
        private readonly VillageRepository villageRepository;
        private readonly GeoPointRepository geoPointRepository;

        public DataManager()
        {
            regionRepository = new RegionRepository();
            districtRepository = new DistrictRepository();
            communityRepository = new CommunityRepository();
            villageRepository = new VillageRepository();
            geoPointRepository = new GeoPointRepository();
        }

        public async Task DeleteAllData()
        {
            await geoPointRepository.DeleteGeoPoints();
            await villageRepository.DeleteVillages();
            await communityRepository.DeleteCommunities();
            await districtRepository.DeleteDistricts();
            await regionRepository.DeleteRegions();
        }

        public async Task InsertAllData()
        {
            await regionRepository.InsertDataForRegions();
            await communityRepository.InsertDataForCommunities();
            await districtRepository.InsertDataForDistricts();
            await geoPointRepository.InsertDataForGeoPoints();
            await villageRepository.InsertDataForVillages();                        
        }
    }
}
