using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.User
{
    public class UserLoginLayout : ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;  //sisteme giren kullanıcı adı soyadı
            ViewBag.value = username;
            Context c = new Context();
            var userName = c.Users.Where(x => x.UserName == username).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.value2 = userName;

            var userImage = c.Users.Where(x => x.UserName == username).Select(y => y.Image).FirstOrDefault();
            ViewBag.Image = userImage;
            return View();

            ;
        }
    }
}
