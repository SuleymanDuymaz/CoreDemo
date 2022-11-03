using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.v3 = context.Blogs.Where(p => p.BlogCreateDate >= DateTime.Now.AddDays(-7)).Count();
           
         
            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(p => p.WriterID == 2).Count(); 
            return View();
        }
    }
}
