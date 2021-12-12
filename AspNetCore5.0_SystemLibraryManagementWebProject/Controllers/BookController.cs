using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BookValidator bookRules = new BookValidator();
        public IActionResult Index(int page = 1)
        {
            var value = bookManager.GetListWithCategory();
            return View(value.ToPagedList(page, 8));
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
        public async Task<IActionResult> AddBook(Book book, IFormFile file)
        {
            ValidationResult result = bookRules.Validate(book);

            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                   book.BookImage = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }
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
