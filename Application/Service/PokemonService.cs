using Application.Enums;
using Application.Repository;
using Application.ViewModels.Pokemon;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonService(PokedexContext dbContext)
        {
            _pokemonRepository = new PokemonRepository(dbContext);
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Description = pokemon.Description,
                PrimaryTypeId = pokemon.PrimaryType,
                SecondaryTypeId = pokemon.SecondaryType,
                RegionId = pokemon.RegionId,
                ImgUrl = pokemon.ImgUrl
            }).ToList();
        }

        public async Task<PokemonViewModel> GetByIdViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            PokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.Description = pokemon.Description;
            vm.PrimaryTypeId = pokemon.PrimaryType;
            vm.SecondaryTypeId = pokemon.SecondaryType;
            vm.RegionId = pokemon.RegionId;
            vm.ImgUrl = pokemon.ImgUrl;
            return vm;
        }

        public async Task DML(PokemonViewModel vm, DMLAction action)
        {
            Pokemon pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Name = vm.Name;
            pokemon.Description = vm.Description;
            pokemon.PrimaryType = vm.PrimaryTypeId;
            pokemon.SecondaryType = vm.SecondaryTypeId == 0 ? vm.PrimaryTypeId : vm.SecondaryTypeId;
            pokemon.RegionId = vm.RegionId;
            pokemon.ImgUrl = vm.ImgUrl;

            if (action == DMLAction.Add)
            {
                await _pokemonRepository.AddAsync(pokemon);
            }
            else if (action == DMLAction.Edit)
            {
                await _pokemonRepository.UpdateAsync(pokemon);
            }
            else if (action == DMLAction.Delete)
            {
                await _pokemonRepository.DeleteAsync(pokemon);
            }
        }
    }
}
