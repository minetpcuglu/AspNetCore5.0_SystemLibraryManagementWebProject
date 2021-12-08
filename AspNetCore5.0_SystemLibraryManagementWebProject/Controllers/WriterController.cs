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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var value = writerManager.GetList();
            return View(value);
        }

        public IActionResult WriterReadAll(int id)
        {
            var value = writerManager.GetWriterById(id);
            return View(value);
        }



        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            //ValidationResult result = categoryRules.Validate(category);

            //if (result.IsValid)
            //{
            //    category.CategoryStatus = true;


            //    categoryManager.Add(category);
            //    return RedirectToAction("Index", "Category");
            //}
            //else if (!result.IsValid)
            //{
            //    foreach (var rule in result.Errors)
            //    {
            //        ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
            //    }


            //}

            //return View();

            writerManager.Add(writer);
            return RedirectToAction("Index");
        }
    }
}
