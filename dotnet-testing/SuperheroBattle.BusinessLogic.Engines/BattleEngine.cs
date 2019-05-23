using Microsoft.AspNetCore.Mvc;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.Core.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace SuperheroBattle.BusinessLogic.Engines
{
    public class BattleEngine : IBattleEngine
    {

        public Battle Fight(Battle battle, List<Superhero> superheroes)
        {
            Debug.WriteLine(superheroes.ToString());
            int firstSuperheroScore = superheroes[0].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[0].AbilityModifier;
            int secondSuperheroScore;
            if (superheroes.Count > 1)
            {
                secondSuperheroScore = superheroes[1].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[1].AbilityModifier;
            }
            else
            {
                secondSuperheroScore = firstSuperheroScore;
            }

            if (firstSuperheroScore > secondSuperheroScore)
            {
                battle.WinnerID = superheroes[0].SuperheroID;
            }
            else if (firstSuperheroScore < secondSuperheroScore)
            {
                battle.WinnerID = superheroes[1].SuperheroID;
            }
            else
            {
                // Returning null indicates a draw.
                battle.WinnerID = null;
            }

            return battle;
        }
    }
}
