using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            employeeManager.Add(employee);
            return RedirectToAction("Index");
        }
    }
}
