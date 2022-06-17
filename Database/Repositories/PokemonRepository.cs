using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Infrastructure.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository: GenericRepository<Pokemon>,IPokemonRepository
    {
        private readonly PokedexContext _dbcontext;

        public PokemonRepository(PokedexContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
