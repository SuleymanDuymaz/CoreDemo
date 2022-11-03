using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                CategoryCount = 10,
                CategoryName="teknoloji"
            }) ;
            list.Add(new CategoryClass
            {
                CategoryCount = 14,
                CategoryName = "yazılım"
            });
            list.Add(new CategoryClass
            {
                CategoryCount = 5,
                CategoryName = "spor"
            });


            return Json(new { jsonList = list });
        }
    }
}
