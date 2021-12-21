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
            return View(/*Tuple.Create<Movement,Book,Employee,User>(new Movement(),new Book(),new Employee(),new User())*/ value);
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

        public IActionResult TakeOnLoan(int id) //ödünç iade
        {
            var value = movementManager.GetById(id);
            return View(value);
        }
    }
}
