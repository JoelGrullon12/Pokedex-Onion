using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Type;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Service
{
    public class TypeService: ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        public static TypeViewModel _type { get; set; }

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<List<TypeViewModel>> GetAllViewModel()
        {
            var typeList = await _typeRepository.GetAllAsync();
            return typeList.Select(type => new TypeViewModel
            {
                Id = type.Id,
                Name = type.Name
            }).ToList();
        }

        public async Task<TypeViewModel> GetByIdViewModel(int id)
        {
            var typeList = await _typeRepository.GetByIdAsync(id);
            TypeViewModel type = new();
            type.Id = typeList.Id;
            type.Name = typeList.Name;
            return type;
        }

        public async Task DML(TypeViewModel vm, DMLAction action)
        {
            PokemonType type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;

            if (action == DMLAction.Add)
            {
                await _typeRepository.AddAsync(type);
            }
            else if (action == DMLAction.Edit)
            {
                await _typeRepository.UpdateAsync(type);
            }
            else if (action == DMLAction.Delete)
            {
                await _typeRepository.DeleteAsync(type);
            }
        }
    }
}
