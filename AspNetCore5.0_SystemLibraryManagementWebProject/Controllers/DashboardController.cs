using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class DashboardController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
       CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        MovementManager movementManager = new MovementManager(new EfMovementRepository());
       
       
        public IActionResult Index()
        {
            ViewBag.CountBookTotel = bookManager.GetList().Count();
            ViewBag.CountCategoryTotel = categoryManager.GetList().Count();
            ViewBag.CountLoanBookTotel = movementManager.GetList().Where(x => x.IslemDurum == true).Count();
            return View();
        }
    }
}
