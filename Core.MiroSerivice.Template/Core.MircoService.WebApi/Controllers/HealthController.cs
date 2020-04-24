using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.MircoService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            Console.WriteLine($"心跳检测:{DateTime.Now}");
            return Ok();
        }

    }
}