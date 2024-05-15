using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;


namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> Get(string mail)
        {
            return _messageDal.List(p=>p.MessageReciever==mail);
        }
        public Message GetById(int id)
        {

            return _messageDal.GetById(id);
        }
        public void AddMessage(Message message)
        {
            _messageDal.Add(message);
        }

        public List<Message> SentMessages(string sender)
        {
            return _messageDal.List(p=>p.MessageSender==sender);
        }
    }
}
