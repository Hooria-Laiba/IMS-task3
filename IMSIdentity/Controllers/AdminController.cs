using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMSIdentity.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _pr;

        public AdminController(IProductRepository productRepo)
        {
            _pr = productRepo;
        }
        public IActionResult Add(string name, string brand, int quantity, decimal price, string type, string expiry, string barcode, string description)
        {
            Product product = new Product();
            product.Name = name;
            product.Brand = brand;
            product.Quantity = quantity;
            product.Price = price;
            product.Type = type;
            product.Expiry = expiry;
            product.Barcode = barcode;
            product.Description = description;
            _pr.Add(product);
            return RedirectToAction("Dash");
        }
        public IActionResult Edit(int id)
        {
            var product = _pr.GetById(id);
            return View(product);
        }
        public IActionResult Alert()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            var product = _pr.GetById(id);
            _pr.Delete(id);
            return View(product);
        }
        public IActionResult Dash()
        {
            return View();
        }
    }
}
