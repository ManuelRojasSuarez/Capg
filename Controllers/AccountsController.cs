using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using BHBE.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Web.Http;
using Mvc = Microsoft.AspNetCore.Mvc;

namespace BHBE.Controllers
{
    [ApiController]
    [Mvc.Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        // POST api/PostAccount
        [Mvc.HttpPost(Name = "PostAccount/{customerID,initialCredit}")]
        public void Post(int customerID, double initialCredit)
        {
            if (!AllData.DataBase.Any(customer => customer.Id == customerID))
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest);
                res.Content = new StringContent("customerId = " + customerID + "it is wrong./n Try a valid one, please.");
                throw new HttpResponseException(res);
            }
            var customer = AllData.DataBase.First(customer => customer.Id == customerID);
            Accounts newAccount = new Accounts();
            newAccount.Transactions = new List<Transactions>();

            if (initialCredit != 0.0)
            {
                var newTransition = new Transactions() { Date = DateTime.Now, Quantity = initialCredit };
                newAccount.Transactions.Add(newTransition);
            }

            if (customer.Accounts is null)
            {
                customer.Accounts = new List<Accounts>();
            }
            customer.Accounts.Add(newAccount);
        }
    }
}
