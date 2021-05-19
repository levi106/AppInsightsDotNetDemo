﻿using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BackAppNoAI1.Controllers
{
    public class BackValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return $"Your value is: {id}";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
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
