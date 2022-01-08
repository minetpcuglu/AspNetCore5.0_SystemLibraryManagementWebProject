using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class UserCount:ViewComponent
    {
        Context c = new Context(); //Toplam kullanıcı sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.UserCountStatus = c.Users.Count();

            return View();
        }
    }
}
