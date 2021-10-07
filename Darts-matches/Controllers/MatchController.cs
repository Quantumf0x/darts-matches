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

        public void SetMatchInputPageValues(string name, DateTime date)
        {
            _match = new Match(name, date);
        }

        public void SetPlayers(string namePlayerOne, string namePlayerTwo)
        {
            Player playerOne = new Player(namePlayerOne);
            Player playerTwo = new Player(namePlayerTwo);
            _match.PlayerOne = playerOne;
            _match.PlayerTwo = playerTwo;
        }
    }
}
