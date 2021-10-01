using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    internal class Match
    {
        private string _name;
        private string _tournament;
        private string _freeInput;
        private DateTime _date;
        private Player _playerOne;
        private Player _playerTwo;
        private Player _winner;
        private int _numberOfSets;
        private int _numberOfLegsPerSet;
        private List<Set> _sets;

        public string Name { get => _name; }
        public string Tournament { get => _tournament; }
        public string FreeInput { get => _freeInput; }
        public DateTime Date { get => _date; }
        public Player PlayerOne { get => _playerOne; }
        public Player PlayerTwo { get => _playerTwo; }
        public Player Winner { get => _winner; }


        public Match(string name, string tournament, string freeInput, Player playerOne, Player playerTwo, int numberOfSets, int numberOfLegsPerSet)
        {
            _name = name;
            _tournament = tournament;
            _freeInput = freeInput;
            _date = DateTime.Today;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _numberOfSets = numberOfSets;
            _numberOfLegsPerSet = numberOfLegsPerSet;

            for (int i = 0; i < numberOfSets; i++)
            {
                createNewSet();
            }
        }

        public void calculateWinner()
        {
            // Logic to calculate the winner of the match
            Player winner = null;
            _winner = winner;
        }

        private void createNewSet()
        {
            int setNumber = _sets.Count + 1;
            Set set = new Set(setNumber, _numberOfLegsPerSet);
            _sets.Add(set);
        }
    }
}
