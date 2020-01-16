using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEFA.Models
{
    public class Match
    {
        private int id;
        private string fTeam;
        private int fTeamGoals;
        private string sTeam;
        private int sTeamGoals;

        public int Id { get => id; set => id = value; }
        public string FTeam { get => fTeam; set => fTeam = value; }
        public int FTeamGoals { get => fTeamGoals; set => fTeamGoals = value; }
        public string STeam { get => sTeam; set => sTeam = value; }
        public int STeamGoals { get => sTeamGoals; set => sTeamGoals = value; }

        public Match()
        {

        }

        public Match(int id, string fTeam, int fTeamGoals, string sTeam, int sTeamGoals)
        {
            this.id = id;
            this.fTeam = fTeam;
            this.fTeamGoals = fTeamGoals;
            this.sTeam = sTeam;
            this.sTeamGoals = sTeamGoals;
        }
    }
}
