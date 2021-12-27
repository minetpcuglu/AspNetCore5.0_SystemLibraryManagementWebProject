using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Book
{
    public class ShowcaseBookList : ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        public IViewComponentResult Invoke()
        {

            var Value = bookManager.GetList();
            return View(Value);
        }
    }
}
