using TabletopGames.Models;
using System;
using System.Linq;


namespace TabletopGames.Extensions.Selectors
{
    public static class GameMechanicsSort
    {
        public static IQueryable<GameMechanic> ApplySort(this IQueryable<GameMechanic> query, int sort, bool ascending)
        {
            System.Linq.Expressions.Expression<Func<GameMechanic, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = m => m.IdMechanic;
                    break;
                case 2:
                    orderSelector = m => m.NameMechanic;
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
