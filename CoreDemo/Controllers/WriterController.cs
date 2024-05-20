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
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult FotoGor()
        {
            var value=writerManager.GetAll();

            return View(value);
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
        public PartialViewResult WriterNavbarPartial()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(p => p.UserName == username).Select(k => k.Email).FirstOrDefault();
            var writerid = context.Writers.Where(p => p.WriterMail == usermail).Select(k => k.Id).FirstOrDefault();

            ViewBag.name = username;
            return PartialView();
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


            var values = await _userManager.FindByNameAsync(User.Identity.Name);


            return View(values);



        }
        [HttpPost]
        
        public  async Task<IActionResult> EditProfile(AppUser appUser)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Name = appUser.Name;
            values.Email = appUser.Email;
            values.UserName = appUser.UserName;

           
            //values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, appUser.PasswordHash);
            //password change
            var result = await _userManager.UpdateAsync(values);
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
            Writer writer = new Writer();
            if (addProfileImage.WriterImage!=null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;

            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterStatus = true;
            writerManager.AddWriter(writer);
            return View();
        }
    }
}
