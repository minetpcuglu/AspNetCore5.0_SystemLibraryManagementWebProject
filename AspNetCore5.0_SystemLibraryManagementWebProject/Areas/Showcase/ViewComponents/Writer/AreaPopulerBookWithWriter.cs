using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.ViewComponents.Writer
{
    public class AreaPopulerBookWithWriter:ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        public IViewComponentResult Invoke(int id)
        {

            var Value = bookManager.GetListWithCategoryByWriterId(id);
            return View(Value);
        }
    }
  
}
