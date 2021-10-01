using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Leg
    {
        int legNumber;
        Player winner;
        List<Throw> throws;
        int scorePlayerOne;
        int scorePlayerTwo;
    }
}
