﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Weather()
        {
            return View();
        }

        public IActionResult WeatherCart()
        {
            return View();
        }

        public IActionResult LinqCard()
        {
            return View();
        }

     
    }
}
