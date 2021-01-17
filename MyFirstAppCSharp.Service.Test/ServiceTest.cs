using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstAppCSharp.Service;
using System.Collections.Generic;
using System.Linq;

namespace MyFristAppCSharp.Service.Test
{
    [TestClass]
    public class ServiceTest
    {
        
        [TestMethod]
        public void TestCreation()
        {
            RestaurantService restSrv = new RestaurantService();

            var nbRestauAvant = restSrv.Get().Count();
            
                        
            var restauAAjouter = new MyFirstAppCSharp.Data.Model.Restaurant()
            {
                    Name = "restaurant op",
                    address = new MyFirstAppCSharp.Data.Model.Address() { street = "rue moine", zipcode = "38000" },
                    Description = "resturant cool",
                    EmailProprio = "email@gmail.com",
                    NumeroTel = "065131",
                    grades = new MyFirstAppCSharp.Data.Model.Grade {
                        Date=System.DateTime.Now, Commentaire="A", Note="10"
                    }
                };

            restSrv.Add(restauAAjouter);

            var nbRestauApres = restSrv.Get().Count();
            
            
            Assert.IsTrue(nbRestauAvant == nbRestauApres + 1);
        }
        


    }
}
