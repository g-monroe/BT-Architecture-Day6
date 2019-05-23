using SuperheroBattle.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperheroBattle.DataAccessHandlers.Handlers
{
    public interface ISuperheroHandler
    {
        Task<List<Superhero>> GetSuperheroes(List<int> superheroIDs);
    }
}