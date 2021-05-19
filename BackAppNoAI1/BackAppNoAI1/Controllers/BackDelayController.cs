using System.Threading.Tasks;
using System.Web.Http;

namespace BackAppNoAI1.Controllers
{
    public class BackDelayController : ApiController
    {
        private async Task LongRunningTask(int msec)
        {
            await Task.Delay(msec);
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
