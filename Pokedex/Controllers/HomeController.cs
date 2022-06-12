using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Service;
using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller { 
    
        private readonly IPokemonService _pokemonService;
        private readonly ITypeService _typeService;
        private readonly IRegionService _regionService;
        private readonly PokemonListViewModel _pokemonList;

        public HomeController(IPokemonService pokemonService, ITypeService typeService, IRegionService regionService)
        {
            _pokemonService = pokemonService;
            _typeService = typeService;
            _regionService = regionService;
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
                    if (!i.Name.ToLower().Contains(name.ToLower()))
                        _pokemonList.Pokemons.Remove(i);

                    ViewData["name"] = name;
                }
            }
            return View(_pokemonList);
        }
    }
}