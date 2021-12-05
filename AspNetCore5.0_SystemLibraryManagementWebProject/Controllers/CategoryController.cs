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
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CategoryValidator categoryRules = new CategoryValidator();
        public IActionResult Index(int page=1)
        {
            var value = categoryManager.GetList();
            return View(value.ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            ValidationResult result = categoryRules.Validate(category);

            if (result.IsValid)
            {
                category.CategoryStatus = true;


                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
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

        public IActionResult DeleteCategory(int id)
        {
    
            var value = categoryManager.GetById(id);
            categoryManager.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {

            var value = categoryManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {

            category.CategoryStatus = true;
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }


    }
}
