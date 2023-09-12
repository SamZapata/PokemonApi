using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace PokemonAPI.Data
{
    public class PokemonAPIContext : DbContext
    {
        public PokemonAPIContext (DbContextOptions<PokemonAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Pokemon> Pokemon { get; set; } = default!;
    }
}
