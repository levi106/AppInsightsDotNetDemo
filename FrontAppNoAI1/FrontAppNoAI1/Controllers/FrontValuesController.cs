using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace FrontAppNoAI1.Controllers
{
    public class FrontValuesController : ApiController
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _baseUri = new Uri(WebConfigurationManager.AppSettings["BackendUri"]);
        private static Uri _url = new Uri(_baseUri, "api/backvalues");

        public async Task<string> Get()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _url
            };
            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> Post([FromBody]string message)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent("\"" + message + "\"", Encoding.UTF8, "application/json"),
                RequestUri = _url
            };
            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
