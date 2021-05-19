using System;
using System.Web.Http;

namespace BackApp1.Controllers
{
    public class BackExceptionController : ApiController
    {
        public string Get()
        {
            throw new ArgumentNullException("argument2");
        }
    }
}
