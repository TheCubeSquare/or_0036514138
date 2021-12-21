using System;
using TabletopGames.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TabletopGames.ViewModels
{
    public class TabletopGameViewModel
    {
        public int IdGame { get; set; }

        public string NameGame { get; set; }

        public int YearGame { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public decimal AverageRating { get; set; }

        public decimal AverageComplexity { get; set; }

        public int PlayTime { get; set; }

        public ICollection<GameDomain> Domains { get; set; }

        public ICollection<GameMechanic> Mechanics { get; set; }
    }
}
