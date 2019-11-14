using Microsoft.AspNetCore.Mvc;

namespace RentalService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
