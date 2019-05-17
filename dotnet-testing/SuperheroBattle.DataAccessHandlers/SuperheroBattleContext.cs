using SuperheroBattle.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SuperheroBattle.DataAccessHandlers
{
    public class SuperheroBattleContext : DbContext
    {

        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public SuperheroBattleContext() : base("SuperheroBattleContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
