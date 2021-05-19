using BackApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackApp1.Controllers
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
