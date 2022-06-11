using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class PokemonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        //public string ImgUrl { get; set; }

        //Navigation Property
        public ICollection<Pokemon> PrimPokemons { get; set; }
        public ICollection<Pokemon> SecPokemons { get; set; }
    }
}
