using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;

namespace SuperheroBattle.DataAccessHandlers
{
    public class SuperheroBattleContext : DbContext
    {
        public SuperheroBattleContext() : base()
        {
        }

        public SuperheroBattleContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<SuperheroAbility> SuperheroAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperheroAbility>().HasKey(sa => new { sa.SuperheroID, sa.AbilityID });

            modelBuilder.Entity<SuperheroAbility>()
                .HasOne<Superhero>(sc => sc.Superhero)
                .WithMany(s => s.SuperheroAbilities)
                .HasForeignKey(sa => sa.SuperheroID);

            modelBuilder.Entity<SuperheroAbility>()
                .HasOne<Ability>(sa => sa.Ability)
                .WithMany(a => a.SuperheroAbilities)
                .HasForeignKey(sa => sa.AbilityID);
        }
    }
}
