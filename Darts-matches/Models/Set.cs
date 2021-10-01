using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    internal class Set
    {
        private int _setNumber;
        private int _numberOfLegs;
        private Player _winner;
        private List<Leg> _legs;

        public int SetNumber { get => _setNumber; }
        public Player Winner { get => _winner; }

        public Set(int setNumber, int numberOfLegs)
        {
            _setNumber = setNumber;
            _numberOfLegs = numberOfLegs;

            for (int i = 0; i < numberOfLegs; i++)
            {
                createNewLeg();
            }
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the set
            Player winner = null;
            _winner = winner;
        }

        private void createNewLeg()
        {
            int legNumber = _legs.Count + 1;
            Leg leg = new Leg(legNumber);
            _legs.Add(leg);
        }
    }
}
