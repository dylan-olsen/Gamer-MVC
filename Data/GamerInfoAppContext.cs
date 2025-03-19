using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamerInfoApp.Models;

namespace GamerInfoApp.Data
{
    public class GamerInfoAppContext : DbContext
    {
        public GamerInfoAppContext (DbContextOptions<GamerInfoAppContext> options)
            : base(options)
        {
        }

        public DbSet<GamerInfoApp.Models.Game> Game { get; set; } = default!;
        public DbSet<GamerInfoApp.Models.Gamer> Gamer { get; set; } = default!;
        public DbSet<GamerInfoApp.Models.Gameplay> Gameplay { get; set; } = default!;
    }
}
