using SuperheroBattle.Core.Entities;
using SuperheroBattle.Core.Managers;
using SuperheroBattle.DataAccessHandlers;
using System;
using SuperheroBattle.DataAccessHandlers.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SuperheroBattle.BusinessLogic.Managers
{
    public class BattleManager : IBattleManager
    {
        private ISuperheroHandler _superherohandler;

        public BattleManager(ISuperheroHandler superheroHandler)
        {
            this._superherohandler = superheroHandler;
        }

        public async Task<Battle> Fight(Battle battle)
        {
            var superheroes = await this._superherohandler.GetSuperheroes(new List<int> { battle.AttackerID, battle.DefenderID });

            int firstSuperheroScore = superheroes.ElementAt(0).SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes.ElementAt(0).AbilityModifier;
            int secondSuperheroScore;
            if (superheroes.Count() > 1)
            {
                secondSuperheroScore = superheroes.ElementAt(1).SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes.ElementAt(1).AbilityModifier;
            }
            else
            {
                secondSuperheroScore = firstSuperheroScore;
            }

            if (firstSuperheroScore > secondSuperheroScore)
            {
                battle.WinnerID = superheroes.ElementAt(0).SuperheroID;
            }
            else if (firstSuperheroScore < secondSuperheroScore)
            {
                battle.WinnerID = superheroes.ElementAt(1).SuperheroID;
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
