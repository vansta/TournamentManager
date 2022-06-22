using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Models.Domain
{
    public class Team
    {
        public Team()
        {
            Name = string.Empty;
            Games = new HashSet<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int AmountOfPlayers { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
