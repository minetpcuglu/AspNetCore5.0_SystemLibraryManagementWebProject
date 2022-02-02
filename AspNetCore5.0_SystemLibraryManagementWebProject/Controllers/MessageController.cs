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
            //var username = User.Identity.Name;  //sisteme giren kullanıcı adı soyadı
            //ViewBag.value = username;
            //Context c = new Context();
            //var userName = c.Users.Where(x => x.UserName == username).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            //ViewBag.value2 = userName;

            //var userImage = c.Users.Where(x => x.UserName == username).Select(y => y.Image).FirstOrDefault();
            //ViewBag.Image = userImage;
            //return View();

            // Context c = new Context();
            //var userName = User.Identity.Name;
            ////sisteme otantike olan kullanıcının bilgilerinin gelmesi
            //var userId = c.Messages.Where(x => x.ReceiverUser.UserName == userName).Select(y => y.MessageId).FirstOrDefault(); ** hata burada 
            //var uservalue = messageManager.GetInboxListByUser(userId);
            ////return View(uservalue);

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
