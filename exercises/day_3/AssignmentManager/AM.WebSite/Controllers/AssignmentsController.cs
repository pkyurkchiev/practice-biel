using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.WebSite.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
