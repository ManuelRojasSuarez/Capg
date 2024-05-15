using BHBE.Models;
using System.Collections;
using System.Xml.Linq;
namespace BHBE.Controllers
{
    public class AllData
    {
        public static List<Customers> DataBase = new List<Customers>()
        {
            new Customers() {Id=1,Name="Sam", Surname="Brown",Accounts= new List<Accounts>() },
            new Customers() {Id=2,Name="Pavlo", Surname="Bavgayev",Accounts= null },
            new Customers() {Id=3,Name="Xin", Surname="Yang",Accounts= null },
        };

        //public Data()
        //{
        //    List<Customers> DataBase = new List<Customers>();
        //    var cust = new Customers() {CustomerID=1,Name="Sam", Surname="Brown",Accounts=null };
        //    cust.Name = "jjj";

        //    DataBase.Add(new Customers());
        //}
    }
}
