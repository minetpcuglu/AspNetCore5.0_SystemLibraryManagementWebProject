using AspNetCore5._0_SystemLibraryManagementWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { CategoryName="Roman",CategoryCount=10});
            list.Add(new CategoryClass { CategoryName="Söylev",CategoryCount=1});
            list.Add(new CategoryClass { CategoryName="Hikaye",CategoryCount=5});
            list.Add(new CategoryClass { CategoryName="Polisiye",CategoryCount=7});

            return Json(new { jsonlist=list});
        }
    }
}
