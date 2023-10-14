using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.CommunModels
{
    public class CommunInfoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("square")]
        public float Square { get; set; }
        [JsonProperty("council_size")]
        public int CouncilSize { get; set; }
        [JsonProperty("center")]
        public string Center { get; set; }
        [JsonProperty("koatuu")]
        public string Koatuu { get; set; }
        [JsonProperty("site")]
        public string? Site { get; set; }
        [JsonProperty("area_id")]
        public int AreaId { get; set; }
        [JsonProperty("region_id")]
        public int? DistrictId { get; set; }
    }
}
