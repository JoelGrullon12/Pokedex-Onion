using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
