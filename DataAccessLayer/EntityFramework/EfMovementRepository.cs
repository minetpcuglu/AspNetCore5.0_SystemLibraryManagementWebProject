using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMovementRepository : GenericRepository<Movement>, IMovementDal
    {
        public List<Movement> GetListWithBook()
        {
            using (var c = new Context())
            {
                return c.Movements.Include(x => x.Book).ToList();
            }
        }
    }
}
