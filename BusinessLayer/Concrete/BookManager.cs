using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Add(Book t)
        {
            t.BookStatus = true;
            _bookDal.insert(t);
        }

        public void Delete(Book t)
        {
      

            t.BookStatus = false;
            _bookDal.Update(t);
        }

        public Book GetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public List<Book> GetList()
        {

            return _bookDal.GetAll();
        }

   

        public void Update(Book t)
        {
            t.BookStatus = true;
            _bookDal.Update(t);
        }

        public List<Book> GetBookByWriterId(int id)
        {
            return _bookDal.GetListAll(x => x.WriterId == id);
        }

        public List<Book> GetListWithCategory()
        {
            return _bookDal.GetListWithCategory();
        }


        public List<Book> GetBookById(int id)
        {
            return _bookDal.GetListAll(x => x.BookId == id);
        }

        public List<Book> GetListWithCategoryByWriterId(int id)
        {
            return _bookDal.GetListWithCategoryByWriterId(id);
        }

        public List<Book> GetListWithCategoryBookId(int id)
        {
            return _bookDal.GetListWithCategoryBookId(id);
        }
    }
}
