using System.Collections.Generic;

namespace SuperheroBattle.Core.Entities
{
    public class Ability
    {
        public int AbilityID { get; set; }
        public string Name { get; set; }
        public IList<SuperheroAbility> SuperheroAbilities { get; set; }

        public Ability()
        {
            SuperheroAbilities = new List<SuperheroAbility>();
        }
    }
}
