using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfBookRepository:GenericRepository<Book>,IBookDal
    {

        //public List<Book> GetBookByWriterId(int id)
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Books.Include(x => x.Category).Where(x => x.WriterId == id).ToList(); 
        //    }
        //}

        public List<Book> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Books.Include(x => x.Category).Include(x=>x.Writer)/*.Where(x=>x.BookStatus==true)*/.ToList();
            }
        }
      



        public List<Book> GetListWithCategoryByWriterId(int id)
        {
            using (var c = new Context())
            {
                return c.Books.Include(x => x.Category).Where(x => x.WriterId == id /*&& x.BookStatus == true*/).ToList(); ;
            }
        }

        public List<Book> GetListWithCategoryBookId(int id)
        {
            using (var c = new Context())
            {
                return c.Books.Include(x => x.Category).Where(x => x.BookId == id /*&& x.BookStatus == true*/).ToList(); ;
            }
        }


    }
}
