using System.Collections.Generic;

namespace Darts_matches.Models
{
    public class Leg
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

        // TODO: add logic to calculate the winner of the set
        public void CalculateWinner()
        {
            Player winner = null;
            _winner = winner;
        }

        public void AddThrow(Player player)
        {
            _throws.Add(player.GetLatestThrow());
        }

        // TODO: add logic to calculate score per player
        public void CalculateScoresPerPlayer()
        {
            _scorePlayerOne = 0;
            _scorePlayerTwo = 0;
        }
    }
}
