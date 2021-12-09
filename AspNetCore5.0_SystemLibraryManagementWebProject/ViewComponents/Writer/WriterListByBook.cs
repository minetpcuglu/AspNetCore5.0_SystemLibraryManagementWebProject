using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Writer
{
    public class WriterListByBook:ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository());

        public IViewComponentResult Invoke(int id)
        {
            var Value =  bookManager.GetListWithWriter(1);
            return View(Value);
        }
    }
}
