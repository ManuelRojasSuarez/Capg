using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using System.Web.Http;
using Mvc = Microsoft.AspNetCore.Mvc;
using BHBE.Models;
using System.Net;
using System.Linq;

namespace BHBE.Controllers
{
    [ApiController]
    [Mvc.Route("[controller]")]
    public class TrasationsController : ControllerBase
    {
        // GET: api/GetCustomers
        [Mvc.HttpGet(Name = "GetCustomers/{customerID}")]
        public Customers Get(int customerID)
        {
            if (!AllData.DataBase.Any(customer => customer.Id == customerID))
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest);
                res.Content = new StringContent("customerId = " + customerID + "it is wrong./n Try a valid one, please.");
                throw new HttpResponseException(res);
            }

            var customer = AllData.DataBase.First(customer => customer.Id == customerID);
            if (customer.Accounts is not null)
            {
                customer.Accounts.ForEach(account =>
                {
                    if ((account.Transactions is not null)  && (account.Transactions.Any()))
                    {
                        customer.Balance += account.Transactions.Select(transation => transation.Quantity).Sum();
                    }
                });
            }
            return customer;
        }
    }
}
