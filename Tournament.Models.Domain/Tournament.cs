namespace TournamentManager.Models.Domain
{
    public class Tournament
    {
        public Tournament()
        {
            Name = string.Empty;
            Teams = new HashSet<Team>();
            ScoringOptions = new HashSet<ScoringOption>();
            Rounds = new HashSet<Round>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int MinutesPerGame { get; set; }
        public int AmountOfBreaks { get; set; }
        public int BreakLength { get; set; }
        public bool HomeAndReturn { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public ICollection<ScoringOption> ScoringOptions { get; set; }
    }
}