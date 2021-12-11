using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        CategoryValidator categoryRules = new CategoryValidator();
        public IActionResult Index()
        {
            var value = bookManager.GetListWithCategory();
            return View(value);
        }

        public IActionResult BookReadAll(int id)
        {
           
            var value = bookManager.GetBookById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            //ValidationResult result = categoryRules.Validate(book);

            //if (result.IsValid)
            //{
               


                bookManager.Add(book);
                return RedirectToAction("Index", "Book");
            //}
            //else if (!result.IsValid)
            //{
            //    foreach (var rule in result.Errors)
            //    {
            //        ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
            //    }


            //}

            //return View();

        }
    }
}
