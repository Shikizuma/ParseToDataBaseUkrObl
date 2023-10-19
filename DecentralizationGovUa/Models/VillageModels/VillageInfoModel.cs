using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.VillageModels
{
    public class VillageInfoModel
    {
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        public int CommunId { get; set; }

        public VillageInfoModel(string title, string category, int communId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Category = category;
            CommunId = communId;
        }
    }
}
