using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
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
            return PartialView();
        }
        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult EditProfile(int id)
        {
            Writer writervalue = writerManager.GetById(id);
            
            return View(writervalue);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditProfile(Writer writer)
        {
            writer.WriterStatus = true;

            writerManager.UpdateWriter(writer);
            return View();
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
