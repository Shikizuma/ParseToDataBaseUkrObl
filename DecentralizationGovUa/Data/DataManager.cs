using DecentralizationGovUa.Repositories;
using DecentralizationGovUa.Services;
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

        private readonly RegionService regionService;
        private readonly CommunityService communityService;
        private readonly DistrictService districtService;
        private readonly VillageService villageService;
        private readonly GeoPointService geoPointService;

        public DataManager()
        {
            regionRepository = new RegionRepository();
            districtRepository = new DistrictRepository();
            communityRepository = new CommunityRepository();
            villageRepository = new VillageRepository();
            geoPointRepository = new GeoPointRepository();

            regionService = new RegionService();
            communityService = new CommunityService();
            districtService = new DistrictService();
            villageService = new VillageService();
            geoPointService = new GeoPointService();
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
            await regionRepository.InsertDataForRegions(regionService.GetRegions().Result);
            await districtRepository.InsertDataForDistricts(districtService.GetDistricts().Result);
            await communityRepository.InsertDataForCommunities(communityService.GetCommunities().Result);
            await geoPointRepository.InsertDataForGeoPoints(geoPointService.GetAllGeoPointsCommunities().Result);
            await villageRepository.InsertDataForVillages(villageService.GetVillages().Result);                        
        }
    }
}
