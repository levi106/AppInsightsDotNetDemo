using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace FrontAppNoAI1.Controllers
{
    public class FrontDelayController : ApiController
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _baseUri = new Uri(WebConfigurationManager.AppSettings["BackendUri"]);
        private static Uri _url = new Uri(_baseUri, "api/backdelay");

        public async Task<string> Get(int id)
        {
            var builder = new UriBuilder(_url);
            builder.Path += $"/{id}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = builder.Uri
            };
            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
