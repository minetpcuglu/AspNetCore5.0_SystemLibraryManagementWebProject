using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Writer
{
    public class DashboardWriterAbout:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
       

        public IViewComponentResult Invoke()
        {

            var Value = writerManager.GetWriterListWithBook().Take(4).ToList();//yazarlar
            return View(Value);
        }
    }
}
