using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class BookNameLing:ViewComponent
    {
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.BookName = c.Books.OrderByDescending(x => x.BookId).Select(x => x.BookName).Take(1).FirstOrDefault();//son eklenen kitap
          
  

            return View();
        }
    }
}
