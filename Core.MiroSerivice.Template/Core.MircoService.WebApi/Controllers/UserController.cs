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
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var user = new
            {
                Id = 1,
                Name = "user 1"
            };
            return new JsonResult(user);
        }

    }
}