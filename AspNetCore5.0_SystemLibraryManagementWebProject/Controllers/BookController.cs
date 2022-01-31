using AspNetCore5._0_SystemLibraryManagementWebProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using ClosedXML.Excel;
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

            var value = bookManager.GetListWithCategoryBookId(id);
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
                                                    Text = x.Name + " " + x.Surname,

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


        [HttpGet]
        public IActionResult BookEditProfile(int id)
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
                                                    Text = x.Name + " " + x.Surname,

                                                    Value = x.WriterId.ToString()
                                                }).ToList();

            ViewBag.value2 = writerValue;

            var bookvalue = bookManager.GetById(id);
            return View(bookvalue);
        }

        [HttpPost]

        public async Task<IActionResult> BookEditProfile(Book book, IFormFile file)
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

                bookManager.Update(book);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }


        public IActionResult DeleteBook(int id)
        {
            var value = bookManager.GetById(id);
            bookManager.Delete(value);
            return RedirectToAction("Index");
        }

        //excel 
        public IActionResult ExportStaticExcelBook()
        {
            using (var workbook = new XLWorkbook())

            {
                var worksheet = workbook.Worksheets.Add("Kitap Listesi");
                worksheet.Cell(1, 1).Value = "Kitap ID";
                worksheet.Cell(1, 2).Value = " Adı";
                worksheet.Cell(1, 3).Value = " Sayfa";
                worksheet.Cell(1, 4).Value = " Yayınevi";

                int BookRowCount = 2;
                foreach (var book in GetBookList())
                {
                    worksheet.Cell(BookRowCount, 1).Value = book.Id;
                    worksheet.Cell(BookRowCount, 2).Value = book.Name;
                    worksheet.Cell(BookRowCount, 3).Value = book.BookNumberPage;
                    worksheet.Cell(BookRowCount, 4).Value = book.BookPublisher;

                    BookRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","KütüphaneKitapListesi.xls");
                }
            }
           
        }

        public List<BookModel> GetBookList()
        {
            List<BookModel> bookModels = new List<BookModel>
            {
                new BookModel{Id=1,Name="10 Dakika 34 Saniye",BookNumberPage="170",BookPublisher="2021" },
                new BookModel{Id=1,Name="10 Dakika ",BookNumberPage="200",BookPublisher="2022" },
            };
            return bookModels;
        }


        public IActionResult BlogListExcel()
        {
            return View();
        }


    }
}
