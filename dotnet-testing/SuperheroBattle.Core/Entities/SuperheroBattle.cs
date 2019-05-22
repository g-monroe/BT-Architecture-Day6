using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.Core.Entities
{
    public class Battle
    {
        public int AttackerID { get; set; }

        public int DefenderID { get; set; }

        public int? WinnerID { get; set; }

        public bool HasBattled
        {
            get
            {
                return WinnerID.HasValue;
            }
        }
    }
}
