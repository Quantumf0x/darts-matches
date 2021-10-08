using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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

        public void SetNameAndDate(string name, DateTime date)
        {
            _match = new Match(name, date);
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
