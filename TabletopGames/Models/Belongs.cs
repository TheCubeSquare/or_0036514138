using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopGames.Models
{
    public class Belongs
    {
        public int IdGame { get; set; }
        public int IdDomain { get; set; }

        public virtual TabletopGame IdGameNavigation { get; set; }
        public virtual GameDomain IdDomainNavigation { get; set; }
    }
}
