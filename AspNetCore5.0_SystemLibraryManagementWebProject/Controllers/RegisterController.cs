using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        WriterValidator writerRules = new WriterValidator();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.getCity = GetCityList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer, string city, string againPassword, IFormFile file)
        {

            ValidationResult result = writerRules.Validate(writer);
            if (result.IsValid && writer.Password == againPassword)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    writer.Image = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                writer.WriterStatus = true;
                writer.Description = "Lütfen bir seyler yazınız";
               
                writerManager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if (!result.IsValid)
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }


            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Hatalı giriş. Girilen şifreler eşleşmedi tekrar deneyiniz.");
            }
            return View();

        }
        public List<string> GetCity()
        {
            String[] CityList = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            return new List<string>(CityList);
        }

        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> getCity = (from n in GetCity()
                                            select new SelectListItem
                                            {
                                                Text = n,
                                                Value = n
                                            }).ToList();
            return getCity;
        }
    }
}
