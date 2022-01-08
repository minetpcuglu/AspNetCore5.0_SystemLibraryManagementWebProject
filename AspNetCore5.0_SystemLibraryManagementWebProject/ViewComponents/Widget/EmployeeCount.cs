using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class EmployeeCount : ViewComponent
    {
        Context c = new Context(); //Toplam kullanıcı sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.EmployeeCount = c.Employees.Count();

            return View();
        }
    }
}
