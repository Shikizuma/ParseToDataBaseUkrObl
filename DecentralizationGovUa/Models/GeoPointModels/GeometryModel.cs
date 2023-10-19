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
        [JsonProperty("coordinates")]
        public dynamic Coordinates { get; set; }
    }
}
