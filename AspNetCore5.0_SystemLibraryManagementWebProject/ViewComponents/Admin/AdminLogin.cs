using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Admin
{
    public class AdminLogin : ViewComponent
    {
        EmployeeManager EmployeeManager = new EmployeeManager(new EfEmployeeRepository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;  //sisteme giren kullanıcı adı soyadı
            ViewBag.value = username;

            Context c = new Context();
            var adminName = c.Employees.Where(x => x.Email == username).Select(y => y.NameSurname ).FirstOrDefault();
            ViewBag.value2 = adminName;

            var adminImage = c.Employees.Where(x => x.Email == username).Select(y => y.Image).FirstOrDefault();
            ViewBag.Image = adminImage;
            return View();
            
        }
    }
}
