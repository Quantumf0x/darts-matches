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
        List<Set> sets;

        public Match(string name, string tournament, string inputField, Player playerOne, Player playerTwo, int numberOfSets)
        {
            this.name = name;
            this.tournament = tournament;
            this.inputField = inputField;
            date = DateTime.Today;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.numberOfSets = numberOfSets;
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the match
            Player winner = null;
            this.winner = winner;
        }

        public Set createNewSet()
        {
            int setNumber = sets.Count + 1;
            Set set = new Set(setNumber);
            sets.Add(set);
            return set;
        }
    }
}
