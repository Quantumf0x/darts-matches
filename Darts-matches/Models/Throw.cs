using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    internal class Throw
    {
        private Player _player;
        private Area _area;
        private int _number;
        private int _score;

        public Player Player { get => _player; }
        private int Score { get => _score; }

        public Throw(Player player, Area area, int number)
        {
            _player = player;
            _area = area;
            _number = number;
        }

        public void calculateScore()
        {
            // Logic to multiply area with number (triple 5 = 15 for example)
            _score = 0;
        }
    }
}
