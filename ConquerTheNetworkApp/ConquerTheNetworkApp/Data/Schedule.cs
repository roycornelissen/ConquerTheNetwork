using System.Collections.Generic;

namespace ConquerTheNetworkApp.Data
{
    public class Schedule
    {
        public string CityId { get; set; }

        public IEnumerable<Slot> Slots { get; set; }
    }
}
