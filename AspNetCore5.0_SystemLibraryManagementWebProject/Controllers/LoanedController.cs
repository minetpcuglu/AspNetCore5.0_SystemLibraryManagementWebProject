using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        UserManager userManager = new UserManager(new EfUserRepository());
        BookManager bookManager = new BookManager(new EfBookRepository());
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult LoanBookList() //Ödünç kitap Listesi
        {
          

            var value = movementManager.GetListWithBook().Where(x => x.IslemDurum == false).ToList();
            return View(value);
        }



        //[HttpPost]
        //public IActionResult LoanBookList([Bind(Prefix =) //Ödünç kitap Listesi
        //{

        //    return View(Tuple.Create<Movement, Book, Employee, User>(new Movement(), new Book(), new Employee(), new User()));
        //}

        [HttpGet]
        public IActionResult Loan() //Ödünç ver 
        {
            List<SelectListItem> userValue = (from x in userManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name + " " + x.Surname,
                                                  Value = x.UserId.ToString()
                                              }).ToList();

            ViewBag.value = userValue;

            List<SelectListItem> employeeValue = (from x in employeeManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.NameSurname,
                                                      //Text = x.e + " " + x.Surname,

                                                      Value = x.EmployeeId.ToString()
                                                  }).ToList();

            ViewBag.value2 = employeeValue;

            List<SelectListItem> bookValue = (from x in bookManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.BookName,


                                                  Value = x.BookId.ToString()
                                              }).ToList();

            ViewBag.value3 = bookValue;
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
        /*,[Bind(Prefix ="kullanici")]User Model1, [Bind(Prefix = "personel")] Employee Model2, [Bind(Prefix = "kitap")]Book Model3, [Bind(Prefix = "hareket")] Movement Model4*/


        public IActionResult TakeOnLoan(int id) //ödünç iade
        {
            var value = movementManager.GetById(id);
            DateTime date = DateTime.Parse(value.IadeTarihi.ToString());
            DateTime date2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan date3 = date2 - date;
            ViewBag.dgr = date3.TotalDays;


            return View("TakeOnLoan", value);
        }


        public IActionResult TakeOnLoanUpdate(Movement movement) //Ödünç ver 
        {
            var value = c.Movements.Find(movement.MovementId);
            value.UyeGetirdigiTarihi = movement.UyeGetirdigiTarihi;
            value.IslemDurum = true;
            c.SaveChanges();

            return RedirectToAction("LoanBookList");
        }

    }
}
