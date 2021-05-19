using BackAppNoAI1.Models;
using System.Linq;
using System.Web.Http;

namespace BackAppNoAI1.Controllers
{
    public class BackDbController : ApiController
    {
        static private readonly SalesLTDataContext _db = new SalesLTDataContext();

        public Customer Get(int id)
        {
            var customers = from p in _db.Customers
                            where p.CustomerID == id
                            select p;
            var customer = customers.FirstOrDefault();
            return customer;
        }
    }
}
