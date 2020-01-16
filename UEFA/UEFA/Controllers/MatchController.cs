using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UEFA.Models;


namespace UEFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        public static List<Match> matchlist = new List<Match>
        { 
            new Match(1, "Den", 5, "USA", 2),
            new Match(2, "SVK", 3, "CAN", 4),
            new Match(3, "UK", 1, "Den", 6),
            new Match(4, "HUN", 5, "Fin", 2)
        };
        // GET: api/Match
        [HttpGet]
        public IEnumerable<Match> GetAllMatches()
        {
            return matchlist;
        }

        // GET: api/Match/5
        [HttpGet("{id}", Name = "Get")]
        public Match GetMatch(int id)
        {
            return matchlist.Find(x => x.Id == id);
        }

        // POST: api/Match
        [HttpPost]
        public void AddMatch([FromBody] Match value)
        {
            value.Id = matchlist.Count() + 1;
            matchlist.Add(value);
        }
    }
}
