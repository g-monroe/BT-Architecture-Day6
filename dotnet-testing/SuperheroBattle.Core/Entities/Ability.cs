using System.Collections.Generic;

namespace SuperheroBattle.Core.Entities
{
    public class Ability
    {
        public int AbilityID { get; set; }
        public string Name { get; set; }
        public ICollection<Superhero> Superheroes { get; set; }

        public Ability()
        {
            Superheroes = new HashSet<Superhero>();
        }
    }
}
