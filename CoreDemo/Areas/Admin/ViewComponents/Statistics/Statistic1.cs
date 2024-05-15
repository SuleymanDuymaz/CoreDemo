using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (Context context=new Context())
            {
                ViewBag.v1=context.Blogs.Count();
                ViewBag.v2 = 28;
                ViewBag.v3 = 47;
                ViewBag.v4 = context.Comments.Count();
                return View();
            }
          
        }
    }
}
