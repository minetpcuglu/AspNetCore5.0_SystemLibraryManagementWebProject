using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        Context c = new Context();
        public IActionResult Inbox(string userName) /*Gelen kutusu*/
        {

            var user = c.Users.FirstOrDefault(x => x.UserName == userName);

            if (user.UserId != 0)
            {
                var result = messageManager.GetInboxListByUser(user.UserId);
                return View(result);
            }


            return null;

        }
        public IActionResult MessageDetails(int id)
        {


            var value = messageManager.GetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {

            return View() ;
          
        }

        [HttpPost]
        public IActionResult NewMessage(Message message)
        {

            var value = DateTime.Now;
          
            message.MessageStatus = true;
            messageManager.Add(message);
            
            return RedirectToAction("Inbox");
        }
    }
}
