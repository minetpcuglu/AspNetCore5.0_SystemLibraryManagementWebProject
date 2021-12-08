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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        WriterValidator writerRules = new WriterValidator();
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
            ValidationResult result = writerRules.Validate(writer);

            if (result.IsValid)
            {
                writer.WriterStatus = true;


                writerManager.Add(writer);
                return RedirectToAction("Index");
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
