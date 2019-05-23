using SuperheroBattle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.BusinessLogic.Engines
{
    public interface IBattleEngine
    {
        Battle Fight(Battle battle, List<Superhero> superheroes);
    }
}
