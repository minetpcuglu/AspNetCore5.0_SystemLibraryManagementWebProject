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
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        EmployeeValidation employeeRules = new EmployeeValidation();
        public IActionResult Index(int page =1)
        {
            var value = employeeManager.GetList();
            return View(value.ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            ValidationResult result = employeeRules.Validate(employee);
            if (result.IsValid)
            {
                employeeManager.Add(employee);
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

      
        public IActionResult DeleteEmployee(int id)
        {
           var value= employeeManager.GetById(id);
            employeeManager.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EmployeeUpdate(int id)
        {
            var value = employeeManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            ValidationResult result = employeeRules.Validate(employee);
            if (result.IsValid)
            {
                employeeManager.Update(employee);
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
