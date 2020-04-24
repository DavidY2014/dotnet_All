using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Core.MiroSerivice.Template.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Core.MiroSerivice.Template.Controllers
{

    /// <summary>
    /// consul 只是做一个发现注册存活的服务，但是call的过程还是直接ip地址调用的
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// consul发现
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            #region 直接调用服务
            #endregion


            #region 客户端发现consul，不属于服务调用

            using (ConsulClient client = new ConsulClient(c=> {
                c.Address = new Uri("http://129.28.178.153:8500/");
                //c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                string message = "";
                foreach (var keyValuePair in dictionary)
                {
                    AgentService agentService = keyValuePair.Value;
                    message += $"{agentService.Address}:{agentService.Port}\n"; 
                }
                base.ViewBag.Message = message;
            }

            #endregion


            #region 调用，负载均衡

            string url = "http://ConsulTestServiceGroup:8500/api/User/GetUsers";
            Uri uri = new Uri(url);
            string groupName = uri.Host;
            using (ConsulClient client = new ConsulClient(c=> {
                c.Address = new Uri("http://129.28.178.153:8500");
                c.Datacenter = "dc1";
            
            })) {
                var dictionary = client.Agent.Services().Result.Response;
                var list = dictionary.Where(k => k.Value.Service.Equals(groupName,
                    StringComparison.OrdinalIgnoreCase));
                KeyValuePair<string, AgentService> keyValuePair = new KeyValuePair<string, AgentService>();
                keyValuePair = list.First();
                var resultUrl = $"{uri.Scheme}://{keyValuePair.Value.Address}:" +
                    $"{keyValuePair.Value.Port}{uri.PathAndQuery}";
                string result = WebApiHelperExtend.InvokeApi(resultUrl);

            }



                #endregion

                return View();
        }
    }
}