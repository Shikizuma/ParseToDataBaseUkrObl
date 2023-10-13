using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class DistrictInfoModel
    {
        public int DistrictId { get; set; }
        public string Title { get; set;}
        public int Population { get; set; }
        public float? Square { get; set; }
        public int AreaId { get; set; }
    }
}
