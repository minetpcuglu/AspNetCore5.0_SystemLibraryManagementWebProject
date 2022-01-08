using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class WriterTheMostBook : ViewComponent
    {

        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {

            ViewBag.WriterName= c.Writers.OrderByDescending(x => x.WriterId).Select(x => x.Name + " " + x.Surname).Take(1).FirstOrDefault();


            return View();
        }

    }
}
