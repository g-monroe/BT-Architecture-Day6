using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroBattle.DataAccessHandlers
{
    public class SuperheroHandler : ISuperheroHandler
    {
        private SuperheroBattleContext _dbContext;
        public SuperheroHandler(SuperheroBattleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Superhero> GetSuperheroes(Battle battle)
        {
            return _dbContext.Superheroes.Where(s => (s.SuperheroID == battle.AttackerID) ||
                                                        (s.SuperheroID == battle.DefenderID))
                                            .Include(s => s.SuperheroAbilities)
                                            .ThenInclude(sa => sa.Ability)
                                            .ToList();
        }
        public ActionResult<String> Seed()
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
        public ActionResult<IEnumerable<Superhero>> GetHeroes()
        {
            return _dbContext.Superheroes
                             .Include(s => s.SuperheroAbilities)
                             .ThenInclude(sa => sa.Ability).ToList();
        }
    }
}
