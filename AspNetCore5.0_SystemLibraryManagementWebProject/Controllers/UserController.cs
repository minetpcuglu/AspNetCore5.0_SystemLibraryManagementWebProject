using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        UserValidator userRules = new UserValidator();
        public IActionResult Index(int page=1)
        {
            var value = userManager.GetList();
            return View(value.ToPagedList(page, 10));
        }

        public IActionResult UserReadAll(int id)
        {
           
            var value = userManager.GetUserById(id);
            return View(value);
           
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(User user, IFormFile file)
        {
            ValidationResult result = userRules.Validate(user);

            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    user.Image = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                userManager.Add(user);
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




        public IActionResult DeleteUser(int id)
        {
            var value = userManager.GetById(id);
            userManager.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserEditProfile(int id)
        {
            var uservalue = userManager.GetById(id);
            return View(uservalue);
        }

        [HttpPost]

        public async Task<IActionResult> UserEditProfile(User user , IFormFile file)
        {
            ValidationResult result = userRules.Validate(user);
            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    user.Image = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                userManager.Update(user);

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
    }
}
