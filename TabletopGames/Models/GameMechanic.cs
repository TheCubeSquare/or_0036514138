using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopGames.Models
{
    public class GameMechanic
    {
        public int IdMechanic { get; set; }
        public string NameMechanic { get; set; }

        public virtual ICollection<Contains> Contains { get; set; }
    }
}
