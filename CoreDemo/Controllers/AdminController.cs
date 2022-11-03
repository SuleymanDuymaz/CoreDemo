using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminDashboard()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbar()
        {

            return PartialView();
        }


    }
}
