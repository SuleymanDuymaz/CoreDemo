using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        //[AllowAnonymous]
        
        public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.WriterID).FirstOrDefault();



            ViewBag.v5 = usermail;
            ViewBag.v4 = username;
            ViewBag.v3 = context.Blogs.Where(p => p.BlogCreateDate >= DateTime.Now.AddDays(-7)).Count();

            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(p => p.WriterID == writerid).Count(); 
            return View();
        }
    }
}
