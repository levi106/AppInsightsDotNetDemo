using Microsoft.ApplicationInsights;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FrontApp1.Controllers
{
    public class FrontValuesController : ApiController
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _url = new Uri("https://backapp1-da3q.azurewebsites.net/api/backvalues");
        private static readonly TelemetryClient _client = new TelemetryClient();

        public async Task<string> Get()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _url
            };

            _client.TrackTrace("FrontValuesController Get");
            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> Post([FromBody]string message)
        {
            _client.TrackTrace($"FrontValuesController Post {message}");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent("\""+message+"\"", Encoding.UTF8, "application/json"),
                RequestUri = _url
            };
            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
