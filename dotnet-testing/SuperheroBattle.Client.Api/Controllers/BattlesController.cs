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
