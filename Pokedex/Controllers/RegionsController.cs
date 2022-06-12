﻿using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Service;
using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
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
            if (!ModelState.IsValid)
                return View(vm);

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
            if (!ModelState.IsValid)
                return View(vm);

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
