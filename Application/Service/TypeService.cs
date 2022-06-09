using Application.Repository;
using Application.ViewModels.Type;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TypeService
    {
        private readonly TypeRepository _typeRepository;
        public static TypeViewModel _type { get; set; }

        public TypeService(PokedexContext dbContext)
        {
            _typeRepository = new TypeRepository(dbContext);
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
    }
}
