using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.ViewComponents.ShocaseStatistic
{
    public class Statistic1:ViewComponent
    {
        BookManager bookManager = new BookManager(new EfBookRepository()); // toplam blog sayısı
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.totelBook = bookManager.GetList().Count(); //toplam bkitap sayısı **birden fazla manager kulllanılcaksa viewbag kullan 
            ViewBag.totelUser = c.Users.Count(); //toplam KUllanıcı sayısı
            ViewBag.totelWriter = c.Writers.Count(); //toplam KUllanıcı sayısı
            //ViewBag.totelComment = c.Comments.Count(); //toplam yorum sayısı

            //string api = "da0d56b3b95e412d8799d554ba6221a7";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=kastamonu&mode=xml&lang=tr&units=metric&appid=" + api;
            //XDocument xDocument = XDocument.Load(connection);
            //ViewBag.temperature = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
