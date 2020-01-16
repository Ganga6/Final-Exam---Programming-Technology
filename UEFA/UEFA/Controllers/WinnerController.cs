using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EURO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UEFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetWinner(int id)
        {
            var match = MatchController.matchlist.Find(x => x.Id == id);
            return Euro.Winner(match.FTeam, match.FTeamGoals, match.STeam, match.STeamGoals);
        }
    }
}