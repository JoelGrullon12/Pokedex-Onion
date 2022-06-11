using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface IRegionRepository
    {
        Task AddAsync(Region Region);
        Task UpdateAsync(Region Region);
        Task DeleteAsync(Region Region);
        Task<List<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(int id);
    }
}
