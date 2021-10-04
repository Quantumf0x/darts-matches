using System.Collections.Generic;

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
                CreateNewLeg();
            }
        }

        // TODO: add logic to calculate the winner of the set
        public void CalculateWinner()
        {
            Player winner = null;
            _winner = winner;
        }

        private void CreateNewLeg()
        {
            int legNumber = _legs.Count + 1;
            Leg leg = new Leg(legNumber);
            _legs.Add(leg);
        }
    }
}
