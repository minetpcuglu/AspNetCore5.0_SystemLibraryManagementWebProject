using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IActionResult Index(int page=1)
        {
            var value = userManager.GetList();
            return View(value.ToPagedList(page, 10));
        }
    }
}
