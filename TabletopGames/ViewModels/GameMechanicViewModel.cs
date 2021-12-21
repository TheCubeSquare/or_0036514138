using System;
using TabletopGames.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TabletopGames.ViewModels
{
    public class GameMechanicViewModel
    {
        public int IdMechanic { get; set; }
        public string NameMechanic { get; set; }
    }
}
