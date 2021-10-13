using System;
using Darts_matches.Models;

namespace Darts_matches.Controllers
{
    public class MatchController
    {
        private static MatchController _instance;
        private Match _match;

        public static MatchController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MatchController();
                }
                return _instance;
            }
        }

        public void CreateMatchAndSetInputs(string name, DateTime date, int pointsPerLeg, int numberOfLegsPerSet, int numberOfSets)
        {
            _match = new Match();
            _match.Name = name;
            _match.Date = date;
            _match.PointsPerLeg = pointsPerLeg;
            _match.NumberOfSets = numberOfSets;
            _match.NumberOfLegsPerSet = numberOfLegsPerSet;
        }

        public void SetSetsAndLegs(int numberOfSets, int numberOfLegsPerSet)
        {
            _match.NumberOfSets = numberOfSets;
            _match.NumberOfLegsPerSet = numberOfLegsPerSet;
        }

        public void SetPlayersAndNotes(string namePlayerOne, string namePlayerTwo, string notes)
        {
            Player playerOne = new Player(namePlayerOne);
            Player playerTwo = new Player(namePlayerTwo);
            _match.PlayerOne = playerOne;
            _match.PlayerTwo = playerTwo;
            _match.Notes = notes;
        }
    }
}
