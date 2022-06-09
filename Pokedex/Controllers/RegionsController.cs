using Application.Enums;
using Application.Service;
using Application.ViewModels.Region;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {
        private readonly RegionService _regionService;



        public RegionsController(PokedexContext dbContext)
        {
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegionViewModel vm)
        {
            await _regionService.DML(vm, DMLAction.Add);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _regionService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionViewModel vm)
        {
            await _regionService.DML(vm, DMLAction.Edit);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionViewModel vm)
        {
            await _regionService.DML(vm, DMLAction.Delete);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }
    }
}
