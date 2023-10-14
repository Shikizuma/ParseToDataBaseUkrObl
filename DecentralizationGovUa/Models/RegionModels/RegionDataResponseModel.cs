using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DecentralizationGovUa.Models.RegionModels
{
    public class RegionDataResponseModel
    {
        [JsonProperty("data")]
        public RegionAreaResponseModel Data { get; set; }
    }
}
