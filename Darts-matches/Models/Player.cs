using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    internal class Player
    {
        private string _name;
        private List<Throw> _throws;
        private int _averagePerSet;
        private int _averagePerLeg;
        private int _numberOfMaxScores;

        public string Name { get => _name; }
        public int AveragePerSet { get => _averagePerSet; }
        public int AveragePerLeg { get => _averagePerLeg; }
        public int NumberOfMaxScores { get => _numberOfMaxScores; }

        public Player(string name)
        {
            _name = name;
        }

        public void throwDart(Area area, int score)
        {
            Throw t = new Throw(this, area, score);
        }

        public Throw getLatestThrow()
        {
            return _throws[_throws.Count - 1];
        }

        public void calculateAveragePerSet(List<Set> sets)
        {
            // Logic to calculate average for the sets
            _averagePerSet = 0;
        }

        public void calculateAveragePerLeg(List<Leg> legs)
        {
            // Logic to calculate average for the legs
            _averagePerLeg = 0;
        }

        public void calculateNumberOfMaxScores()
        {
            // Logic to calculate number of max scores
            _numberOfMaxScores = 0;
        }
    }
}
