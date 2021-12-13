using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface  IBookService:IGenericService<Book>
    {
       
        List<Book> GetListWithCategory();
        List<Book> GetListWithCategoryByWriterId(int id);
        List<Book> GetListWithCategoryBookId(int id);
        List<Book> GetBookById(int id);
    }
}
