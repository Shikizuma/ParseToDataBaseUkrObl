using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class VillageCommunCommunityResponseModel
    {
        [JsonProperty("id")]
        public int CommunityId { get; set; }
        [JsonProperty("villages")]
        public List<VillageInfoModel> Villages { get; set; }
    }
}
