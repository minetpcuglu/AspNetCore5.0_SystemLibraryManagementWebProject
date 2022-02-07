using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message t)
        {
            _messageDal.insert(t);
        }

        public void Delete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x=>x.MessageId==id);
        }

        public List<Message> GetList()
        {
           return _messageDal.GetAll();
        }

        public void Update(Message t)
        {
            _messageDal.Update(t);
        }
        public List<Message> GetInboxListByUser(int id)  //alıcı mesaj
        {
            return _messageDal.GetListWithMessageByUser(id);
        }

    
    }
}
