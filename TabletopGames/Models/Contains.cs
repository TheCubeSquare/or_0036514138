using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopGames.Models
{
    public class Contains
    {
        public int IdGame { get; set; }
        public int IdMechanic { get; set; }

        public virtual TabletopGame IdGameNavigation { get; set; }
        public virtual GameMechanic IdMechanicNavigation { get; set; }
    }
}
