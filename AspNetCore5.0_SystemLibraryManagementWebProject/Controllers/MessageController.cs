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

        [HttpGet]
        public IActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            //var mail = (string).Session["UserName"].ToString();
            //message.ReceiverUser = mail.tostring();

            message.MessageDate.ToShortDateString();
            message.MessageStatus = true;
            messageManager.Add(message);
            
            return RedirectToAction("Inbox");
        }
    }
}
