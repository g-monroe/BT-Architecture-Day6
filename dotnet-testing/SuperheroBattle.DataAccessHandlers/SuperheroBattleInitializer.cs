using SuperheroBattle.Core;
using System.Collections.Generic;
using System.Data.Entity;

namespace SuperheroBattle.DataAccessHandlers
{
    public class SuperheroBattleInitializer : DropCreateDatabaseIfModelChanges<SuperheroBattleContext>
    {
        protected override void Seed(SuperheroBattleContext context)
        {
            var superheroes = new List<Superhero>()
            {
                new Superhero { SuperheroName="Spider-Man", SecretIdentity="Peter Parker",  }
            };
            context.Superheroes.AddRange(superheroes);
            context.SaveChanges();
        }
    }
}