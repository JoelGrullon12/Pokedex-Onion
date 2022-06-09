using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly PokedexContext _dbcontext;

        public PokemonRepository(PokedexContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbcontext.Pokemons.AddAsync(pokemon);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbcontext.Entry(pokemon).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbcontext.Set<Pokemon>().Remove(pokemon);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbcontext.Set<Pokemon>().ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Pokemon>().FindAsync(id);
        }
    }
}
