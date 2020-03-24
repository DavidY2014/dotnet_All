using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Advanced.NetFrame.WebAPI.Controllers
{
    /// <summary>
    /// 如果路由不用的话，可以加个~
    /// eg:[Route("~api/Values/{id:int}")]
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        #region 特性路由

        [Route("api/Values/{id:int}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        [Route("api/Values/{name}")]
        public string Get(string name)
        {
            return $"value {name}";
        }

        [Route("api/Values/{id:int}/Type/{typeID:int}")]
        public string Get(int id, int typeId)
        {
            return $"value-Type {id} {typeId}";
        }


        #endregion

    }
}
