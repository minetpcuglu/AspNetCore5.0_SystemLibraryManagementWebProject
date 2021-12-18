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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User t)
        {
            t.UserStatus = true;
            _userDal.insert(t);
        }

        public void Delete(User t)
        {
            t.UserStatus = false;
            _userDal.Delete(t);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll(x => x.UserStatus == true);
        }

        public List<User> GetUserById(int id)
        {
            return _userDal.GetListAll(x => x.UserId == id);
        }

        public void Update(User t)
        {
            t.UserStatus= true;
            _userDal.Update(t);
        }
    }
}
