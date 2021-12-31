using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.Statistic
{
    public class StatisticLastBook : ViewComponent
    {
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {

            ViewBag.lastBook = c.Books.OrderByDescending(x => x.BookId).Select(x => x.BookName).Take(1).FirstOrDefault();//son eklenen kitap
            ViewBag.totelUser = c.Users.Count(); //toplam Kullanıcı sayısı
            return View();
        }
    }
}
