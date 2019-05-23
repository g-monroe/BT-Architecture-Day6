using Microsoft.AspNetCore.Mvc;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.Core.Managers;
using SuperheroBattle.DataAccessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperheroBattle.BusinessLogic.Engines;
using System.Diagnostics;

namespace SuperheroBattle.BusinessLogic.Engines
{
    public class BattleManager : IBattleManager
    {
        private ISuperheroHandler _superheroHandler;
        private IBattleEngine _battleEngine;
       public BattleManager(ISuperheroHandler superheroHandler, IBattleEngine battleEngine)
        {
            _battleEngine = battleEngine;
            _superheroHandler = superheroHandler;
        }
        public void ExampleUseCase()
        {
            throw new NotImplementedException();
        }
       
        public Battle Fight(Battle battle)
        {
            var superHeroes = _superheroHandler.GetSuperheroes(battle);
            Debug.WriteLine("Here");
            return _battleEngine.Fight(battle, superHeroes);
        }
        public ActionResult<IEnumerable<Superhero>> Get()
        {
            return _superheroHandler.GetHeroes();
        }
        public ActionResult<String> Seed()
        {
            return _superheroHandler.Seed();
        }
    }
}
