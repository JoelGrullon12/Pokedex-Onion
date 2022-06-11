using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TypeRepository:ITypeRepository
    {
        private readonly PokedexContext _dbcontext;

        public TypeRepository(PokedexContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(PokemonType type)
        {
            await _dbcontext.Types.AddAsync(type);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PokemonType type)
        {
            _dbcontext.Entry(type).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PokemonType type)
        {
            _dbcontext.Set<PokemonType>().Remove(type);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<PokemonType>> GetAllAsync()
        {
            return await _dbcontext.Set<PokemonType>().ToListAsync();
        }

        public async Task<PokemonType> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<PokemonType>().FindAsync(id);
        }
    }
}
