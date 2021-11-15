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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Add(Employee t)
        {
            _employeeDal.insert(t);
        }

        public void Delete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> GetList()
        {
          return  _employeeDal.GetAll();
        }

        public void Update(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
