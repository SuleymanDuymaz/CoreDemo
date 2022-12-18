using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace CoreDemo.Controllers
{

    public class NewsLetterController : Controller
    {

        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterDal());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.NewsLetterStatus = true;
            newsLetterManager.AddNewsLetterSubscriber(newsLetter);
            return PartialView();
        }
    }
}
