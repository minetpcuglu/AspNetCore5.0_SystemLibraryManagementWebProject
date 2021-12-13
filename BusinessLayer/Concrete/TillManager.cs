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
    public class TillManager : ITillService
    {
        ITillDal _tillDal;

        public TillManager(ITillDal tillDal)
        {
            _tillDal = tillDal;
        }

        public void Add(Till t)
        {
            _tillDal.insert(t);
        }

        public void Delete(Till t)
        {
            _tillDal.Delete(t);
        }

        public Till GetById(int id)
        {
          return  _tillDal.GetById(id);
        }

        public List<Till> GetList()
        {
            return _tillDal.GetAll();
        }


      

        public void Update(Till t)
        {
            _tillDal.Update(t);
        }
    }
}
