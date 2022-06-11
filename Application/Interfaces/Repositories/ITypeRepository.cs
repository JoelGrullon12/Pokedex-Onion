﻿using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface ITypeRepository
    {
        Task AddAsync(PokemonType type);
        Task UpdateAsync(PokemonType type);
        Task DeleteAsync(PokemonType type);
        Task<List<PokemonType>> GetAllAsync();
        Task<PokemonType> GetByIdAsync(int id);
    }
}