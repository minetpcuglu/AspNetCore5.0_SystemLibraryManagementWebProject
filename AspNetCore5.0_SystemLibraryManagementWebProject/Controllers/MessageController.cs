using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox() /*Gelen kutusu*/
        {

            int id = 3;
            var value = messageManager.GetInboxListByUser(id);
            return View(value);
            
        }
        public IActionResult MessageDetails(int id)
        {


            var value = messageManager.GetById(id);
            return View(value);
        }
    }
}
