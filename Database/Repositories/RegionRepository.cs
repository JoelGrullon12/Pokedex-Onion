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
    public class RegionRepository:IRegionRepository
    {
        private readonly PokedexContext _dbcontext;

        public RegionRepository(PokedexContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Region Region)
        {
            await _dbcontext.Regions.AddAsync(Region);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region Region)
        {
            _dbcontext.Entry(Region).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region Region)
        {
            _dbcontext.Set<Region>().Remove(Region);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbcontext.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Region>().FindAsync(id);
        }
    }
}
