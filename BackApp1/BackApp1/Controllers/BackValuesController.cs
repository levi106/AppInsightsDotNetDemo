using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackApp1.Controllers
{
    public class BackValuesController : ApiController
    {
        static private readonly TelemetryClient _telemetry = new TelemetryClient();

        // GET api/values
        public IEnumerable<string> Get()
        {
            _telemetry.TrackTrace("BackValuesController Get");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            _telemetry.TrackTrace($"BackValuesController Get {id}");
            return $"Your value is: {id}";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            _telemetry.TrackTrace($"ValuesController.Post",
                SeverityLevel.Information,
                new Dictionary<string, string>
                {
                    {"value", value},
                    {"length", value?.Length.ToString()}
                });
            return $"{DateTime.Now.ToLongTimeString()}: {value}";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
