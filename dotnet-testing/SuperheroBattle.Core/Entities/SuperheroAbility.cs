using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.Core.Entities
{
    public class SuperheroAbility
    {
        public int SuperheroID { get; set; }
        public Superhero Superhero { get; set; }

        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }
}
