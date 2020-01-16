using System;

namespace EURO
{
    public class Euro
    {
        public static string Winner(string fTeam, int fTeamGoals, string sTeam, int sTeamGoals)
        {
            if (fTeamGoals < 0 || sTeamGoals < 0) throw new ArgumentOutOfRangeException("Goals cannot be negative");
            if(fTeamGoals > sTeamGoals)
            {
                return fTeam;
            }
            else if (fTeamGoals < sTeamGoals)
            {
                return sTeam;
            }
            return "Draw";
        }
    }
}
