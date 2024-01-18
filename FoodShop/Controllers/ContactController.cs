using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
