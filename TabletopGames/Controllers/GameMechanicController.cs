using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    public class GameMechanicController : Controller
    {
        private readonly TabletopGamesContext ctx;
        private readonly AppSettings appSettings;

        public GameMechanicController(TabletopGamesContext ctx, IOptionsSnapshot<AppSettings> options)
        {
            this.ctx = ctx;
            appSettings = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Tables = Output.Tables;

            var query = ctx.GameMechanic.AsNoTracking();

            query = query.ApplySort(1, true);

            var gameMechanics = await query
               .Select(p => new GameMechanicViewModel
               {
                   IdMechanic = p.IdMechanic,
                   NameMechanic = p.NameMechanic
               })
               .ToListAsync();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                Ascending = true,
                Sort = 1
            };

            var model = new GameMechanicsViewModel
            {
                GameMechanics = gameMechanics,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
    }
}
