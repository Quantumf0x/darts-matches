using System;
using System.Collections.Generic;

namespace Darts_matches.Models
{
    internal class Match
    {
        private string _name;
        private string _notes;
        private DateTime _date;
        private Player _playerOne;
        private Player _playerTwo;
        private Player _winner;
        private int _numberOfSets;
        private int _numberOfLegsPerSet;
        private List<Set> _sets;

        public string Name { get => _name; set => _name = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Player PlayerOne { get => _playerOne; set => _playerOne = value; }
        public Player PlayerTwo { get => _playerTwo; set => _playerTwo = value; }
        public Player Winner { get => _winner; set => _winner = value; }


        public Match(string name, DateTime date)
        {
            _name = name;
            _date = date;
        }

        public void setupMatch()
        {
            for (int i = 0; i < _numberOfSets; i++)
            {
                CreateNewSet();
            }
        }

        // TODO: add logic to calculate the winner of the match
        public void CalculateWinner()
        {
            Player winner = null;
            _winner = winner;
        }

        private void CreateNewSet()
        {
            int setNumber = _sets.Count + 1;
            Set set = new Set(setNumber, _numberOfLegsPerSet);
            _sets.Add(set);
        }
    }
}
