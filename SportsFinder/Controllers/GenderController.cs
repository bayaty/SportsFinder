﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportsFinder.Controllers
{
    public class GenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}