using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> Types { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<PokemonType>().ToTable("Types");
            modelBuilder.Entity<Region>().ToTable("Regions");
            #endregion

            #region keys
            modelBuilder.Entity<Pokemon>().HasKey(pokemon => pokemon.Id);
            modelBuilder.Entity<PokemonType>().HasKey(type => type.Id);
            modelBuilder.Entity<Region>().HasKey(region => region.Id);
            #endregion

            #region relations
            //Primary Type
            modelBuilder.Entity<PokemonType>()
                .HasMany<Pokemon>(type => type.PrimPokemons)
                .WithOne(pokemon => pokemon.PrimTypes)
                .HasForeignKey(pokemon => pokemon.PrimaryType)
                .OnDelete(DeleteBehavior.Cascade);

            //Secondary Type
            modelBuilder.Entity<PokemonType>()
                .HasMany<Pokemon>(type => type.SecPokemons)
                .WithOne(pokemon => pokemon.SecTypes)
                .HasForeignKey(pokemon => pokemon.SecondaryType);

            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region property config

            #region pokemons
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.Name).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.Description).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.ImgUrl).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.PrimaryType).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.SecondaryType);
            modelBuilder.Entity<Pokemon>().Property(pokemon => pokemon.RegionId).IsRequired();
            #endregion

            #region types
            modelBuilder.Entity<PokemonType>().Property(pokemon => pokemon.Name).IsRequired();
            //modelBuilder.Entity<PokemonType>().Property(pokemon => pokemon.Description).IsRequired();
            //modelBuilder.Entity<PokemonType>().Property(pokemon => pokemon.ImgUrl).IsRequired();
            #endregion

            #region regions
            modelBuilder.Entity<Region>().Property(pokemon => pokemon.Name).IsRequired();
            modelBuilder.Entity<Region>().Property(pokemon => pokemon.Description).IsRequired();
            #endregion

            #endregion
        }
    }
}
