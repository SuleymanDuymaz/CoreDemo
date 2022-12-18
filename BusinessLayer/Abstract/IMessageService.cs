using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> Get(string mail);
        public void AddMessage(Message message);
        List<Message> SentMessages(string sender);
    }
}
