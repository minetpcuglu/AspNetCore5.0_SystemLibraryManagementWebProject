using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    [Area("Showcase")]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
    
        WriterValidator writerRules = new WriterValidator();
        public IActionResult Index(int page = 1)
        {
         
            var value = writerManager.GetList();
        

            return View(value.ToPagedList(page, 8));
        }

        public IActionResult WriterReadAll(int id)
        {
            ViewBag.x = id;
            var value = writerManager.GetWriterById(id);
            return View(value);
        }



        [HttpGet]
        public IActionResult AddWriter()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWriter(Writer writer, IFormFile file)
        {
            ValidationResult result = writerRules.Validate(writer);

            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    writer.Image = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }


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

        [HttpGet]
        public IActionResult WriterEditProfile(int id)
        {
            var writervalue = writerManager.GetById(id);
            return View(writervalue);
        }

        [HttpPost]

        public async Task<IActionResult> WriterEditProfile(Writer writer, IFormFile file)
        {
            ValidationResult result =writerRules.Validate(writer);
            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    writer.Image = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                
                writerManager.Update(writer);

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

       
        public IActionResult DeleteWriter(int id)
        {
            var value = writerManager.GetById(id);
            writerManager.Delete(value);
            return RedirectToAction("Index");
        }
    }
}

