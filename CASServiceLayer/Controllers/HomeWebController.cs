﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASServiceLayer.Controllers
{
    public class HomeApiController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}