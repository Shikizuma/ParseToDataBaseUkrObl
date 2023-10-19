using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.CommunModels
{
    public class CommunResponseModel
    {
        [JsonProperty("communities")]
        public List<CommunInfoModel> Communs { get; set; }
    }
}
