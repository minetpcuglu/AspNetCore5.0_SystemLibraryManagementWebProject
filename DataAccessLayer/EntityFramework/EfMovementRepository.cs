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
    public class EfMovementRepository : GenericRepository<Movement>, IMovementDal
    {
        public List<Movement> GetListWithBookName()
        {
            using (var c = new Context())
            {
                return c.Movements.Include(x => x.Book).Include(x=>x.Employee).Include(x=>x.User).ToList();
            }
        }

        public List<Movement> GetListWithMovement(int id)
        {
            using (var c = new Context())
            {
                return c.Movements.Include(x => x.Book).Include(x => x.Employee).Include(x => x.User).ToList();
            }
        }

        //public List<Movement> GetListWithBookName(int id)
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Movements.Include(x => x.Book).Where(x => x.UserId == id && x.EmployeeId==id).ToList(); ;
        //    }
        //}




        //public List<Book> GetListWithBookName()
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Books.Include(x => x.BookName).Where(x => x.BookStatus == true).ToList();
        //    }
        //}
    }
}
