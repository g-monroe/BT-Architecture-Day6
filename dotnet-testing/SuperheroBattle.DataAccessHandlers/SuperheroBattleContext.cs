using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;

namespace SuperheroBattle.DataAccessHandlers
{
    public class SuperheroBattleContext : DbContext
    {
        public SuperheroBattleContext(): base()
        {
        }

        public SuperheroBattleContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Ability> Abilities { get; set; }
    }
}
