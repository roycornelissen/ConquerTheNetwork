using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerTheNetworkSampleService.Data
{
    public class Schedule
    {
        public string CityId { get; set; }

        public IEnumerable<Slot> Slots { get; set; } 
    }
}
