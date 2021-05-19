using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontApp1.Services
{
    public class ExceptionService : IExceptionService
    {
        public void TestMethod1()
        {
            throw new ArgumentNullException("argument1");
        }
    }
}