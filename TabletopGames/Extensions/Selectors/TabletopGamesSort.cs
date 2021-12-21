using TabletopGames.Models;
using System;
using System.Linq;


namespace TabletopGames.Extensions.Selectors
{
    public static class TabletopGamesSort
    {
        public static IQueryable<TabletopGame> ApplySort(this IQueryable<TabletopGame> query, int sort, bool ascending)
        {
            System.Linq.Expressions.Expression<Func<TabletopGame, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = m => m.IdGame;
                    break;
                case 2:
                    orderSelector = m => m.NameGame;
                    break;
                case 3:
                    orderSelector = m => m.YearGame;
                    break;
                case 4:
                    orderSelector = m => m.MinPlayers;
                    break;
                case 5:
                    orderSelector = m => m.MaxPlayers;
                    break;
                case 6:
                    orderSelector = m => m.AverageRating;
                    break;
                case 7:
                    orderSelector = m => m.AverageComplexity;
                    break;
                case 8:
                    orderSelector = m => m.PlayTime;
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
