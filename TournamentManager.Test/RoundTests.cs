using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TournamentManager.Managers;
using TournamentManager.Models.Domain;

namespace TournamentManager.Test
{
    [TestClass]
    public class RoundTests
    {
        static Team _team1 = new()
        {
            Id = 1,
            Name = "Team 1",
            AmountOfPlayers = 11
        };
        static List<Team> _teams = new List<Team>
            {
                _team1,
                new()
                {
                    Id = 2,
                    Name = "Team 2",
                    AmountOfPlayers = 13
                },
                new()
                {
                    Id = 3,
                    Name = "Team 3",
                    AmountOfPlayers = 11
                },
                new()
                {
                    Id = 4,
                    Name = "Team 4",
                    AmountOfPlayers = 13
                }
            };

        [TestMethod]
        public void AssertCorrectRoundCount()
        {
            var rounds = RoundsManager.CreateRounds(_teams, false);

            Assert.AreEqual(3, rounds.Count);
        }

        [TestMethod]
        public void AssertAllTeamsUniqueInRound()
        {
            var rounds = RoundsManager.CreateRounds(_teams, false);

            foreach (var round in rounds)
            {
                var teamsForRound = round.Games.Select(g => g.HomeTeamId).ToList();
                teamsForRound.AddRange(round.Games.Select(g => g.OutTeamId));
                var test = teamsForRound.GroupBy(t => t).Max(t => t.Select(g => g).Count());
                Assert.AreEqual(1, test);
            }
        }

        [TestMethod]
        public void AssertAllTeamsContained()
        {
            var rounds = RoundsManager.CreateRounds(_teams, false);
            var teams = rounds.SelectMany(r => r.Games).Select(g => g.HomeTeamId).ToList();
            teams.AddRange(rounds.SelectMany(r => r.Games).Select(g => g.OutTeamId));
            Assert.AreEqual(4, teams.Distinct().Count());
        }

        [TestMethod]
        public void AssertAllTeamsUnique()
        {
            var teams = _teams.Append(_team1).ToHashSet();
            void action() => RoundsManager.CreateRounds(teams, false);
            Assert.ThrowsException<ArgumentException>(action);
        }
    }
}