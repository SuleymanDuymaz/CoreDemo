using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;
        

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult Inbox()
        {
            string username = User.Identity.Name;
            string usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerId = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.WriterID).FirstOrDefault();

            var values = messageManager.Get(usermail);

            return View(values);
        }
        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var sendermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == sendermail).Select(y => y.WriterID).FirstOrDefault();
            var values = messageManager.SentMessages(sendermail);

            return View(values);
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

            message.MessageSender = usermail;
            message.MessageDate = DateTime.Now;
            message.MessageStatus = true;
            messageManager.AddMessage(message);

            return RedirectToAction("Inbox");
            
        }


    }
}
