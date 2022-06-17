﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
