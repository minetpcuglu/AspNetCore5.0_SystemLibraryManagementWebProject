using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class BookLing:ViewComponent
    {
       
            Context c = new Context(); //Toplam Yeni mesaj sayısı
            public IViewComponentResult Invoke()
            {

                ViewBag.BookCount = c.Books.Count();
                ViewBag.BookCountStatus = c.Books.Where(x=>x.BookStatus==false).Count();

                return View();
            }
        
    }
}
