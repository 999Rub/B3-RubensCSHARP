using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstAppCSharp.Data.Model
{
   public class Grade
    {
        public int ID { get; set; }
        public string Note { get; set; }
        public string Commentaire { get; set; }
        public long DateLastVisite { get; set; }
    }
}
