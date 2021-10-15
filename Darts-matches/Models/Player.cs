using System.Collections.Generic;

namespace Darts_matches.Models
{
    public class Player
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

        public void ThrowDart(Area area, int score)
        {
            Throw t = new Throw(this, area, score);
        }

        public Throw GetLatestThrow()
        {
            return _throws[_throws.Count - 1];
        }

        // TODO: add logic to calculate average for the sets
        public void CalculateAveragePerSet(List<Set> sets)
        {
            _averagePerSet = 0;
        }

        // TODO: add logic to calculate average for the legs
        public void CalculateAveragePerLeg(List<Leg> legs)
        {
            _averagePerLeg = 0;
        }

        // TODO: add logic to calculate number of max scores
        public void CalculateNumberOfMaxScores()
        {
            _numberOfMaxScores = 0;
        }
    }
}
