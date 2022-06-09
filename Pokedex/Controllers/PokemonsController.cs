using Application.Service;
using Application.Enums;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        //Services
        private readonly PokemonService _pokemonService;
        private readonly TypeService _typeService;
        private readonly RegionService _regionService;

        //ViewModels
        private readonly PokemonListViewModel _pokemonList;
        private readonly SavePokemonViewModel _savePokemon;

        public PokemonsController(PokedexContext dbContext)
        {
            _pokemonService = new(dbContext);
            _typeService = new(dbContext);
            _regionService = new(dbContext);
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
