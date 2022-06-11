using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Core.Application.ViewModels.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemon
{
    public class SavePokemonViewModel
    {
        public List<RegionViewModel> Regions { get; set; }
        public List<TypeViewModel> Types { get; set; }
        public PokemonViewModel Pokemon { get; set; }

    }
}
