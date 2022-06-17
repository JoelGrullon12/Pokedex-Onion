using Pokedex.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IGenericService<VM,Action> 
        where VM : class
        where Action:Enum
    {
        Task<List<VM>> GetAllViewModel();
        Task<VM> GetByIdViewModel(int id);
        Task DML(VM vm, DMLAction action);
    }
}
