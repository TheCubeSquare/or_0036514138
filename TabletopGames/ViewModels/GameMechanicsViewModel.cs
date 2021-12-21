using System.Collections.Generic;

namespace TabletopGames.ViewModels
{
    public class GameMechanicsViewModel
    {
        public IEnumerable<GameMechanicViewModel> GameMechanics{ get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
