using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMovementDal:IGenericDal<Movement>
    {

        //List<Movement> GetListWithBookName(int id);
        List<Movement> GetListWithBookName();
    }
}
