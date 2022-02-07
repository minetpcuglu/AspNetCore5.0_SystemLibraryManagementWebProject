using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories.GenericRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfNoticeRepository:GenericRepository<Notice>,INoticeDal
    {
    }
}
