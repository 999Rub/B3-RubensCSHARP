using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstAppCSharp.Data.Model
{
    public class Restaurant
    {
        public int ID { get; set; }
        public Address address { get; set; }
        public string EmailProprio { get; set; }
        public string NumeroTel { get; set; }
        public List<Grade> grades { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Address
    {

        public int ID { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
        public string City { get; set; }
    }

    public class Grade
    {

        public int ID { get; set; }
        public string Note { get; set; }
        public string Commentaire { get; set; }
        public long DateLastVisite { get; set; }



    }
}
