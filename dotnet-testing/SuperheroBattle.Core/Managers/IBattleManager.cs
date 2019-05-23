using Microsoft.AspNetCore.Mvc;
using SuperheroBattle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.Core.Managers
{
    public interface IBattleManager
    {
        void ExampleUseCase();
        Battle Fight(Battle battle);
        ActionResult<IEnumerable<Superhero>> Get();
        ActionResult<String> Seed();
    }
}
