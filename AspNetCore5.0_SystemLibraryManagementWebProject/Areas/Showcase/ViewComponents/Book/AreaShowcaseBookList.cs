using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.ViewComponents.Book
{
    public class AreaShowcaseBookList:ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        public IViewComponentResult Invoke()
        {

            var Value = bookManager.GetList().Take(4);
            return View(Value);
        }
    }
}
