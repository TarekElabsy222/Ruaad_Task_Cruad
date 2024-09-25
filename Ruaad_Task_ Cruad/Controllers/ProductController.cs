using Microsoft.AspNetCore.Mvc;
using Ruaad_Task__Cruad.Models;

namespace Ruaad_Task__Cruad.Controllers
{
    public class ProductController : Controller
    {
         
        public IActionResult Index()
        {
            var products = new ApplicationDbContext();
            var result = products.Products.ToList();
            return View(result);
        }
        public IActionResult Details(int id) { 
            var products = new ApplicationDbContext();
            var result = products.Products.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        public IActionResult Edit(int id)
        {
            var products = new ApplicationDbContext();
            var result = products.Products.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Product newProduct)
        {
            var products = new ApplicationDbContext();
            var result = products.Products.FirstOrDefault(p => p.Id == newProduct.Id);
            if (result != null)
            {
                result.Name = newProduct.Name;
                result.Description = newProduct.Description;
                result.Price = newProduct.Price;
                result.ImageUrl = newProduct.ImageUrl;

                products.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newProduct);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var products = new ApplicationDbContext();
            var result = products.Products.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                products.Products.Remove(result);
                products.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
