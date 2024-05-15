using API.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult ProductList()
        {
            using Context context = new Context();
            var values = context.Products.ToList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            using Context context = new Context();
            context.Add(product);
            context.SaveChanges();

            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using Context context = new Context();
            Product value = context.Products.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
          
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using Context context = new Context();
            Product value = context.Products.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(value);
                context.SaveChanges();
                return Ok();

            }

        }
        [HttpPut]
        public IActionResult Delete(Product product)
        {
            using Context context = new Context();
            Product value = context.Find<Product>(product.ID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Name = product.Name;
                context.Update(value);
                context.SaveChanges();
                return Ok();

            }

        }
    }
}
