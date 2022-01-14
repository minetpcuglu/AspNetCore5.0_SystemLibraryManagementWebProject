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
    public class UserName: ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userName = User.Identity.Name;
            //sisteme otantike olan kullanıcının bilgilerinin gelmesi
            var userId = c.Users.Where(x => x.Name + x.Surname == userName).Select(y => y.UserId).FirstOrDefault();
            var uservalue = userManager.GetById(userId);
            return View(uservalue);
        }
    }
}
