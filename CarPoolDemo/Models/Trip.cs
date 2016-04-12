using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPoolDemo.Models
{
    public class Trip
    {
        private User user { get; set; }
        private Location origin { get; set; }
        private Location destination { get; set; }
        private DateTime departureTime { get; set; }
        private float travelDistance { get; set; }
        private int travelTime { get; set; }

        public Trip() { }
        public Trip(Location from, Location to, DateTime departureTime)
        {
            this.origin = from;
            this.destination = to;
            this.departureTime = departureTime;
        }

        public void getTripInfo()
        {
            // Connect to google server to get travelDistance and travelTime
        }
    }

}