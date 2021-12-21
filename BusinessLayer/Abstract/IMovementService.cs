using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMovementService:IGenericService<Movement>
    {
        List<Movement> GetListWithBook();
        List<Movement> GetListWith(int id);
        //List<Movement> GetMovementListByBook(int id);
        //List<Movement> GetListWithBookName(int id);

    }
}
