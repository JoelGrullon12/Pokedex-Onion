using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.Service;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        //Services
        private readonly IPokemonService _pokemonService;
        private readonly ITypeService _typeService;
        private readonly IRegionService _regionService;

        //ViewModels
        private readonly PokemonListViewModel _pokemonList;
        private readonly SavePokemonViewModel _savePokemon;

        public PokemonsController(IPokemonService pokemonService, 
            ITypeService typeService, IRegionService regionService)
        {
            _pokemonService = pokemonService;
            _typeService = typeService;
            _regionService = regionService;
            _pokemonList = new();
            _savePokemon = new();
        }

        public async Task<IActionResult> Index()
        {
            _pokemonList.Pokemons = await _pokemonService.GetAllViewModel();
            _pokemonList.Types = await _typeService.GetAllViewModel();
            _pokemonList.Regions = await _regionService.GetAllViewModel();
            return View(_pokemonList);
        }

        public async Task<IActionResult> Create()
        {
            _savePokemon.Types = await _typeService.GetAllViewModel();
            _savePokemon.Regions = await _regionService.GetAllViewModel();
            return View(_savePokemon);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            await _pokemonService.DML(vm.Pokemon, DMLAction.Add);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            _savePokemon.Types = await _typeService.GetAllViewModel();
            _savePokemon.Regions = await _regionService.GetAllViewModel();
            _savePokemon.Pokemon = await _pokemonService.GetByIdViewModel(id);
            return View(_savePokemon);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            await _pokemonService.DML(vm.Pokemon, DMLAction.Edit);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            //_savePokemon.Types = await _typeService.GetAllViewModel();
            //_savePokemon.Regions = await _regionService.GetAllViewModel();
            //_savePokemon.Pokemon = await _pokemonService.GetByIdViewModel(id);
            return View(await _pokemonService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PokemonViewModel vm)
        {
            await _pokemonService.DML(vm, DMLAction.Delete);
            return RedirectToRoute(new { controller = "Pokemons", action = "Index" });
        }
    }
}
