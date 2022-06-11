using Application.Service;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> Index(int region, string name)
        {
            _pokemonList.Pokemons = await _pokemonService.GetAllViewModel();
            _pokemonList.Types = await _typeService.GetAllViewModel();
            _pokemonList.Regions = await _regionService.GetAllViewModel();

            if (region != 0)
            {
                List<PokemonViewModel> pokemon = new(_pokemonList.Pokemons);
                foreach (PokemonViewModel i in pokemon)
                {
                    if (i.RegionId != region)
                        _pokemonList.Pokemons.Remove(i);

                    ViewData["region"] = region;
                }
            }

            if (name != null && name!="")
            {
                List<PokemonViewModel> pokemon = new(_pokemonList.Pokemons);
                foreach (PokemonViewModel i in pokemon)
                {
                    if (!i.Name.Contains(name))
                        _pokemonList.Pokemons.Remove(i);

                    ViewData["name"] = name;
                }
            }
            return View(_pokemonList);
        }
    }
}
