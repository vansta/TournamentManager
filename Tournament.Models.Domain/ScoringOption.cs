using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Models.Domain
{
    public class ScoringOption
    {
        public ScoringOption()
        {
            Name = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
