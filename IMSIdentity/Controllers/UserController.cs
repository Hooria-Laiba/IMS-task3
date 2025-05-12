using IMSIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMSIdentity.Controllers
{
    public class UserController : Controller
    {
        private IProductRepository _ipr;
        public IActionResult Udash()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
