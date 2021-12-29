using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.ViewComponents.Book
{
    public class AreaBookListSidebar:ViewComponent
    {

        BookManager bookManager = new BookManager(new EfBookRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.NewBook = c.Books.OrderByDescending(x => x.BookId).Select(x => x.BookName).Take(4).FirstOrDefault();//son eklenen kitaplar
            var Value = bookManager.GetList();
            return View(Value);
        }
    }
}
