using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetlistBookId(int id)
        {
            var value = bookManager.GetListWithCategoryBookId(id);
            return View(value);
        }
    }
}
