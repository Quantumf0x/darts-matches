using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Match
    {
        string name;
        string tournament;
        string inputField;
        DateTime date;

        Player playerOne;
        Player playerTwo;
        Player winner;

        int numberOfSets;
        int numberOfLegsPerSet;
        List<Set> sets;

        public Match(string name, string tournament, string inputField, Player playerOne, Player playerTwo, int numberOfSets, int numberOfLegsPerSet)
        {
            this.name = name;
            this.tournament = tournament;
            this.inputField = inputField;
            date = DateTime.Today;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.numberOfSets = numberOfSets;
            this.numberOfLegsPerSet = numberOfLegsPerSet;

            for (int i = 0; i < numberOfSets; i++)
            {
                createNewSet();
            }
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the match
            Player winner = null;
            this.winner = winner;
        }

        private void createNewSet()
        {
            int setNumber = sets.Count + 1;
            Set set = new Set(setNumber, numberOfLegsPerSet);
            sets.Add(set);
            return set;
        }
    }
}
