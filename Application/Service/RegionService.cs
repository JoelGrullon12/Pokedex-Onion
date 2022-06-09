using Application.Enums;
using Application.Repository;
using Application.ViewModels.Region;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(PokedexContext dbContext)
        {
            _regionRepository = new RegionRepository(dbContext);
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,
                Description = region.Description
            }).ToList();
        }

        public async Task<RegionViewModel> GetByIdViewModel(int id)
        {
            var regionList = await _regionRepository.GetByIdAsync(id);
            RegionViewModel Region = new();
            Region.Id = regionList.Id;
            Region.Name = regionList.Name;
            Region.Description = regionList.Description;
            return Region;
        }

        public async Task DML(RegionViewModel vm, DMLAction action)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;
            region.Description = vm.Description;

            if (action == DMLAction.Add)
            {
                await _regionRepository.AddAsync(region);
            }
            else if (action == DMLAction.Edit)
            {
                await _regionRepository.UpdateAsync(region);
            }
            else if (action == DMLAction.Delete)
            {
                await _regionRepository.DeleteAsync(region);
            }
        }
    }
}
