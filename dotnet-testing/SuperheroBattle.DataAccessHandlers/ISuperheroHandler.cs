using Microsoft.AspNetCore.Mvc;
using SuperheroBattle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.DataAccessHandlers
{
    public interface ISuperheroHandler
    {
       List<Superhero> GetSuperheroes(Battle battle);
       ActionResult<String> Seed();
        ActionResult<IEnumerable<Superhero>> GetHeroes();
    }
}
