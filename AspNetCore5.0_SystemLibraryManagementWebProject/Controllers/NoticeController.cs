using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}
