using System.Collections.Generic;

namespace TabletopGames.ViewModels
{
    public class TabletopGamesViewModel
    {
        public IEnumerable<TabletopGameViewModel> TabletopGames { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
