using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;


namespace CarPoolDemo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult check(string from, string to, string time)
        {
            string origin = from;
            string destination = to;
            //Console.WriteLine("origin: " + origin);
            //Console.WriteLine("destination: " + destination);
            
            
            ViewBag.Message = GetMap(from, to, time);
            ViewBag.from = from;
            ViewBag.to = to;
            ViewBag.time = time;
            return View();
        }


        private static string GetMap(string origin, string destination, string time)
        {
            DateTime myTime = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm",
            System.Globalization.CultureInfo.InvariantCulture).AddHours(6);
            TimeSpan span = (myTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            int timestamp = (int)span.TotalSeconds;
            int current = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            if (current > timestamp)
            {
                return "this is past time. plz use future time";
                //return;
            }

            string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + origin +
                "&destination=" + destination + "&departure_time=" + timestamp + "&key=AIzaSyBO9khwJBKM4II1pxZT89ItprSLiYj9eho";
            var client = new WebClient();
            var result = client.DownloadData(url);

            var json = Encoding.UTF8.GetString(result);
            dynamic dynObj = JsonConvert.DeserializeObject(json);
            var res = dynObj.routes[0].legs[0];
            string s="Distance: " + res.distance.text + "             Duration: " + res.duration.text + "             Duration in traffic: " + res.duration_in_traffic.text;
            return s;
        }


    }
}