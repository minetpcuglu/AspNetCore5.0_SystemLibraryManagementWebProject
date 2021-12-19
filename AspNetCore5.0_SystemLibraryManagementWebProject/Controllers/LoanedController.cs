using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class LoanedController : Controller  //takeonloan ödünc alma 
    {
        MovementManager movementManager = new MovementManager(new EfMovementRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Loan() //Ödünç ver 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loan(Movement movement) //Ödünç ver 
        {
           movementManager.Add(movement);
            return View();
        }
    }
}
