using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerTheNetworkSampleService.Data
{
    public class Slot
    {
        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string Title { get; set; }

    }
}
