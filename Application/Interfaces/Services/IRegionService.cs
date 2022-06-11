﻿using Pokedex.Core.Application.Enums;
using Pokedex.Core.Application.ViewModels.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<List<RegionViewModel>> GetAllViewModel();
        Task<RegionViewModel> GetByIdViewModel(int id);
        Task DML(RegionViewModel vm, DMLAction action);
    }
}
