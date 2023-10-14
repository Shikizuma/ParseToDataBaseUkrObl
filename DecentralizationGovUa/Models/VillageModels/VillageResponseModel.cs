using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.VillageModels
{
    public class VillageResponseModel
    {
        [JsonProperty("villages")]
        public List<VillageInfoModel> Villages { get; set; }
    }
}
