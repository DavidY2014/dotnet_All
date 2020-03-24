using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Advanced.NetFrame.WebAPI.Models;

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

        [HttpGet]
        public string GetUserById(int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            
            return null;
        }

        /// <summary>
        /// 这种方式入参无法直接获取信息，需要通过querystring
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetUserById(User user)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string nameParam = HttpContext.Current.Request.QueryString["Name"];
            return null;
        }

        /// <summary>
        /// 这种方式如果前端js的data为一个对象，那么后端通过加[FromUri]获取实体对象
        /// 数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetUserByModel([FromUri] User user)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string nameParam = HttpContext.Current.Request.QueryString["Name"];
            return null;
        }


        #endregion

    }
}
