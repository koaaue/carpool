using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPoolDemo.Models
{
    public class Location
    {
        private string state { get; set; }
        private string city { get; set; }
        private string street { get; set; }
        private string result { get; set; }

        public Location() { }
        public Location(string state, string city, string street)
        {
            this.state = state;
            this.city = city;
            this.street = street;
        }
        public Location(String result)
        {
            this.result = result;
        }

        public override string ToString()
        {
            if (result == null)
                return street + ", " + city + ", " + state;
            else
                return result;
        }

    }
}