using FrontAppNoAI1.Services;
using System.Web.Mvc;

namespace FrontAppNoAI1.Controllers
{
    public class FrontExceptionController : Controller
    {
        private IExceptionService _exception;

        public FrontExceptionController(IExceptionService exception)
        {
            this._exception = exception;
        }

        // GET: Exception
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int type)
        {
            this._exception.TestMethod1();
            return View();
        }
    }
}
