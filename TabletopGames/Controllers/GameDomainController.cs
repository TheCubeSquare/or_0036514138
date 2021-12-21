using Microsoft.AspNetCore.Mvc;
using TabletopGames.Models;
using TabletopGames.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Linq;
using TabletopGames.Extensions.Selectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabletopGames.Controllers
{
    public class GameDomainController : Controller
    {
        private readonly TabletopGamesContext ctx;
        private readonly AppSettings appSettings;

        public GameDomainController(TabletopGamesContext ctx, IOptionsSnapshot<AppSettings> options)
        {
            this.ctx = ctx;
            appSettings = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Tables = Output.Tables;

            var query = ctx.GameDomain.AsNoTracking();

            query = query.ApplySort(1, true);

            var gameDomains = await query
               .Select(p => new GameDomainViewModel
               {
                   IdDomain = p.IdDomain,
                   NameDomain = p.NameDomain
               })
               .ToListAsync();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                Ascending = true,
                Sort = 1
            };

            var model = new GameDomainsViewModel
            {
                GameDomains = gameDomains,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
    }
}
