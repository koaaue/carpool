using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using Newtonsoft.Json;

namespace ToogleAPIDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string origin = "High Point Park, 6500 Alma Drive, Plano, TX  75023";
            string destination = "2014 Commerce St，Dallas, TX 75201";
            Console.WriteLine("origin: " + origin);
            Console.WriteLine("destination: " + destination);
            string time = "2016-02-12 08:40";
            DateTime myTime = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture).AddHours(6);
            TimeSpan span = (myTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            int timestamp = (int)span.TotalSeconds;
            GetMap(origin, destination, timestamp+"");
        }


        private static void GetMap(string origin, string destination, string timestamp)
        {
            string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + origin +
                "&destination=" + destination + "&departure_time="+timestamp+"&key=AIzaSyBO9khwJBKM4II1pxZT89ItprSLiYj9eho";
            var client = new WebClient();
           // Console.WriteLine(url);
            var result = client.DownloadData(url);
            
            var json = Encoding.UTF8.GetString(result);
            dynamic dynObj = JsonConvert.DeserializeObject(json);
            var res = dynObj.routes[0].legs[0];
            Console.WriteLine("distance: "+res.distance.text+ "  duration: "+res.duration.text + " duration in traffic: "+ res.duration_in_traffic.text);
        }
    }
}
