using Microsoft.ApplicationInsights;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackApp1.Controllers
{
    public class BackDelayController : ApiController
    {
        static private readonly TelemetryClient _client = new TelemetryClient();

        private async Task LongRunningTask(int msec)
        {
            _client.TrackTrace("Start LongRunningTask");
            await Task.Delay(msec);
            _client.TrackTrace("End LongRunningTask");
        }

        public async Task<int> Get()
        {
            int msec = 1000;
            await LongRunningTask(msec);
            return msec;
        }

        public async Task<int> Get(int id)
        {
            await LongRunningTask(id);
            return id;
        }
    }
}
