using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroBattle.BusinessLogic.Engines;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.Core.Managers;
using SuperheroBattle.DataAccessHandlers;

namespace SuperheroBattle.Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private IBattleManager _battleManager;
        public BattlesController(IBattleManager battleManager)
        {
            _battleManager = battleManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Superhero>> Get()
        {
            return _battleManager.Get();
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
            return _battleManager.Seed();
        }

        [HttpPost("fight")]
        public ActionResult<Battle> Fight([FromBody]Battle battle)
        {
            return Ok(_battleManager.Fight(battle));
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
