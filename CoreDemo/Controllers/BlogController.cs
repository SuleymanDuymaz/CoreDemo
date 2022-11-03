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

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Blog> values=blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [HttpGet]
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
            var value = blogManager.GetListWithCategoryByWriter(1);
            
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
            blog.BlogStatus = true; 
            blog.BlogThumbnailImage = "sd";
            blog.BlogImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq12Ao1igJHRtHMISM8atngBuBN_ordQS9tg&usqp=CAU";
            blog.BlogCreateDate= DateTime.Parse(DateTime.Now.ToString());
            blog.BlogStatus = true;
            
            blog.WriterID = 1;  
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
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> valuecategory = (from p in categoryManager.GetAll()    


                                                  select new SelectListItem
                                                  {
                                                      Text = p.CategoryName,
                                                      Value = p.CategoryID.ToString()
                                                  }
                                             ).ToList();
            ViewBag.valuecat = valuecategory;

            var value=blogManager.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {

            blog.BlogStatus = true;
            blog.BlogThumbnailImage = "Django";
            blog.BlogImage = "https://www.djangoproject.com/m/img/logos/django-logo-negative.png";
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToString());
            blog.BlogStatus = true;

            blog.WriterID = 2;
            return View();
        }
    }
}
