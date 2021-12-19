using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class LoanedController : Controller  //takeonloan ödünc alma 
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Loan() //Ödünç ver 
        {
            return View();
        }
    }
}
