using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetInboxListByUser(int id); //kullanıyıca göre veri getirme
        List<Message> GetListInbox(string p); //şartlı listeleme
        List<Message> GetListSendbox(string p); //şartlı listeleme

    }
}
