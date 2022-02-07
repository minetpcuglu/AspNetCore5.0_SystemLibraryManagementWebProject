using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class NoticeController : Controller
    {
        NoticeManager noticeManager = new NoticeManager(new EfNoticeRepository());
        public IActionResult Index()
        {
            var value = noticeManager.GetList();
            return View(value);
        }



        [HttpGet]
        public IActionResult AddNotice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotice(Notice notice)
        {
          
                noticeManager.Add(notice);
                return RedirectToAction("Index");
           
        }


        public IActionResult DeleteNotice(int id)
        {
            var value = noticeManager.GetById(id);
            noticeManager.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult NoticeUpdate(int id)
        {
            var value = noticeManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult NoticeUpdate(Notice notice)
        {
           
                noticeManager.Update(notice);
                return RedirectToAction("Index");
           
        }

    }
}
