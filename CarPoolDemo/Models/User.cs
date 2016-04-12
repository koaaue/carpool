using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPoolDemo.Models
{
    public class User
    {
        private string uid { get; set; }
        private string fName { get; set; }
        private string lName { get; set; }
        private string email { get; set; }
        private string phone { get; set; }
        private string password { get; set; }

        public User() { }
        public User(String fName, String lName)
        {
            this.fName = fName;
            this.lName = lName;
        }
    }
}