using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopGames.Models
{
    public class TabletopGame
    {
        public TabletopGame()
        {
            Belongs = new HashSet<Belongs>();
            Contains = new HashSet<Contains>();
        }

        public int IdGame { get; set; }
        public string NameGame { get; set; }
        public int YearGame { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public decimal AverageRating { get; set; }
        public decimal AverageComplexity { get; set; }
        public int PlayTime { get; set; }
        

        public virtual ICollection<Belongs> Belongs { get; set; }
        public virtual ICollection<Contains> Contains { get; set; }
    }
}
