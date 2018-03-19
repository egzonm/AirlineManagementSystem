using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LayoutDetails details;
            details.name = "Airline Management System";
            details.email = "airline@info.com";
            details.telephone = "044849130";
            ViewBag.DetailsForPage = details.name +" "+ details.email +" "+ details.telephone;

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