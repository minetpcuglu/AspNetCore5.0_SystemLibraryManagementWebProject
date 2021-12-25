using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject.Controllers
{
    public class LoanedController : Controller  //takeonloan ödünc alma 
    {
        MovementManager movementManager = new MovementManager(new EfMovementRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
       
        public IActionResult Index()
        {
            return View();
        }

      
        [HttpGet]
        public IActionResult LoanBookList() //Ödünç kitap Listesi
        {
            var value = movementManager.GetListWithBook();
            return View( value);
        }

        //[HttpPost]
        //public IActionResult LoanBookList([Bind(Prefix =) //Ödünç kitap Listesi
        //{

        //    return View(Tuple.Create<Movement, Book, Employee, User>(new Movement(), new Book(), new Employee(), new User()));
        //}

        [HttpGet]
        public IActionResult Loan() //Ödünç ver 
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Loan(Movement movement) //Ödünç ver 
        {
           movementManager.Add(movement);
            return RedirectToAction("LoanBookList");
        }

        //[HttpGet]
        //public IActionResult TakeOnLoan() //ödünç iade
        //{
            
        //    return View(/*Tuple.Create<Movement,Book,Employee,User>(new Movement(),new Book(),new Employee(),new User())*/);
        //}

        public IActionResult TakeOnLoan(int id /*,[Bind(Prefix ="kullanici")]User Model1, [Bind(Prefix = "personel")] Employee Model2, [Bind(Prefix = "kitap")]Book Model3, [Bind(Prefix = "hareket")] Movement Model4*/) //ödünç iade
        {
            var value = movementManager.GetById(id);
            return View(value);
        }
    }
}
