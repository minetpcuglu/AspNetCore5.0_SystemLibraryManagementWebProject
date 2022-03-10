using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class LoginController : Controller
    {
        readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true); //perssitent true cerezlerde şifreyi hatırlasın //5 kez yanlıs giriş yaparsa hesap bloke olcak belli süre
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            else
            {
                ModelState.AddModelError("", "Hatalı Kullanıcı Adı/Şifre");
                return View();
            }
          
        }





        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(Employee employee)
        {
            Context c = new Context();
            var dataValue = c.Employees.FirstOrDefault(x => x.Email == employee.Email && x.Password == employee.Password);

            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,employee.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                ModelState.AddModelError("", "Hatalı Kullanıcı Adı/Şifre");
                return View();
            }

        }


        public async Task< ActionResult> LogOut()
        {
          await  HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
