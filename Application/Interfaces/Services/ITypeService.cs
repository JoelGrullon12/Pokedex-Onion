using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.ViewModels.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface ITypeService
    {
        Task<List<TypeViewModel>> GetAllViewModel();
        Task<TypeViewModel> GetByIdViewModel(int id);
        Task DML(TypeViewModel vm, DMLAction action);
    }
}
