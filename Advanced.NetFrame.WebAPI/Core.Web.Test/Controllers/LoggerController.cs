using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Test.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Web.Test.Controllers
{
    public class LoggerController : Controller
    {
        private ILoggerFactory _factory;
        private IService _myService;
        public LoggerController(ILoggerFactory factory,IService myService)
        {
            //把日志注入进来
            _factory = factory;
            _myService = myService;//通过autofac注入进来了
        }
        public IActionResult Index()
        {
            ILogger<LoggerController> _ilogger = _factory.CreateLogger<LoggerController>();
            _ilogger.LogError($"this is start up error");

            return View();
        }
    }
}