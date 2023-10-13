using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    internal class CommunInfoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Population { get; set; }
        public float Square { get; set; }
        public int CouncilSize { get; set; }
        public int DistrictSize { get; set; }
        public string Center { get; set; }
        public string Koatuu { get; set; }
        public string Site { get; set; }
        public int AreaId { get; set; }
        public int RegionId { get; set; }
        public List<> GeoPoints { get; set; }
    }
}
