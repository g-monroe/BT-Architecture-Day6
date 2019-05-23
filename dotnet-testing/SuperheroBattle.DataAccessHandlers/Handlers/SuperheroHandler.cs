using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperheroBattle.Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuperheroBattle.DataAccessHandlers.Handlers
{
    public class SuperheroHandler : ISuperheroHandler
    {
        private SuperheroBattleContext _context;
        public SuperheroHandler(SuperheroBattleContext context)
        {
            _context = context;
        }

        public async Task<List<Superhero>> GetSuperheroes(List<int> superheroIDs)
        {
            return await _context.Superheroes.Where(s => (superheroIDs.Contains(s.SuperheroID)))
                                .Include(s => s.SuperheroAbilities)
                                .ThenInclude(sa => sa.Ability)
                                .ToListAsync();
        }
    }
}
