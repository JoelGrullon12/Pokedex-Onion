using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly PokedexContext _dbcontext;

        public GenericRepository(PokedexContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(T t)
        {
            await _dbcontext.Set<T>().AddAsync(t);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _dbcontext.Entry(t).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _dbcontext.Set<T>().Remove(t);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

    }
}
