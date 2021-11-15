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
            _bookDal.insert(t);
        }

        public void Delete(Book t)
        {
            _bookDal.Delete(t);
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
            _bookDal.Update(t);
        }
    }
}
