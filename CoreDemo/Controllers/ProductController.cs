using API.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44385/api/Product");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);

            return View(values);
        }

        public IActionResult AddProduct()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var httpClient = new HttpClient();
            var jsonProduct = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44385/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }

            return View();

        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44385/api/Product" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonProduct = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonProduct);

                return View(values);
            }
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonProduct = JsonConvert.SerializeObject(class1);
            var content = new StringContent(jsonProduct,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44385/api/Product",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44385/api/Product" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
    }
}
