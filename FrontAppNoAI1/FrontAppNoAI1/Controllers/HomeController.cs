using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace FrontAppNoAI1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _baseUri = new Uri(WebConfigurationManager.AppSettings["BackendUri"]);
        private static Uri _url = new Uri(_baseUri, "api/backstartup");

        public async Task<ActionResult> Index()
        {
            string result;
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = _url
                };
                var response = await _httpClient.SendAsync(request);
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result = "NG";
            }
            ViewBag.Result = result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}