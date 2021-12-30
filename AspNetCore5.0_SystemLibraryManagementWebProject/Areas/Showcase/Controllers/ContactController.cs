using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contactManager.Add(contact);
            return RedirectToAction("AddContact");
        }
    }
}
