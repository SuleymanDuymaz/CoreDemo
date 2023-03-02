using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(UserSingInViewModel userSignİnViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignİnViewModel.UserName, userSignİnViewModel.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                
            }
            return View(userSignİnViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }





        //////OLD LOGİN
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        ////bir yol daha var 47 de 
        //[HttpPost]
        //public IActionResult Index(Writer writer)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Writers.FirstOrDefault(p=>p.WriterMail==writer.WriterMail && p.WriterPassword==writer.WriterPassword);

        //    if (datavalue!=null)
        //    {
        //        HttpContext.Session.SetString("username", writer.WriterMail);
        //        HttpContext.Session.SetString("passwword", writer.WriterPassword);

        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}
        public IActionResult AccesDenied()
        {
            return View();
        }

    }
}
