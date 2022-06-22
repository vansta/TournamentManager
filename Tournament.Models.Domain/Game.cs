using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Models.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int OutTeamId { get; set; }

        public int HomeScore { get; set; }
        public int OutScore { get; set; }

        public virtual Team? HomeTeam { get; set; }
        public virtual Team? OutTeam { get; set; }

        public virtual Round? Round { get; set; }

        public bool IsContestant(int id)
        {
            return id == HomeTeamId || id == OutTeamId;
        }
    }
}
