using System;
using TabletopGames.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TabletopGames.ViewModels
{
    public class GameDomainViewModel
    {
        public int IdDomain { get; set; }
        public string NameDomain { get; set; }
    }
}
