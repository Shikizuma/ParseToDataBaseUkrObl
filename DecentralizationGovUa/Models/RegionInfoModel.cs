using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class RegionInfoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("square")]
        public float Square { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("local_community_count")]
        public int LocalCommunityCount { get; set; }
        [JsonProperty("percent_communities_from_area")]
        public float? PercentCommunitiesFromArea { get; set; }
        [JsonProperty("sum_communities_square")]
        public float? SumCommunitiesSquare { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                $"title: {Title}\n";
        }
    }
}
