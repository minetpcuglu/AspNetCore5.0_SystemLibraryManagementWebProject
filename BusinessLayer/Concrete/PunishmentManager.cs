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
    public class PunishmentManager : IPunishmentService
    {
        IPunishmentDal _punishmentDal;

        public PunishmentManager(IPunishmentDal punishmentDal)
        {
            _punishmentDal = punishmentDal;
        }

        public void Add(Punishment t)
        {
            _punishmentDal.insert(t);
        }

        public void Delete(Punishment t)
        {
            _punishmentDal.Delete(t);
        }

        public Punishment GetById(int id)
        {
            return _punishmentDal.GetById(id);
        }

        public List<Punishment> GetList()
        {
            return _punishmentDal.GetAll();
        }

        public void Update(Punishment t)
        {
            _punishmentDal.Update(t);
        }
    }
}
