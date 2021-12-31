using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Statistic
{
    public class StatisticAdmin : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = c.Writers.Where(x => x.WriterId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.adminImage = c.Writers.Where(x => x.WriterId == 1).Select(y => y.Image).FirstOrDefault();
            ViewBag.adminDescription = c.Writers.Where(x => x.WriterId == 1).Select(y => y.Description).FirstOrDefault();
            return View();
        }
    }
}
