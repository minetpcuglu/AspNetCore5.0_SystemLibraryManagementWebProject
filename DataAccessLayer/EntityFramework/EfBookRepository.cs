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
       

        public List<Book> GetListWithWriter(int id) //kategoriye göre yazar getirme
        {
            using (var c = new Context())
            {
                return c.Books.Include(x => x.Writer).Where(x => x.WriterId == id).ToList();
            }
        }
    }
}
