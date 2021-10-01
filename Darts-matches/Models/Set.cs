using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Set
    {
        int setNumber;
        int numberOfLegs;
        Player winner;
        List<Leg> legs;

        public Set(int setNumber, int numberOfLegs)
        {
            this.setNumber = setNumber;
            this.numberOfLegs = numberOfLegs;

            for (int i = 0; i < numberOfLegs; i++)
            {
                createNewLeg();
            }
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the set
            Player winner = null;
            this.winner = winner;
        }

        private void createNewLeg()
        {
            int legNumber = legs.Count + 1;
            Leg leg = new Leg(legNumber);
            legs.Add(leg);
            return leg;
        }
    }
}
