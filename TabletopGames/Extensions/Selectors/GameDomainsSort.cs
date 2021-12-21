using TabletopGames.Models;
using System;
using System.Linq;


namespace TabletopGames.Extensions.Selectors
{
    public static class GameDomainsSort
    {
        public static IQueryable<GameDomain> ApplySort(this IQueryable<GameDomain> query, int sort, bool ascending)
        {
            System.Linq.Expressions.Expression<Func<GameDomain, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = m => m.IdDomain;
                    break;
                case 2:
                    orderSelector = m => m.NameDomain;
                    break;
            }
            if (orderSelector != null)
            {
                query = ascending ?
                       query.OrderBy(orderSelector) :
                       query.OrderByDescending(orderSelector);
            }

            return query;
        }
    }
}
