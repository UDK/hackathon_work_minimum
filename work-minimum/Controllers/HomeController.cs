using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using work_minimum.Models;

namespace work_minimum.Controllers
{
    [Route("api/")]
    public class HomeController : Controller
    {
        [HttpPost]
        public JsonResult Index(string name)
        {
            return Json(name+"asdasdas");
        }
    }
}
