using MagazineApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazineApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(SubscriberContext context = new SubscriberContext())

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
    }
}