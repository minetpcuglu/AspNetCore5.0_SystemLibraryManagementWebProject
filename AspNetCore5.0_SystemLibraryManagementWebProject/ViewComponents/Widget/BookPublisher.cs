using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Widget
{
    public class BookPublisher : ViewComponent
    {
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.BookPublish = c.Books.GroupBy(x=>x.Publisher).OrderByDescending(y=>y.Count()).Select(z=> new {z.Key }).FirstOrDefault();//son eklenen kitap



            return View();
        }
    }
}
