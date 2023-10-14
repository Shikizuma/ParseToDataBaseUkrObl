using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.VillageModels
{
    public class VillageCommunCommunityResponseModel
    {
        [JsonProperty("community")]
        public VillageResponseModel Community { get; set; }
    }
}
