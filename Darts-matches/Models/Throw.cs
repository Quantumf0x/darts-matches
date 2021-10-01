using System;
using System.Collections.Generic;
using System.Text;

namespace Darts_matches.Models
{
    class Throw
    {
        Player player;
        Area area;
        int score;

        public Throw(Player player, Area area, int score)
        {
            this.player = player;
            this.area = area;
            this.score = score;
        }
    }
}
