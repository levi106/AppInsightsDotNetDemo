using Microsoft.ApplicationInsights;
using System.Web.Http;

namespace BackApp1.Controllers
{
    public class BackStartupController : ApiController
    {
        static private readonly TelemetryClient _client = new TelemetryClient();

        public string Get()
        {
            return "OK";
        }
    }
}
