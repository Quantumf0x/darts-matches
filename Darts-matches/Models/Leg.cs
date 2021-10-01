using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Leg
    {
        int legNumber;
        Player winner;
        List<Throw> throws;
        int scorePlayerOne;
        int scorePlayerTwo;

        public Leg(int legNumber)
        {
            this.legNumber = legNumber;
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the set
            Player winner = null;
            this.winner = winner;
        }

        public void addThrow(Player player)
        {
            throws.Add(player.getLatestThrow());
        }

        public void calculateScoresPerPlayer()
        {
            // Logic to calculate score per player
            scorePlayerOne = 0;
            scorePlayerTwo = 0;
        }
    }
}
