using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic3:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
