using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
    //[AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();

        public IActionResult Index()
        {
            List<Blog> values=blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var value = blogManager.GetBlogById(id);
            
            return View(value);
        }
        [HttpGet]
        public IActionResult Bloglarım()
        {
           
            //var value = blogManager.GetBlogListByWriter(1);
            // var value = blogManager.GetListWithCategoryByWriter(1);

            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();

            ViewBag.v1 = usermail;

            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.WriterID).FirstOrDefault();
            var value = blogManager.GetListWithCategoryByWriter(writerid);

            return View(value);
        }
        [HttpGet]
        public IActionResult NewBlog()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> valuecategory = (from p in categoryManager.GetAll()


                                                  select new SelectListItem
                                                  {
                                                      Text = p.CategoryName,
                                                      Value = p.CategoryID.ToString()
                                                  }
                                             ).ToList();
            ViewBag.valuecat = valuecategory;


            return View();
        }
        [HttpPost]
        public IActionResult NewBlog(Blog blog)
        {

            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.WriterID).FirstOrDefault();

            blog.BlogStatus = true; 
            blog.BlogThumbnailImage = "sd";
            blog.BlogImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq12Ao1igJHRtHMISM8atngBuBN_ordQS9tg&usqp=CAU";
            blog.BlogCreateDate= DateTime.Parse(DateTime.Now.ToString());
            blog.BlogStatus = true;
            
            blog.WriterID = writerid;  
            blogManager.AddBlog(blog);
            


            return RedirectToAction("Index");
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = blogManager.GetByID(id);
           blogManager.Delete(value);   
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var value = blogManager.GetByID(id);
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> valuecategory = (from p in categoryManager.GetAll()    


                                                  select new SelectListItem
                                                  {
                                                      Text = p.CategoryName,
                                                      Value = p.CategoryID.ToString()
                                                  }
                                             ).ToList();
            ViewBag.valuecat = valuecategory;

           
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.WriterID).FirstOrDefault();

           
            blog.WriterID = writerid;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.UpdateBlog(blog);
                
            return RedirectToAction("Bloglarım","Blog");
        }
    }
}
