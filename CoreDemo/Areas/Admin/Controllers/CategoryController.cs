using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using X.PagedList;
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using System.IO;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page = 1)
        {
            var value = categoryManager.GetAll().ToPagedList(page, 10);


            return View(value);
        }
        [HttpGet]

        public IActionResult CategoryAdd()
        {
            return View();
        }
        public IActionResult CategoryAdd(Category category)
        {
            categoryManager.AddCategory(category);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            Category value = categoryManager.GetByID(id);
            categoryManager.Delete(value);


            return RedirectToAction("Index");
        }
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kategori Listesi");
                worksheet.Cell(1, 1).Value = "Kategori ID";
                worksheet.Cell(1, 2).Value = "Kategori Adı ";
                int BlogRowCount = 2;

                List<Category1> values = new List<Category1>()
            {
                 new Category1{ID=1,Name="Badminton"},
                 new Category1 { ID = 2, Name = "Basket" },
                 new Category1 { ID = 3, Name = "Top" }

            };


                foreach (var item in values)
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Name;
                    BlogRowCount++;
                }
                using (var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxlmformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }
                            

            }
          

      
         
            
        }
      
        public IActionResult ListExcel()
        {

            return View();
        }

    }
    
}
