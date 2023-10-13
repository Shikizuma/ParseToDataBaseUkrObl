using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class CommunDataResponseModel
    {
        [JsonProperty("data")]
        public CommunResponseModel Data { get; set; }
    }
}
