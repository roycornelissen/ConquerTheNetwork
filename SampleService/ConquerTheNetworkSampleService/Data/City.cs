using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConquerTheNetworkSampleService.Data
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
