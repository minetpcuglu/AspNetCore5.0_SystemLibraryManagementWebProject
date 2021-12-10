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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer t)
        {
            t.WriterStatus = true;
            _writerDal.insert(t);
        }

        

        public void Delete(Writer t)
        {
            t.WriterStatus = false;
            _writerDal.Update(t);
        }


        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

      
        public List<Writer> GetList()
        {
            return _writerDal.GetListAll(x => x.WriterStatus == true);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterId == id);
        }

        public List<Writer> GetWriterListWithBook()
        {
            return _writerDal.GetListWithBook();
        }

        public void Update(Writer t)
        {
            t.WriterStatus = true;
            _writerDal.Update(t);
        }
    }
}
