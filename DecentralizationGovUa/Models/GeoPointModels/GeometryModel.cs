using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.GeoPointModels
{
    public class GeometryModel
    {
        public Guid Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public List<CoordinatesInfoModel> Coordinates { get; set; }
        public int CommunId { get; set; }
}
}
