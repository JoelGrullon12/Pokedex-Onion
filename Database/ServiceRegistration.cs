using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PokedexContext>(options => options.UseInMemoryDatabase("PokedexDb"));
            }
            else
            {
                services.AddDbContext<PokedexContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("PokedexConnection"), 
                    m=>m.MigrationsAssembly(
                        typeof(PokedexContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            #endregion

        }
    }
}
