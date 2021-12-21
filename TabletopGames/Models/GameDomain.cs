using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopGames.Models
{
    public class GameDomain
    {
        public int IdDomain { get; set; }
        public string NameDomain { get; set; }

        public virtual ICollection<Belongs> Belongs { get; set; }
    }
}
