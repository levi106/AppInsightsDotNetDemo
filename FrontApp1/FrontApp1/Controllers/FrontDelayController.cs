using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FrontApp1.Controllers
{
    public class FrontDelayController : ApiController
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Uri _url = new Uri("https://backapp1-da3q.azurewebsites.net/api/backdelay");

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
