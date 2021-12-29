using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
  
        public IActionResult Index(int page = 1)
        {

            var value = writerManager.GetList();


            return View(value.ToPagedList(page, 8));
        }

        public IActionResult WriterReadAll(int id)
        {
            ViewBag.x = id;
            var value = writerManager.GetWriterById(id);
            return View(value);
        }

    }
}
