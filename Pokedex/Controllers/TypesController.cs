using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Service;
using Pokedex.Core.Application.ViewModels.Type;
using Pokedex.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _typeService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeViewModel vm)
        {
            await _typeService.DML(vm, DMLAction.Add);
            return RedirectToRoute(new { controller = "Types", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _typeService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TypeViewModel vm)
        {
            await _typeService.DML(vm, DMLAction.Edit);
            return RedirectToRoute(new { controller = "Types", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typeService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TypeViewModel vm)
        {
            await _typeService.DML(vm, DMLAction.Delete);
            return RedirectToRoute(new { controller = "Types", action = "Index" });
        }
    }
}
