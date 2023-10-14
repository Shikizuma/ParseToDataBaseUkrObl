using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models.GeoPointModels
{
    public class PointEntityModel
    {
        public Guid Id { get; set; }
        public List<double> Coordinates { get; set; }
        public int CommunId { get; set; }

        public void CreateInstance(List<List<List<double>>> Coordinates, int communId)
        {
            Id = Guid.NewGuid();
            this.Coordinates = Coordinates.SelectMany(x => x.SelectMany(y => y)).ToList(); ;
            this.CommunId = communId;
        }
    }

    
}
