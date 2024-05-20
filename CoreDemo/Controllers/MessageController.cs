using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        Context context = new Context();

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.Id).FirstOrDefault();


            var values = messageManager.Get(usermail);
            int messagecount = values.Count();
            ViewBag.count = messagecount;

            return View(values);
        }
        public IActionResult MessageDetail(int id)
        {
            Message value=messageManager.GetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult Compose()
        {

            return View();
        }
        [HttpPost]

        public IActionResult Compose(Message message)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            



            message.MessageDate = DateTime.Now;
            message.MessageSender = usermail;
            message.MessageStatus = true;

            messageManager.AddMessage(message);
            return RedirectToAction("Inbox");
        }
        public IActionResult SendBox()
        {

            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();

            List<Message> values = messageManager.SentMessages(usermail);
            return View(values);
        }


    }
}
