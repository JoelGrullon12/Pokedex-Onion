using Application.Service;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller { 
    
        private readonly PokemonService _pokemonService;
        private readonly TypeService _typeService;
        private readonly RegionService _regionService;
        private readonly PokemonListViewModel _pokemonList;

        public HomeController(PokedexContext dbContext)
        {
            _pokemonService = new(dbContext);
            _typeService = new(dbContext);
            _regionService = new(dbContext);
            _pokemonList = new();
        }

        public async Task<IActionResult> Index()
        {
            _pokemonList.Pokemons = await _pokemonService.GetAllViewModel();
            _pokemonList.Types = await _typeService.GetAllViewModel();
            _pokemonList.Regions = await _regionService.GetAllViewModel();
            return View(_pokemonList);
        }
    }
}
