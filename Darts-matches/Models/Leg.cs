using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    internal class Leg
    {
        private int _legNumber;
        private Player _winner;
        private List<Throw> _throws;
        private int _scorePlayerOne;
        private int _scorePlayerTwo;

        public int LegNumber { get => _legNumber; }
        public Player Winner { get => _winner; }
        public int ScorePlayerOne { get => _scorePlayerOne; }
        public int ScorePlayerTwo { get => _scorePlayerTwo; }

        public Leg(int legNumber)
        {
            _legNumber = legNumber;
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the set
            Player winner = null;
            _winner = winner;
        }

        public void addThrow(Player player)
        {
            _throws.Add(player.getLatestThrow());
        }

        public void calculateScoresPerPlayer()
        {
            // Logic to calculate score per player
            _scorePlayerOne = 0;
            _scorePlayerTwo = 0;
        }
    }
}
