using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConquerTheNetworkSampleService.Data
{
    public class MockDatabase
    {
        static MockDatabase()
        {
            Cities = new List<City>
            {
                new City { Id = "1", Latitude = 30.267153, Longitude = -97.7430608, Name = "Austin", Logo = "/Images/austin.png"  },
                new City { Id = "2", Latitude = 42.3584300, Longitude = -71.0597700, Name = "Boston", Logo = "/Images/boston.png"  },
                new City { Id = "3", Latitude = 36.1749700, Longitude = -115.1372200, Name = "Las Vegas", Logo = "/Images/lasvegas.png"  },
                new City { Id = "4", Latitude = 28.5383400, Longitude = -81.3792400, Name = "Orlando", Logo = "/Images/orlando.png"  },
                new City { Id = "5", Latitude = 47.6739900, Longitude = -122.1215100, Name = "Redmond", Logo = "/Images/redmond.png"  },
                new City { Id = "6", Latitude = 38.8951100, Longitude = -77.0363700, Name = "Washington DC", Logo = "/Images/washingtonDC.png"  }
            };

            Schedules = new List<Schedule>
            {
                // Austin
                new Schedule { CityId = "1", Slots = new List<Slot>
                {
                    new Slot { Duration = TimeSpan.FromHours(4), StartTime = new DateTime(2016, 5, 16, 9, 0, 0), Title = "Pre-Conference Workshops" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 5, 16, 13, 0, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromHours(4), StartTime = new DateTime(2016, 5, 16, 14, 0, 0), Title = "Pre-Conference Workshops Continue" },
                    new Slot { Duration = TimeSpan.FromHours(2), StartTime = new DateTime(2016, 5, 16, 19, 0, 0), Title = "Dine-A-Round Dinner" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 5, 17, 8, 0, 0), Title = "Opening Keynote" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 9, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 10, 45, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(90), StartTime = new DateTime(2016, 5, 17, 12, 0, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 13, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 15, 00, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 16, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 17, 17, 45, 0), Title = "Welcome Reception" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 5, 18, 8, 0, 0), Title = "General Session" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 18, 9, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 18, 10, 45, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(90), StartTime = new DateTime(2016, 5, 18, 12, 0, 0), Title = "Birds Of A Feather Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 18, 13, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 18, 15, 00, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 18, 16, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromHours(2), StartTime = new DateTime(2016, 5, 18, 19, 00, 0), Title = "Rollin' On The River Bat Cruise" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 19, 8, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 19, 9, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 19, 11, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 5, 19, 12, 15, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 19, 13, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 5, 19, 13, 45, 0), Title = "Breakout Sessions" },
                }},
                // Las Vegas
                new Schedule { CityId = "3", Slots = new List<Slot>
                {
                    new Slot { Duration = TimeSpan.FromHours(4), StartTime = new DateTime(2016, 3, 7, 9, 0, 0), Title = "Pre-Conference Workshops" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 3, 7, 13, 0, 0), Title = "Lunch @ Le Village Buffet, Paris Las Vegas" },
                    new Slot { Duration = TimeSpan.FromHours(4), StartTime = new DateTime(2016, 3, 7, 14, 0, 0), Title = "Pre-Conference Workshops Continue" },
                    new Slot { Duration = TimeSpan.FromHours(2), StartTime = new DateTime(2016, 3, 7, 19, 0, 0), Title = "Dine-A-Round Dinner" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 3, 8, 8, 0, 0), Title = "Opening Keynote" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 8, 9, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 8, 10, 45, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(60), StartTime = new DateTime(2016, 3, 8, 12, 0, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(30), StartTime = new DateTime(2016, 3, 8, 13, 0, 0), Title = "Dessert Break - Visit Exhibitors" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 8, 13, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 8, 15, 00, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 8, 16, 15, 0), Title = "Welcome Reception" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 3, 9, 8, 0, 0), Title = "General Session" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 9, 9, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 9, 10, 45, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(90), StartTime = new DateTime(2016, 3, 9, 12, 0, 0), Title = "Birds Of A Feather Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 9, 13, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 9, 15, 00, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 9, 16, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromHours(2), StartTime = new DateTime(2016, 3, 9, 19, 00, 0), Title = "Rollin' On The River Bat Cruise" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 10, 8, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 10, 9, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 10, 11, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 3, 10, 12, 15, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 10, 13, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 10, 13, 45, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 11, 8, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 11, 9, 30, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 11, 11, 0, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromHours(1), StartTime = new DateTime(2016, 3, 11, 12, 15, 0), Title = "Lunch" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 11, 13, 15, 0), Title = "Breakout Sessions" },
                    new Slot { Duration = TimeSpan.FromMinutes(75), StartTime = new DateTime(2016, 3, 11, 13, 45, 0), Title = "Breakout Sessions" },
                }},
            };
        }

        public static IEnumerable<City> Cities { get; set; }

        public static IEnumerable<Schedule> Schedules { get; set; } 
    }
}
