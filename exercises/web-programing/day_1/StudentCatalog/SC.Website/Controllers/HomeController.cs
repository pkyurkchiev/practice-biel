using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SC.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hello(int? id, string name)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;

            return View();
        }

        public ActionResult Calculator(int? a, int? b)
        {
            ViewBag.Area = a * b;
            ViewBag.Perimeter = 2*b + 2*a;

            return View();
        }
    }
}