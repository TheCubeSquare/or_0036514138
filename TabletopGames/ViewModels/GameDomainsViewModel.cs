using System.Collections.Generic;

namespace TabletopGames.ViewModels
{
    public class GameDomainsViewModel
    {
        public IEnumerable<GameDomainViewModel> GameDomains { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
