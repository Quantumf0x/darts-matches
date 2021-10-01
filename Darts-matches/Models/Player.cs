using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Player
    {
        string name;
        List<Throw> throws;
        int averagePerSet;
        int averagePerLeg;
        int numberOfMaxScores;

        public Player(string name)
        {
            this.name = name;
        }

        public void throwDart(Area area, int score)
        {
            Throw t = new Throw(this, area, score);
        }

        public Throw getLatestThrow()
        {
            return throws[throws.Count - 1];
        }

        public void calculateAveragePerSet(List<Set> sets)
        {
            // Logic to calculate average for the sets
            averagePerSet = 0;
        }

        public void calculateAveragePerLeg(List<Leg> legs)
        {
            // Logic to calculate average for the legs
            averagePerLeg = 0;
        }

        public void calculateNumberOfMaxScores()
        {
            // Logic to calculate number of max scores
            numberOfMaxScores = 0;
        }
    }
}
