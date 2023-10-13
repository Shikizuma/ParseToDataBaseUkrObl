using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class DistrictInfoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("population")]
        public float Population { get; set; }
        [JsonProperty("square")]
        public float? Square { get; set; }
        [JsonProperty("area_id")]
        public int AreaId { get; set; }
    }
}
