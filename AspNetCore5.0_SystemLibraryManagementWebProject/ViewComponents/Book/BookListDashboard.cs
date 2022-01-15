using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Book
{
    public class BookListDashboard:ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
          
            var Value = bookManager.GetListWithCategory().Take(7).ToList();//son eklenen kitaplar
            return View(Value);
        }
    }
}
