using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
