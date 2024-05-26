using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{

    public class WriterController : Controller
    {
     
        public IActionResult FotoGor()
        {


            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterLogin()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();

        }
    
        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }
        [HttpGet]
   
        public async Task<IActionResult> EditProfile()
        {
            //IDENTITY LANINA GORE CALISIR DURUMDA GUNCEL

            //İLK YOL 


            //Context context = new Context();
            //UserManager userManager = new UserManager(new EfUserDal());
            //var username = User.Identity.Name;
            //var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            //var id = context.Users.Where(p => p.Email == usermail).Select(k => k.Id).FirstOrDefault();
            //var values = userManager.GetById(id);
            //return View(values);


            //İLK YOL 


           


            return View();



        }
        [HttpPost]
        
        public  async Task<IActionResult> EditProfile(AppUser appUser)
        {

         
           
            //values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, appUser.PasswordHash);
            //password change
         
            return RedirectToAction("Index","Dashboard");
           
            
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddWriter()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddWriter(AddProfileImage addProfileImage)
        {

        
            return View();
        }
    }
}
