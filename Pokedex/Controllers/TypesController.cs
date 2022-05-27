using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class TypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
