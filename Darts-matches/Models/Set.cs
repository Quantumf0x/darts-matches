using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Set
    {
        int setNumber;
        Player winner;
        List<Leg> legs;

        public Set(int setNumber)
        {
            this.setNumber = setNumber;
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the set
            Player winner = null;
            this.winner = winner;
        }

        public Leg createNewLeg()
        {
            int legNumber = legs.Count + 1;
            Leg leg = new Leg(legNumber);
            legs.Add(leg);
            return leg;
        }
    }
}
