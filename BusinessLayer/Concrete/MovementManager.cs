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
    public class MovementManager : IMovementService
    {
        IMovementDal _movementDal;

        public MovementManager(IMovementDal movementDal)
        {
            _movementDal = movementDal;
        }

        public void Add(Movement t)
        {
            _movementDal.insert(t);
        }

        public void Delete(Movement t)
        {
            _movementDal.Delete(t);
        }

        public Movement GetById(int id)
        {
            return _movementDal.GetById(id);
        }

        public List<Movement> GetList()
        {
            return _movementDal.GetAll();
        }

        public void Update(Movement t)
        {
            _movementDal.Update(t);
        }
    }
}
