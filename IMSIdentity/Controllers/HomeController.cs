using System.Diagnostics;
using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMSIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _pr;
        public HomeController(ILogger<HomeController> logger, IProductRepository productRepo)
        {
            _logger = logger;
            _pr = productRepo;
        }
        public IActionResult Catalogue()
        {
            var products = _pr.GetAll();
            return View(products);
        }

        public IActionResult Order()
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
