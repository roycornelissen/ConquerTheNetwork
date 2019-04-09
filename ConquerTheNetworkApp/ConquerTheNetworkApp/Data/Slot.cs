using System;
using Newtonsoft.Json;

namespace ConquerTheNetworkApp.Data
{
    public class Slot
    {
        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public string DayFormatted => StartTime.Date.ToString("D");

        [JsonIgnore]
        public string StartTimeFormatted => StartTime.ToString("HH:mm");

        [JsonIgnore]
        public string EndTimeFormatted => StartTime.Add(Duration).ToString("HH:mm");
    }
}
