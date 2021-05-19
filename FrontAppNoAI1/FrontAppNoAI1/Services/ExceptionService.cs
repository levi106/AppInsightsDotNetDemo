using System;

namespace FrontAppNoAI1.Services
{
    public class ExceptionService : IExceptionService
    {
        public void TestMethod1()
        {
            throw new ArgumentNullException("argument1");
        }
    }
}