using AutoMapper;
using DataAccessLayer.Models.VMs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class UserRegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserRegisterController(UserManager<AppUser> userManager , IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInVM model)
        {
            if (ModelState.IsValid) //moeldeki kurallar saglandıysa
            {
                var appUser = _mapper.Map<UserSignInVM, AppUser>(model);
                var result = await _userManager.CreateAsync(appUser, model.Password); //identtiy kütüphanesinin kendi create metoduyla ekleme yaptık
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
