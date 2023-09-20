using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;

namespace PokemonAPI.Data
{
    public class PokemonAPIContext : DbContext
    {
        public PokemonAPIContext (DbContextOptions<PokemonAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonAPI.Models.Pokemon> Pokemon { get; set; } = default!;
        public DbSet<PokemonAPI.Models.Ability> Ability { get; set; } = default!;
        public DbSet<PokemonAPI.Models.PType> PType { get; set; } = default!;
    }
}
