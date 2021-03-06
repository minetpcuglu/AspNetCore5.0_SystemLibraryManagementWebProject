using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IBookDal:IGenericDal<Book>
    {
        List<Book> GetListWithCategory();
        List<Book> GetListWithCategoryBookId(int id);
        List<Book> GetListWithCategoryByWriterId(int id);

        //List<Book> GetBookByWriterId(int id);
    }
}
