using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.RegionModels
{
    public class RegionAreaResponseModel
    {
        [JsonProperty("areas")]
        public List<RegionInfoModel> Areas { get; set; }
    }
}
