using FrontApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontApp1.Controllers
{
    public class FrontExceptionController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _url = new Uri("https://backapp1-da3q.azurewebsites.net/api/backexception");

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
        public async Task<ActionResult> Index(int type)
        {
            if (type == 123)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = _url
                };
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                Response.StatusCode = 404;
                ViewBag.Message = "404 Error";
                return View();
            }
            else
            {
                this._exception.TestMethod1();
                return View();
            }
        }
    }
}