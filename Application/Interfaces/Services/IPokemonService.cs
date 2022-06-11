using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.ViewModels.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonViewModel>> GetAllViewModel();
        Task<PokemonViewModel> GetByIdViewModel(int id);
        Task DML(PokemonViewModel vm, DMLAction action);
    }
}
