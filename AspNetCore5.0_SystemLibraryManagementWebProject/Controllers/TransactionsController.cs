using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class TransactionsController : Controller
    {
        MovementManager movementManager = new MovementManager(new EfMovementRepository());
        public IActionResult Index()
        {
            var value = movementManager.GetListWithBook().Where(x => x.IslemDurum == true).ToList(); ;
            return View(value);
           
        }
    }
}
