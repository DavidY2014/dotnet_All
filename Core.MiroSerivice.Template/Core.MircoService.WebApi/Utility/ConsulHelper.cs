using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Configuration;

namespace Core.MircoService.WebApi.Utility
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://129.28.178.153:8500/");
                //c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dcl";
            });
            string ip = configuration["ip"];
            int port = int.Parse(configuration["port"]);
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "service" + Guid.NewGuid(),//每个服务名
                Name = "ConsulTestServiceGroup",//grop name
                Address = ip,
                Port = port,
                //配置心跳检查，不然consul会一直默认在线
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(10 ),
                    HTTP = $"http://{ip}:{port}/api/Health/Index",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(35)
                }
            });
            Console.WriteLine($"http://{ip}:{port}完成注册");
        }

    }
}
