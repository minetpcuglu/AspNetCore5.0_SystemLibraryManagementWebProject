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
        List<Book> GetBookByWriterId(int id);
        List<Book> GetListWithWriter(int id);  //Include metodu kullanımı için kitap göre listeleme
    }
}
