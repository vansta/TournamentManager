using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Models.Domain
{
    public class Round
    {
        public Round()
        {
            Games = new HashSet<Game>();
        }
        public int Id { get; set; }
        public int Index { get; set; }

        public virtual Tournament? Tournament { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
