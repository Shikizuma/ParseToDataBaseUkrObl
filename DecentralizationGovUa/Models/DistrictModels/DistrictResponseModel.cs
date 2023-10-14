using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.DistrictModels
{
    public class DistrictResponseModel
    {
        [JsonProperty("regions")]
        public List<DistrictInfoModel> Districts { get; set; }
    }
}
