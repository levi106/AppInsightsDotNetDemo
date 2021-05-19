using FrontApp1.Services;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontApp1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly TelemetryClient _client = new TelemetryClient();
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _url = new Uri("https://backapp1-da3q.azurewebsites.net/api/backstartup");
        private IPerformanceService _perf;

        public HomeController(IPerformanceService perf)
        {
            this._perf = perf;
        }

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
                _client.TrackException(ex);
                result = "NG";
            }
            ViewBag.Result = result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            _perf.CpuStress(3, 10);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}