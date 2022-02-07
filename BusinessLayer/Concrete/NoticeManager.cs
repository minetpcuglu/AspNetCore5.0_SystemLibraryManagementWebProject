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
   public class NoticeManager : INoticeService
    {
        INoticeDal _noticeDal;

        public NoticeManager(INoticeDal noticeDal)
        {
            _noticeDal = noticeDal;
        }

        public void Add(Notice t)
        {
           _noticeDal.insert(t);
        }

        public void Delete(Notice t)
        {
            _noticeDal.Delete(t);
        }

        public Notice GetById(int id)
        {
            return _noticeDal.GetById(id);
        }

        public List<Notice> GetList()
        {
            return _noticeDal.GetAll();
        }

        public void Update(Notice t)
        {
            _noticeDal.Update(t);
        }
    }
}
