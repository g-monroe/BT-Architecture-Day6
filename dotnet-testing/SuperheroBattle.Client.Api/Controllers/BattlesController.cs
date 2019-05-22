using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.DataAccessHandlers;

namespace SuperheroBattle.Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private SuperheroBattleContext _dbContext;
        public BattlesController(SuperheroBattleContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Superhero>> Get()
        {
            return _dbContext.Superheroes
                             .Include(s => s.SuperheroAbilities)
                             .ThenInclude(sa => sa.Ability).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("seed")]
        public ActionResult<string> SeedInitialEntities()
        {
            try
            {
                SuperheroBattleInitializer.SeedData(_dbContext);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Success";
        }

        [HttpPost("fight")]
        public async Task<ActionResult<Battle>> Fight([FromBody]Battle battle)
        {
            var superheroes =
                await _dbContext.Superheroes.Where(s => (s.SuperheroID == battle.AttackerID) ||
                                                        (s.SuperheroID == battle.DefenderID))
                                            .Include(s => s.SuperheroAbilities)
                                            .ThenInclude(sa => sa.Ability)
                                            .ToListAsync();

            int firstSuperheroScore = superheroes[0].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[0].AbilityModifier;
            int secondSuperheroScore = superheroes[1].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[1].AbilityModifier;

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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
