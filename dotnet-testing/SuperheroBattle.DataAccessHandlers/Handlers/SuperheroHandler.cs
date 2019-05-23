using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;

namespace SuperheroBattle.DataAccessHandlers.Handlers
{
    public class SuperheroHandler : ISuperheroHandler
    {
        private SuperheroBattleContext _context;
        public SuperheroHandler(SuperheroBattleContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Superhero>> GetSuperheroes(IEnumerable<int> superheroIDs)
        {
            return await _context.Superheroes.Where(s => (superheroIDs.Contains(s.SuperheroID)))
                                 .Include(s => s.SuperheroAbilities)
                                 .ThenInclude(sa => sa.Ability).ToListAsync();
            
        }
    }
}
