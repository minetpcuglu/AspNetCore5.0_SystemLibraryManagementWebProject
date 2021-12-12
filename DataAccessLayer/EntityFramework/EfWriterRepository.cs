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
    public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
    {


        public List<Writer> GetListWithBook()
        {
            using (var c = new Context())
            {
                return c.Writers.Include(x => x.Books).ToList(); //kitap tablosuna ait degerler 
            }
        }

        public List<Book> GetListWithCategoryByWriterId(int id)
        {
            using (var c = new Context())
            {
                return c.Books.Include(x => x.Category).Where(x => x.WriterId == id).ToList(); ;
            }
        }
    }
}
