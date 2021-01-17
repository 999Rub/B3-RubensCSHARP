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
    

   
}
