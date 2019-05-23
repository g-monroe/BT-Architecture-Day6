using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperheroBattle.Core.Entities;

namespace SuperheroBattle.Core.Managers
{
    public interface IBattleManager
    {
        Task<Battle> Fight(Battle battle);

    }
}