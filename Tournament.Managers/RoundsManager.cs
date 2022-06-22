using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Models.Domain;

namespace TournamentManager.Managers
{
    public class RoundsManager
    {
        public static IList<Round> CreateRounds(ICollection<Team> teams, bool homeAndReturn = false)
        {
            if (!CheckIfTeamsAreUnique(teams))
            {
                throw new ArgumentException("Teams are not unique");
            }
            var rounds = CreateRounds(teams);
            if (homeAndReturn)
            {
                rounds.AddRange(CreateRounds(teams));
            }

            return rounds;
        }

        private static List<Round> CreateRounds(ICollection<Team> teams)
        {
            int amountOfRound = teams.Count - 1;
            List<Round> rounds = Enumerable.Repeat(new Round(), amountOfRound).ToList();

            int index = 0;
            Dictionary<int, int> games = new();
            foreach (Round round in rounds)
            {
                round.Index = index++;
                foreach (var team in teams)
                {
                    if (!round.Games.Any(g => g.IsContestant(team.Id)))
                    {
                        int rivalId = teams
                            .First(t =>
                                t.Id != team.Id
                                && !round.Games.Any(g => g.IsContestant(t.Id))
                                && !games.Any(g => g.Key == team.Id && g.Value == t.Id)
                                ).Id;

                        round.Games.Add(new Game
                        {
                            HomeTeamId = team.Id,
                            OutTeamId = rivalId
                        });
                        games.Add(team.Id, rivalId);
                    }
                }
            }

            return rounds;
        }

        private static bool CheckIfTeamsAreUnique(ICollection<Team> teams)
        {
            var test = teams.Distinct();
            return teams.Distinct().Count() == teams.Count;
        }
    }
}
