using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.Controllers
{
    public class ContactController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
