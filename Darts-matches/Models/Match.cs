using System;
using System.Collections.Generic;

namespace Darts_matches.Models
{
    internal class Match
    {
        private string _name;
        private string _tournament;
        private string _notes;
        private DateTime _date;
        private Player _playerOne;
        private Player _playerTwo;
        private Player _winner;
        private int _numberOfSets;
        private int _numberOfLegsPerSet;
        private List<Set> _sets;

        public string Name { get => _name; }
        public string Tournament { get => _tournament; }
        public string FreeInput { get => _notes; }
        public DateTime Date { get => _date; }
        public Player PlayerOne { get => _playerOne; }
        public Player PlayerTwo { get => _playerTwo; }
        public Player Winner { get => _winner; }


        public Match(string name, string tournament, string notes, Player playerOne, Player playerTwo, int numberOfSets, int numberOfLegsPerSet)
        {
            _name = name;
            _tournament = tournament;
            _notes = notes;
            _date = DateTime.Today;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _numberOfSets = numberOfSets;
            _numberOfLegsPerSet = numberOfLegsPerSet;

            for (int i = 0; i < numberOfSets; i++)
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
