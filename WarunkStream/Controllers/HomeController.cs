﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WarunkStream.Controllers
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
        public async Task<ActionResult> Register()
        {
            return View();
        }
        public async Task<ActionResult> AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Certificate()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Login()
        {
            return View();
        }
    }
}