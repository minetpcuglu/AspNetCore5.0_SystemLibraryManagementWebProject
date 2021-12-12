using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BookValidator bookRules = new BookValidator();
        public IActionResult Index()
        {
            var value = bookManager.GetListWithCategory();
            return View(value);
        }

        public IActionResult BookReadAll(int id)
        {
           
            var value = bookManager.GetListWithCategoryByWriterId(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.value = categoryValue;

            List<SelectListItem> writerValue = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name +" "+ x.Surname,

                                                      Value = x.WriterId.ToString()
                                                }).ToList();

            ViewBag.value2 = writerValue;



            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            ValidationResult result = bookRules.Validate(book);

            if (result.IsValid)
            {
                bookManager.Add(book);
                return RedirectToAction("Index", "Book");
            }
            else if (!result.IsValid)
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }


            }

            return View();

        }
    }
}
