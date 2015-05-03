using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWT_projekat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PromjenaLozinke(int id, Guid guid) {
            ViewBag.Id = id;
            ViewBag.Guid = guid;
            return View();
        }
    }
}
