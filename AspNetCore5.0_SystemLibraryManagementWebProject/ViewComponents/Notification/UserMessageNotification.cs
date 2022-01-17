using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Notification
{
    public class UserMessageNotification : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            Context c = new Context();
            var userId = c.Users.Where(x => x.UserName == user).Select(y => y.UserId).FirstOrDefault();
         
            var value = messageManager.GetInboxListByUser(userId);
            return View(value);
        }
    }
}
