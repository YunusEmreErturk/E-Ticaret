﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CircloidTemplate.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewBag.MainPageSelected = "selected";
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}