using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TypeRepository : GenericRepository<PokemonType>, ITypeRepository
    {
        private readonly PokedexContext _dbcontext;

        public TypeRepository(PokedexContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
