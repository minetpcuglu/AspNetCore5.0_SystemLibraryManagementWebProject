﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
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
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.NewBook = c.Books.OrderByDescending(x => x.BookId).Select(x => x.BookName).Take(4).FirstOrDefault();//son eklenen blog
            var value = bookManager.GetListWithCategory();
            return View(value);
        }

        public IActionResult GetlistBookId(int id)
        {
          
            var value = bookManager.GetListWithCategoryBookId(id);
            return View(value);
        }
    }
}
