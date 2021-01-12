using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstAppCSharp.Web.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
       // public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
       // public List<Grade> grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }
    }
    public class Address
    {

        public int ID { get; set; }
        public string building { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
    }

    public class Grade
    {

        public int ID { get; set; }
        public long date { get; set; }
        public string grade { get; set; }
        public int score { get; set; }


    }

}
