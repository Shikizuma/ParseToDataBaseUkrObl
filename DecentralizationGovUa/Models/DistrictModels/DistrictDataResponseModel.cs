using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.DistrictModels
{
    public class DistrictDataResponseModel
    {
        [JsonProperty("data")]
        public DistrictResponseModel Data { get; set; }
    }
}
