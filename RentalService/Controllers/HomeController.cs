using Microsoft.AspNetCore.Mvc;

namespace RentalService.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
