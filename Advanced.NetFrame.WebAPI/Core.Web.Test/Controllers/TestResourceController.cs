using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Web.Test.Filters;

namespace Core.Web.Test.Controllers
{
    public class TestResourceController : Controller
    {
        [CustomResourceFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}