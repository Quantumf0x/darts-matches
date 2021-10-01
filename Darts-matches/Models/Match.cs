using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Match
    {
        string name;
        string tournamentName;
        string inputField;
        DateTime date;

        Player playerOne;
        Player playerTwo;
        Player winner;

        int numberOfSets;
        List<Set> sets;
    }
}
